<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingManager.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.SettingManager" %>
<%@ Register TagPrefix="cc1" Namespace="AWS.FilePicker" Assembly="FilePickerControl" %>

<div align="center">
<table class="Area" id="Table1" cellspacing="0" cellpadding="5" width="600" border="0">
	<tr>
		<td colspan="2"><asp:label id="lblStatusUpdate" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td style="width: 30%">Tên website</td>
		<td><asp:TextBox id="txtWebTitle" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%">Mail Server</td>
		<td><asp:TextBox id="txtMailServer" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%">Mail Server Port</td>
		<td><asp:TextBox id="txtMailServerPort" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
    <tr>
        <td style="width: 30%">
            Mail username</td>
        <td>
            <asp:TextBox ID="txtMailUsername" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 30%">
            Mail password</td>
        <td>
            <asp:TextBox ID="txtMailPassword" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
    </tr>
	<tr>
		<td style="width: 30%">Thời gian cache</td>
		<td><asp:TextBox id="txtDefaultCacheExpire" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox>&nbsp;(h)</td>
	</tr>
	<tr>
		<td style="width: 30%">Contact Email</td>
		<td><asp:TextBox id="txtContactEmail" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%">Thông tin chung các khóa học:</td>
		<td>
		<cc1:FilePicker ID="txtBrochureFile" runat="server" CssClass="solidnormal" Width="280px" fpUploadDir="/Upload/Main/" fpPopupURL="../FilePicker/FilePicker.aspx"></cc1:FilePicker>
		</td>
	</tr>
    <tr>
		<td style="width: 30%">Nhạc nền:</td>
		<td>
		<cc1:FilePicker ID="txtSound" runat="server" CssClass="solidnormal" Width="280px" fpUploadDir="/Upload/Main/" fpPopupURL="../FilePicker/FilePicker.aspx"></cc1:FilePicker>
		</td>
	</tr>
	<tr>
		<td style="width: 30%">Hotline</td>
		<td><asp:TextBox id="txtHotline" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%">YM1:</td>
		<td><asp:TextBox id="txtYM1" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%">YM2:</td>
		<td><asp:TextBox id="txtYM2" runat="server" Width="280px" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%" colspan="2">Từ khóa tối ưu tìm kiếm</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:TextBox id="txtMetaSearch" runat="server" Width="100%" TextMode="MultiLine" Rows="5" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 30%" colspan="2">Mô tả website</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:TextBox id="txtMetaDescription" runat="server" Width="100%" TextMode="MultiLine" Rows="5" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td></td>
		<td>
			<asp:Button id="cmdUpdate" runat="server" Width="72px" Text="Cập nhật" OnClick="cmdUpdate_Click" ></asp:Button></td>
	</tr>
</table>
</div>
