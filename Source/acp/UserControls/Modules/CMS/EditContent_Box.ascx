<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent_Box.ascx.cs"
    Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.EditContent_Box" %>
<table cellspacing="0" cellpadding="3" width="100%" align="center">
    <tr>
        <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <asp:Label ID="lblStatusUpdate" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="4" width="100%" align="center" border="0">
                        <tr>
                            <td>
                                Đăng vào các box bổ trợ
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="lstZones" runat="server" Width="220px" Height="270px" SelectionMode="Multiple"
                                    CssClass="solidnormal"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="cmdUpdate" AccessKey="s" runat="server" Width="110px" Text="Cập nhật"
                                    CausesValidation="False" OnClick="cmdUpdate_Click"></asp:Button>
                                <asp:Label ID="lblStatusUpdate2" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
