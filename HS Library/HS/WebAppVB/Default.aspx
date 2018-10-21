<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebAppVB._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>

<style> 
.page_dimmer 
{ 
position:fixed; 
height:100%; 
width:100%; 
top:0px; 
left:0px; 
background-color:#000000; 
filter:alpha(opacity=50); 
-moz-opacity:.50; 
opacity:.50; 
z-index:50; 
} 


.msg_box_container 
{ 
position:fixed; 
background-color:#888888; 
border:1px solid #999999; 
z-index:50; 
left:20%; 
right:20%; 
top:20%;" 
} 

</style> 


<body>
    <form id="form1" runat="server">
    <div>
    
      <div class="page_dimmer" id="pagedimmer"> </div> 
<div class="msg_box_container" id="msgbox"> 
<table width="100%"> 
<tr> 
<td colspan="2">[TITLE]</td> 
</tr> 
<tr> 
<td>[ICON]</td> 
<td>[MESSAGE]</td> 
</tr> 
<tr> 
<td colspan="2"><input type="Button" value="OK" 
   onClick="document.getElementById('pagedimmer').style.visibility = 'hidden'; 
          document.getElementById('msgbox').style.visibility = 'hidden'"></td> 
</tr> 
</table> 
</div> 
    
    </div>
    </form>
</body>
</html>
