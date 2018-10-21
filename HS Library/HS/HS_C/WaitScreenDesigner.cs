using System.Web.UI.Design;

namespace HS
{
    /// <summary>
    /// The designer for the wait screen control.
    /// </summary>
    public class WaitScreenDesigner : ControlDesigner
    {
        /// <summary>
        /// Retrieves the HTML markup that is used to represent 
        /// the control at design time.
        /// </summary>
        /// <returns>
        /// The HTML markup used to represent the control at design time.
        /// </returns>
        public override string GetDesignTimeHtml()
        {
            var imageUrl = ((WaitScreen)Component).ImageUrl;
            
            if (!imageUrl.Contains("mvwres://"))
            {
                var webApp =
                (IWebApplication)Component.Site.GetService(
                    typeof(IWebApplication));
                var item = webApp.GetProjectItemFromUrl(imageUrl);
                return string.Concat(
                    "<img src=\"",
                    item.PhysicalPath,
                    "\" alt=\"Please wait...\" />");
            }
            return string.Concat(
                  "<img src=\"",
                  imageUrl,
                  "\" alt=\"Please wait...\" />");
       
        }

    }
}
