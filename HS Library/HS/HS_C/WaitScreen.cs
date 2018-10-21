using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;

[assembly: WebResource("HS.Busy.gif", "image/gif")]
namespace HS
{
    /// <summary>
    /// The WaitScreen control displays a grafic while a long running operation 
    /// is running.
    /// </summary>
    [ToolboxData("<{0}:WaitScreen runat=server></{0}:WaitScreen>"),]
    [ToolboxBitmap(typeof(WaitScreen), "HS.WaitScreen.ico")]
    [Designer(typeof(WaitScreenDesigner))]
    [DefaultEvent("Process")]
    [DefaultProperty("ImageUrl")]
    public class WaitScreen : WebControl
    {
        // This field holds the URL pointing to an image.
        private string _imageUrl = "~/images/busy.gif";
        private static readonly Type s_thisType = typeof(WaitScreen);

        /// <summary>
        /// Delegate for long running process.
        /// </summary>
        public delegate void ProcessHandler(object sender, EventArgs e);

        /// <summary>
        /// The process event.
        /// </summary>
        [Category("Action")]
        [Description("the method executing the long running operation.")]
        public event ProcessHandler Process;

        /// <summary>Gets/sets the URL pointing to an image.</summary>
        /// <value>A <see cref="string">string</see> containing the URL pointing 
        /// to an image..</value>
        /// <remarks>This property gets/sets the URL pointing to an image.
        /// </remarks>
        [Description("Gets/sets the URL pointing to an image.")]
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that 
        /// contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _imageUrl =Page.ClientScript.GetWebResourceUrl(s_thisType,"HS.Busy.gif");
        }

        /// <summary>
        /// Triggers the Process event.
        /// </summary>
        public virtual void OnProcess()
        {
            Process(this, null);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //Do not output!!!!
        }

        /// <summary>
        /// Triggers the Load event.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Page.Response.Buffer = true;

            #region Show splash screen

            Page.Response.Write(
                string.Concat(@"<script type=""text/javascript""> 
//<![CDATA[
<!--

function hideObject(obj) 
{
    obj.style.display = 'none';
}
// -->
//]]>
</script>
<div id=""splashScreen""><img src=""",new Control().ResolveUrl(_imageUrl), @""" alt=""busy"" /></div>"));

            #endregion

            Page.Response.Flush();

            OnProcess();

            Page.Response.Flush();

            #region Hide splash screen

            Page.Response.Write(
                @"<script type=""text/javascript""> 
//<![CDATA[
<!--
var splash
if(document.getElementById) 
{
    splash = document.getElementById('splashScreen');
}
else if(document.layers)  //NS4
{
    splash = document.splashScreen;
}
else if(document.all) //IE4
{
    splash = document.all.splashScreen;
}
hideObject(splash);
// -->
//]]>
</script>
");

            #endregion

        }





    }
}