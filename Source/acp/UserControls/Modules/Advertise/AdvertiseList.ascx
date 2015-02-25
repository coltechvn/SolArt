<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiseList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Advertise.AdvertiseList" %>
<div align="center">
<TABLE class="Area" cellSpacing="0" cellPadding="4" width="760" border="0">
	<TR>
		<TD colSpan="2">
			<table cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR>
					<TD colspan="2">Sử dụng
						<asp:checkbox id="chkEnable" runat="server" Checked="True"></asp:checkbox></TD>
				</TR>
				<tr align="center">
					<td width="170"><b>Vị trí</b></td>
					<td><b>Khu vực</b></td>
				</tr>
				<tr align="center">
					<td><asp:listbox id="lstPositions" runat="server" Width="160px" Height="152px"></asp:listbox></td>
					<td><asp:listbox id="lstZones" runat="server" Width="100%" Height="152px" SelectionMode="Multiple"></asp:listbox></td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD colspan="2">
			<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="lstPositions" ErrorMessage="Phải nhập vị trí đăng quảng cáo"></asp:requiredfieldvalidator><br />
			<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="lstZones" ErrorMessage="Phải nhập khu vực đăng quảng cáo"></asp:requiredfieldvalidator></TD>
	</TR>
</TABLE>
<TABLE style="PADDING-BOTTOM: 5px; PADDING-TOP: 5px" cellSpacing="0" cellPadding="0" width="760"
	border="0">
	<TR>
		<TD valign="top" colspan="2">
			<asp:Button id="cmdSearch" runat="server" Width="66px" Text="Tìm" OnClick="cmdSearch_Click"></asp:Button>&nbsp;
			<asp:Button id="cmdAddNew" runat="server" Width="66" Text="Thêm" OnClick="cmdAddNew_Click"></asp:Button>
		</TD>
	</TR>
	<tr>
		<td><asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
	</tr>
</TABLE>
<asp:DataGrid id="dtgAdvertises" runat="server" Width="760px" AutoGenerateColumns="False" PageSize="2"
	CellPadding="2" OnItemCommand="dtgAdvertises_ItemCommand" OnItemDataBound="dtgAdvertises_ItemDataBound">
	<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
	<ItemStyle CssClass="LightRow"></ItemStyle>
	<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
	<Columns>
		<asp:BoundColumn Visible="False" DataField="Advertise_ID" HeaderText="ID">
			<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
		</asp:BoundColumn>
		<asp:TemplateColumn HeaderText="Ảnh">
			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
			<ItemTemplate>
				<asp:Literal id="litUrl" runat="server"></asp:Literal>
			</ItemTemplate>
		</asp:TemplateColumn>
		
		<asp:BoundColumn DataField="Advertise_Type" HeaderText="Loại">
			<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
		</asp:BoundColumn>
		<asp:BoundColumn DataField="Advertise_Click" HeaderText="Click">
			<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
		</asp:BoundColumn>
		<asp:TemplateColumn HeaderText="Thứ tự">
			<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
			<HeaderTemplate>
				<asp:Button id="Button1" runat="server" Width="58px" Text="Sắp xếp" CommandName="priority"></asp:Button>
			</HeaderTemplate>
			<ItemTemplate>
				<asp:DropDownList id="dropPriority" runat="server" Width="58px" CssClass="InputBox"></asp:DropDownList>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn>
			<HeaderStyle Width="1%"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
			<ItemTemplate>
				<asp:Button id="ImageButton1" runat="server" CssClass="FlatButton" CommandName="edit" Text="Sửa"
					CausesValidation="False"></asp:Button>
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn>
			<HeaderStyle HorizontalAlign="Center" Width="1%"></HeaderStyle>
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
			<ItemTemplate>
				<asp:Button id="cmdDel" runat="server" CssClass="FlatButton" CommandName="del" Text="Xóa" CausesValidation="False"></asp:Button>
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:DataGrid>
</div>