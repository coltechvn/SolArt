<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectDate.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Controls.SelectDate" %>
<table cellSpacing="0" cellPadding="0" border="0">
	<tr>
		<td>Ngày
			<asp:DropDownList id="dropDay" runat="server" Width="50" CssClass="solidnormal"></asp:DropDownList></td>
		<td>&nbsp;Tháng
			<asp:DropDownList id="dropMonth" runat="server" Width="50" CssClass="solidnormal"></asp:DropDownList></td>
		<td>&nbsp;Năm
			<asp:DropDownList id="dropYear" runat="server" Width="60" CssClass="solidnormal"></asp:DropDownList></td>
	</tr>
</table>