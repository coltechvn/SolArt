<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CKEditor.aspx.cs" Inherits="iDKCMS.FrontEnd.CKEditor" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CKEditor:CKEditorControl ID="CKEditor1" runat="server" 
            FilebrowserImageBrowseUrl="/simogeo/index.html" 
            FilebrowserBrowseUrl="/simogeo/index.html" 
            FilebrowserFlashBrowseUrl="/simogeo/index.html" 
        >
        </CKEditor:CKEditorControl>
    </div>
    </form>
</body>
</html>
