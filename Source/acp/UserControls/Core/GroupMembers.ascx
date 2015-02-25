<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupMembers.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.GroupMembers" %>
<div align="center">
<table id="Table1" cellspacing="0" cellpadding="0" width="600" align="center" border="0">
	<tr>
		<td style="width: 20%">Nhóm</td>
		<td>
			<asp:Label id="txtGroupName" runat="server" ForeColor="Red"></asp:Label></td>
		<td align="right" style="width: 20%"></td>
	</tr>
</table>
<br />
<table class="SidePanel" id="Table2" cellspacing="0" cellpadding="5" width="600" border="0">
	<tr>
		<td style="width: 50%; text-align: center;">
			Thành viên</td>
		<td style="width: 50"></td>
		<td style="width: 50%; text-align: center;">Tất cả</td>
	</tr>
	<tr>
		<td>
			<asp:ListBox id="lstGroupMembers" runat="server" Width="100%" SelectionMode="Multiple" Rows="15" CssClass="solidnormal"></asp:ListBox></td>
		<td valign="middle">
			<asp:Button id="cmdAdd" runat="server" Text="<<" Width="45px" OnClick="cmdAdd_Click"></asp:Button><br />
			<br />
			<asp:Button id="cmdRemover" runat="server" Text=">>" Width="45px" OnClick="cmdRemover_Click"></asp:Button></td>
		<td>
			<asp:ListBox id="lstUsers" runat="server" Width="100%" SelectionMode="Multiple" Rows="15" CssClass="solidnormal"></asp:ListBox></td>
	</tr>
	<tr>
		<td colspan="3">
			<asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
	</tr>
</table>
</div>