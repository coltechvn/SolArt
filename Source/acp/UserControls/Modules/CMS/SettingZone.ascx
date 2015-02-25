<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingZone.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.SettingZone" %>
<div align="center">
<table class="Area" id="Table1" cellspacing="0" cellpadding="5" width="760" align="center" border="0">
	<tr>
		<td colspan="2"><asp:label id="lblStatusUpdate" runat="server"></asp:label></td>
	</tr>
	<tr style="display: none;">
		<td colspan="2"><strong>Các mục có bài nổi bật phía dưới trang chủ</strong></td>
	</tr>
	<tr style="display: none;">
		<td colspan="2">
			<table cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:listbox id="lstZones" runat="server" Height="150px" SelectionMode="Multiple" Width="208px"></asp:listbox></td>
					<td width="50" style="text-align: center;"><asp:button id="btnAdd" runat="server" Width="40" Text=">>" OnClick="btnAdd_Click"></asp:button><br />
						<br />
						<asp:button id="btnRemover" runat="server" Width="40" Text="<<" OnClick="btnRemover_Click"></asp:button></td>
					<td><asp:listbox id="lstZoneFocus" runat="server" Height="150px" SelectionMode="Multiple" Width="208px"></asp:listbox></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr style="display: none;">
		<td colspan="2"><strong>Các mục có bài nổi bật tại ô nhỏ phía dưới bên phải trang chủ</strong></td>
	</tr>
	<tr style="display: none;">
		<td colspan="2">
			<table cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td><asp:listbox id="lstZonesSmall" runat="server" Height="150px" SelectionMode="Multiple" Width="208px"></asp:listbox></td>
					<td width="50" style="text-align: center;"><asp:button id="butZonesSmallAdd" runat="server" Width="40" Text=">>" OnClick="butZonesSmallAdd_Click"></asp:button><br />
						<br />
						<asp:button id="butZonesSmallRemove" runat="server" Width="40" Text="<<" OnClick="butZonesSmallRemove_Click"></asp:button></td>
					<td><asp:listbox id="lstZonesSmallFocus" runat="server" Height="150px" SelectionMode="Multiple" Width="208px"></asp:listbox></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td width="30%">Mục trang chủ</td>
		<td><asp:dropdownlist id="dropZoneHome" runat="server" Width="312px" CssClass="solidnormal"></asp:dropdownlist></td>
	</tr>
    <tr>
		<td width="30%">Mục đăng ký học</td>
		<td><asp:dropdownlist id="dropClassRegister" runat="server" Width="312px" CssClass="solidnormal"></asp:dropdownlist></td>
	</tr>
    <tr>
		<td width="30%">Mục các lớp học</td>
		<td><asp:dropdownlist id="dropKhoaHoc" runat="server" Width="312px" CssClass="solidnormal"></asp:dropdownlist></td>
	</tr>
    <tr>
		<td></td>
		<td><asp:button id="cmdUpdate" runat="server" Width="88px" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:button></td>
	</tr>
</table>
</div>