<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.UserProfile" %>
<div align="center">
<table class="Area" id="Table1" cellspacing="0" cellpadding="5" width="500" border="0">
	<tr>
		<td colspan="2">
			<asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td style="width: 20%">Email</td>
		<td>
			<asp:textbox id="txtEmail" runat="server" Width="296px" Enabled="False" CssClass="solidnormal"></asp:textbox></td>
	</tr>
	<tr>
		<td>Họ tên</td>
		<td>
			<asp:textbox id="txtFullName" runat="server" Width="296px" CssClass="solidnormal"></asp:textbox>
			<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="(*)" ControlToValidate="txtFullName"
				Display="Dynamic"></asp:requiredfieldvalidator></td>
	</tr>
	<tr>
		<td>Giới tính</td>
		<td>
			<asp:dropdownlist id="dropGender" runat="server" Width="296px" CssClass="solidnormal">
				<asp:ListItem Value="1">Nam</asp:ListItem>
				<asp:ListItem Value="0">Nữ</asp:ListItem>
			</asp:dropdownlist></td>
	</tr>
	<tr>
		<td>Địa chỉ</td>
		<td>
			<asp:textbox id="txtAddress" runat="server" Width="296px" CssClass="solidnormal"></asp:textbox></td>
	</tr>
	<tr>
		<td>Ngày sinh</td>
		<td>
			<asp:textbox id="txtBirthDay" runat="server" Width="296px" CssClass="solidnormal"></asp:textbox></td>
	</tr>
	<tr>
		<td>Điện thoại</td>
		<td>
			<asp:textbox id="txtPhone" runat="server" Width="296px" CssClass="solidnormal"></asp:textbox></td>
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