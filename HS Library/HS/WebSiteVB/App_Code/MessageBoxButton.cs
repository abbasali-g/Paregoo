using System;
using System.Web;
using System.Web.UI;

//using System.Data;
//using System.Configuration;
//using System.Linq;

//using System.Web.Security;

//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

using System.Text;



/// <summary>
/// Summary description for MessageBoxButton
/// </summary>
public class MessageBoxButton
{
    private string msg_button = "";

    public MessageBoxButton(string btnValue)
    {
        msg_button = "<input type=\"button\" value=\"" + btnValue + "\"";
    }

    public void SetClass(string btnClass)
    {
        msg_button += " class=\"" + btnClass + "\"";
    }

    public void SetLocation(string btnLocation)
    {
        msg_button += " onClick=\"window.location='" + btnLocation + "'\"";
    }

    public string ReturnObject()
    {
        return msg_button += ">";
    }

}
