<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCmdRoles.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.UserCmdRoles" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<table cellspacing="0" cellpadding="0" border="0" width="600">
	<tr>
		<td style="width: 20%">
			Người dùng</td>
		<td>
			<asp:Label id="lblUserEmail" runat="server" ForeColor="Red"></asp:Label></td>
		<td align="right" style="width: 20%"></td>
	</tr>
</table>
<br />
<table cellspacing="0" cellpadding="5" border="0" class="SidePanel" width="600">
	<tr>
		<td style="width: 50%">Quyền người dùng</td>
		<td style="width: 50"></td>
		<td style="width: 50%">
			Tất cả</td>
	</tr>
	<tr>
		<td>
			<asp:ListBox id="lstUserRoles" runat="server" Width="100%" SelectionMode="Multiple" Rows="15" CssClass="solidnormal"></asp:ListBox></td>
		<td valign="middle">
			<asp:Button id="cmdAdd" runat="server" Text="<<" Width="45px" OnClick="cmdAdd_Click"></asp:Button><br />
			<br />
			<asp:Button id="cmdRemover" runat="server" Text=">>" Width="45px" OnClick="cmdRemover_Click"></asp:Button></td>
		<td>
			<asp:ListBox id="lstRoles" runat="server" Width="100%" SelectionMode="Multiple" Rows="15" CssClass="solidnormal"></asp:ListBox></td>
	</tr>
	<tr>
		<td colspan="3"><asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
	</tr>
</table>
</div>