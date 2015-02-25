<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install.aspx.cs" Inherits="iDKCMS.BackEnd.Install" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div align="center">
            <table border="0" cellpadding="2" cellspacing="1" width="100%">
                <tr>
                    <td width="10">
                        <asp:RadioButton runat="server" ID="radFile" GroupName="RadChoice"></asp:RadioButton></td>
                    <td width="100">
                        FileName:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Columns="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td height="50">
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Install" OnClick="Button1_Click"></asp:Button>&nbsp;&nbsp;<a
                            href="Install.aspx">[ Retry ]</a>&nbsp;&nbsp;<a href="Sql.aspx">[ Query ]</a></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:RadioButton runat="server" ID="radText" GroupName="RadChoice" Checked="True"></asp:RadioButton></td>
                    <td valign="top">
                        Text:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtString" TextMode="MultiLine" Rows="40" Columns="100"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
