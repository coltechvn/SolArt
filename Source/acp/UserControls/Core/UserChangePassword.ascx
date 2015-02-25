<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserChangePassword.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.UserChangePassword" %>
<div align="center">
<table class="Area" id="Table1" cellspacing="0" cellpadding="5" width="500" border="0">
	<tr>
		<td colspan="2">
			<asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td style="width: 20%">Mật khẩu cũ</td>
		<td>
			<asp:textbox id="txtCurPwd" runat="server" Width="296px" TextMode="Password" CssClass="solidnormal"></asp:textbox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtCurPwd"
				Display="Dynamic"></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td>Mật khẩu mới</td>
		<td>
			<asp:textbox id="txtNewPwd" runat="server" Width="296px" TextMode="Password" CssClass="solidnormal"></asp:textbox></td>
	</tr>
	<tr>
		<td>Gõ lại</td>
		<td>
			<asp:textbox id="txtRetypeNewPwd" runat="server" Width="296px" TextMode="Password" CssClass="solidnormal"></asp:textbox>
			<asp:CompareValidator id="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="txtRetypeNewPwd"
				ControlToCompare="txtNewPwd">(*)</asp:CompareValidator></td>
	</tr>
	<tr>
		<td></td>
		<td></td>
	</tr>
	<tr>
		<td></td>
		<td>
			<asp:button id="cmdUpdate" runat="server" Width="72px" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:button></td>
	</tr>
</table>
</div>