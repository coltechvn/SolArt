<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuanLyMonHoc.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Solart.QuanLyMonHoc" %>
<div align="center">
<asp:datagrid id="dtgData" CellPadding="2" runat="server" 
        AutoGenerateColumns="False" Width="500px" BorderWidth="0" 
        onitemcommand="dtgData_ItemCommand" onitemdatabound="dtgData_ItemDataBound">
		<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
		<ItemStyle CssClass="LightRow"></ItemStyle>
		<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="Monhoc_ID" HeaderText="ID"></asp:BoundColumn>
			<asp:BoundColumn DataField="Monhoc_Name" HeaderText="T&#234;n">
				<HeaderStyle Width="99%"></HeaderStyle>
			</asp:BoundColumn>
			<asp:TemplateColumn>
				<HeaderStyle Width="1%"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:Button id="Button1" Width="40" runat="server" CommandName="edit" Text="Sửa" CausesValidation="False"></asp:Button>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn>
				<HeaderStyle Width="1%"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:Button id="cmdDel" Width="40" runat="server" CommandName="del" Text="Xóa" CausesValidation="False"></asp:Button>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle Mode="NumericPages"></PagerStyle>
	</asp:datagrid>
<p style="height: 10px; margin: 0; padding: 0;"></p>
<table class="SidePanel" cellspacing="0" cellpadding="5" width="500" border="0" id="Table1">
	<tr>
		<td colspan="2">
			<asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td style="width: 20%"></td>
		<td>
			<asp:TextBox id="txtID" runat="server" Width="300px" Visible="False" CssClass="solidnormal"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 20%">Tên</td>
		<td>
			<asp:TextBox id="txtName" runat="server" Width="300px" CssClass="solidnormal"></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtName"
				Display="Dynamic"></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td style="width: 20%"></td>
		<td>
			<asp:button id="cmdUpdate" runat="server" Width="72px" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:button>
			<asp:button id="cmdAddNew" runat="server" Width="72px" Text="Thêm mới" OnClick="cmdAddNew_Click"></asp:button>
			<asp:button id="cmdEmpty" runat="server" Width="72" Text="Hủy" CausesValidation="False" OnClick="cmdEmpty_Click"></asp:button></td>
	</tr>
</table>
</div>