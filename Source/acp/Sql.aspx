<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sql.aspx.cs" Inherits="iDKCMS.BackEnd.Sql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Query</title>
    <style>
			.TextCourier {
				font-family: Courier New, Courier, Verdana, Arial;
			}
		</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="Install.aspx">[ Install ]</a>&nbsp;&nbsp;<a href="Sql.aspx">[ Retry ]</a><br>
			&nbsp;&nbsp;&nbsp;<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
			<asp:TextBox id="TextBox1" runat="server" Width="900" CssClass="TextCourier"></asp:TextBox>&nbsp;<asp:Button 
            id="Button1" runat="server" Text="Button" onclick="Button1_Click"></asp:Button>
			<asp:DataGrid id="DataGrid1" Runat="server"></asp:DataGrid>
			<asp:Label id="Label1" runat="server">Label</asp:Label>
    </div>
    </form>
</body>
</html>
