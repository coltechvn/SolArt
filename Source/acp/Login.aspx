<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iDKCMS.BackEnd.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>iDK Control Panel: Login Page</title>
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link rel="stylesheet" type="text/css" href="theme/iDK/css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
            <tr>
                <td style="height: 200px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 210px" class="bodyline">
                    <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                        <tr>
                            <td class="tdNotice">
                                &nbsp;<asp:Label ID="lblMessage" runat="server" Visible="False">Thông tin không chính xác</asp:Label></td>
                            <td style="width: 414px">
                                <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                    <tr>
                                        <td>
                                            <img alt="" src="theme/idk/img/Login_03.gif" width="414" height="24" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img alt="" src="theme/idk/img/Login_05.gif" width="414" height="49" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                <tr>
                                                    <td style="width: 38px">
                                                        <img alt="" src="theme/idk/img/Login_06.gif" width="38" height="137" /></td>
                                                    <td class="bglogin">
                                                        <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                                                    <tr>
                                                                                        <td class="alignleft" style="height: 36px; width: 74px" valign="bottom">
                                                                                            <img alt="" src="theme/idk/img/Login_09.gif" width="43" height="16" /></td>
                                                                                        <td valign="bottom" class="tdinputpad">
                                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtinput"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="width: 50px">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                                                ControlToValidate="txtEmail"></asp:RequiredFieldValidator></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="alignleft" style="height: 32px" valign="bottom">
                                                                                            <img alt="" src="theme/idk/img/Login_14.gif" width="69" height="15" />&nbsp;</td>
                                                                                        <td valign="bottom" class="tdinputpad">
                                                                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txtinput"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                                                ControlToValidate="txtPassword"></asp:RequiredFieldValidator></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td style="width: 32px">
                                                                                <img alt="" src="theme/idk/img/Login_08.gif" width="32" height="88" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                                                    <tr>
                                                                                        <td style="height: 36px" valign="top">
                                                                                            <table style="width: 100%" cellpadding="0" cellspacing="0" class="border0line">
                                                                                                <tr>
                                                                                                    <td class="alignleft" style="width: 105px">
                                                                                                        <img alt="" src="theme/idk/img/Login_18.gif" width="97" height="21" /></td>
                                                                                                    <td class="alignleft">
                                                                                                        <asp:CheckBox ID="chkRememberPwd" runat="server"></asp:CheckBox></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img alt="" src="theme/idk/img/Login_22.gif" width="202" height="13" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td style="width: 174px">
                                                                                <asp:Button ID="btLogin" runat="server" Text="" CssClass="butLogin" 
                                                                                    onclick="BtLoginClick">
                                                                                </asp:Button></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 157px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
