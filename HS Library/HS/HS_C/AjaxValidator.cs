
//using System.Data;
//using System.Configuration;
//using System.Linq;
//using System.Web.Security;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





[assembly: System.Web.UI.WebResource("HS.ClientScripts.AjaxValidator.js", "text/javascript")]// "application/x-javascript"
namespace HS
{

    /// <summary>
    /// Enables you to perform custom validation on both the client and server
    /// </summary>

    public class AjaxValidator : BaseValidator, ICallbackEventHandler
    {
        public AjaxValidator()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        public event ServerValidateEventHandler ServerValidate;
        string _controlToValidateValue;

    protected override void OnPreRender(EventArgs e)
    {

             String eventRef = Page.ClientScript.GetCallbackEventReference(this, "", "", "");

   
        //-------------------------- sarandy

            ClientScriptManager cs = Page.ClientScript;    
           cs.RegisterClientScriptResource(typeof(HS.AjaxValidator), "HS.ClientScripts.AjaxValidator.js");
        
       
        // Write out the web resource url.
        // ResourcePath.InnerHtml = Page.ClientScript.GetWebResourceUrl(rstype, rsname);

        //// Register include file
           //  String includeScript = Page.ResolveClientUrl("~/ClientScripts/AjaxValidator.js");
           //  Page.ClientScript.RegisterClientScriptInclude("AjaxValidator", includeScript);
            //--------------------------



    // Register startup script
    String startupScript =
String.Format("document.getElementById('{0}').evaluationfunction = 'AjaxValidatorEvaluateIsValid';", this.ClientID);
    Page.ClientScript.RegisterStartupScript(this.GetType() , this.ClientID+"AjaxValidator", startupScript, true);

    base.OnPreRender(e);

    }






     /// <summary>
    /// Only do the AJAX on browsers that support it
    /// </summary>
    protected override bool DetermineRenderUplevel()
    {
    return Context.Request.Browser.SupportsCallback;
    }


    /// <summary>
    /// Server method called by client AJAX call
    /// </summary>
    public string GetCallbackResult()
    {
    return ExecuteValidationFunction(_controlToValidateValue).ToString();
    }


    /// <summary>
    /// Return callback result to client
    /// </summary>
    public void RaiseCallbackEvent(string eventArgument)
    {
    _controlToValidateValue = eventArgument;
    }


    /// <summary>
    /// Server-side method for validation
    /// </summary>
    protected override bool EvaluateIsValid()
    {
    string controlToValidateValue = this.GetControlValidationValue(this.ControlToValidate);
    return ExecuteValidationFunction(controlToValidateValue);
    }



    /// <summary>
    /// Performs the validation for both server and client
    /// </summary>
    private bool ExecuteValidationFunction(String controlToValidateValue)
        {
        ServerValidateEventArgs args = new ServerValidateEventArgs(controlToValidateValue, this.IsValid);
        if (ServerValidate != null)
        ServerValidate(this, args);
        return args.IsValid;
        }




    }
}
