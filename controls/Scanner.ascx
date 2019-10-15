<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Scanner.ascx.vb" Inherits="Scanner" %>

<img id="Image1" height="150" width="150" alt="" name="Image1" src="/webroot/web/modules/employees/photos/no-photo.jpg"
   runat="server"/>
<br />
<input id="File1" type="file" size="4" name="File1" runat="server"/>

<script type="text/javascript">

function SlamPix(imgId, fileId) {
	var Image1 = document.getElementById(imgId);
	var selFilePath = document.getElementsByName(fileId)[0].value;
	
	if (selFilePath=='') {
	    Image1.src = "/webroot/web/modules/employees/photos/no-photo.jpg";
	} else {
	    Image1.src = "/webroot/web/modules/employees/photos/sel-photo.jpg";
	}	
	//alert(document.getElementsByName(fileId)[0].value);
}
</script>

