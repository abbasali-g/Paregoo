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


using System.Collections;
using System.Text;
using System.IO;



/// <summary>
/// Summary description for MessageBox
/// </summary>
public class MessageBox
{
    private string strLine;
    private StringBuilder msgbox;
    private StreamReader readtemplte;
    private string msgbox_title = "";
    private string msgbox_icon = "";
    private string msgbox_message = "";
    private string msgbox_ok_button = "";
    private string msgbox_buttons = "";
    private ArrayList msgbox_button;

    public MessageBox(string tpl_path)
    {
        readtemplte = new StreamReader(tpl_path);
        msgbox = new StringBuilder();
        msgbox_button = new ArrayList();

        while ((strLine = readtemplte.ReadLine()) != null)
        {
            msgbox.Append(strLine);
        }
    }

    public void SetTitle(string msg_title)
    {
        this.msgbox_title = msg_title;
    }

    public void SetIcon(string msg_icon)
    {
        this.msgbox_icon = "<img src=\"" + msg_icon + "\">";
    }

    public void SetMessage(string msg_message)
    {
        this.msgbox_message = msg_message;
    }

    public void SetOKButton(string msg_button_class)
    {
        this.msgbox_ok_button = "<input type=\"button\" value=\"OK\" class=\""
        + msg_button_class +
        "\" onClick=\"document.getElementById('pagedimmer').style.visibility = 'hidden';"
        + "document.getElementById('msgbox').style.visibility = 'hidden';\">";
    }

    public void AddButton(string msg_button)
    {
        msgbox_button.Add(msg_button);
    }

    public string ReturnObject()
    {
        int i = 0;
        while (i < msgbox_button.Count)
        {
            msgbox_buttons += msgbox_button[i] + " ";
            i++;
        }

        msgbox.Replace("[TITLE]", this.msgbox_title);
        msgbox.Replace("[ICON]", this.msgbox_icon);
        msgbox.Replace("[MESSAGE]", this.msgbox_message);
        msgbox.Replace("[BUTTONS]", msgbox_buttons + this.msgbox_ok_button);

        return msgbox.ToString();
    }

}
