<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebAppVB.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="position:fixed;height:100%;width:100%;top:0px;left:0px;
    background-color:#000000;filter:alpha(opacity=55);-moz-opacity:.55;opacity:.55;z-index:50;" 
    id="pagedimmer"> </div> 
<div style="position:fixed;background-color:#888888; border:1px solid #999999; z-index:50; left:20%; 
    right:20%; top:20%;" id="msgbox"> 
<div style="margin:5px;"> 
<table width="100%" style="background-color:#FFFFFF; border:1px solid #999999;"> 
<tr> 
<td colspan="2" style="font-family:tahoma; font-size:11px; font-weight:bold; 
    padding-left:5px; background-image: url(msg_title_1.jpg); color:#FFFFFF; height:22px;">[TITLE]</td> 
</tr> 
<tr> 
<td style="width:100px; text-align:center;">[ICON]</td> 
<td style="font-family:tahoma; font-size:11px;padding-left:5px;">[MESSAGE]</td> 
</tr> 
<tr> 
<td colspan="2" style="border-top:1px solid #CCCCCC; padding-top:5px;text-align:right;">[BUTTONS]</td> 
</tr> 
</table> 
</div> 
</div> 
    </div>
    </form>
</body>
</html>
