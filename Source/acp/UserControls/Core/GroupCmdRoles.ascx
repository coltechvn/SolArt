<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupCmdRoles.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.GroupCmdRoles" %>
<div align="center">
    <table id="Table2" cellspacing="0" cellpadding="0" width="600" border="0">
        <tr>
            <td style="width: 20%">
                Nhóm</td>
            <td>
                <asp:Label ID="txtGroupName" runat="server" ForeColor="Red"></asp:Label></td>
            <td align="right" style="width: 20%">
            </td>
        </tr>
    </table>
    <br />
    <table class="SidePanel" id="Table1" cellspacing="0" cellpadding="5" width="600"
        border="0">
        <tr align="center">
            <td style="width: 50%">
                Quyền nhóm</td>
            <td style="width: 50">
            </td>
            <td style="width: 50%">
                Tất cả</td>
        </tr>
        <tr align="center">
            <td>
                <asp:ListBox ID="lstGroupRoles" SelectionMode="Multiple" Rows="15" Width="100%" runat="server" CssClass="solidnormal">
                </asp:ListBox></td>
            <td valign="middle">
                <asp:Button ID="cmdAdd" Width="45px" runat="server" Text="<<" OnClick="cmdAdd_Click">
                </asp:Button><br />
                <br />
                <asp:Button ID="cmdRemover" Width="45px" runat="server" Text=">>" OnClick="cmdRemover_Click">
                </asp:Button></td>
            <td>
                <asp:ListBox ID="lstRoles" SelectionMode="Multiple" Rows="15" Width="100%" runat="server" CssClass="solidnormal">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label></td>
        </tr>
    </table>
</div>
