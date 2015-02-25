<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManager.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.UserManager" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<table cellspacing="0" cellpadding="0" width="900" border="0">
	<tr>
		<td valign="top" >
			<cc1:NewDataGrid id="dtgUsers" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="15"
				runat="server" CellPadding="2" OnItemCommand="dtgUsers_ItemCommand" OnItemDataBound="dtgUsers_ItemDataBound" BorderWidth="0">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="User_ID" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="User_Email" HeaderText="Email">
						<HeaderStyle Width="30%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="User_FullName" HeaderText="T&#234;n">
						<HeaderStyle Width="35%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="1%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" Width="40" CausesValidation="False" Text="Sửa" CommandName="edit"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="1%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="cmdDel" runat="server" Width="40" CausesValidation="False" Text="Xóa" CommandName="del"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="1%"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="Button2" Width="80px" CausesValidation="False" CommandName="roles" runat="server"
								Text="Phân quyền"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</cc1:NewDataGrid></td>
		<td style="width: 10px"></td>
		<td valign="top" style="width: 300px">
			<table class="Area" cellspacing="0" cellpadding="5" width="100%" border="0">
				<tr>
					<td colspan="2"><asp:label id="lblUpdateStatus" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td style="width: 25%"></td>
					<td><asp:textbox id="txtID" Width="173px" runat="server" Enabled="False" Visible="False" CssClass="solidnormal"></asp:textbox></td>
				</tr>
				<tr>
					<td>Email</td>
					<td><asp:textbox id="txtEmail" Width="173px" runat="server" CssClass="solidnormal"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="(*)" ControlToValidate="txtEmail"
							Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ErrorMessage="(*)" ControlToValidate="txtEmail"
							ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">(*)</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td>Họ tên</td>
					<td><asp:textbox id="txtFullName" Width="173px" runat="server" CssClass="solidnormal"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtFullName" ErrorMessage="(*)"
							Display="Dynamic"></asp:requiredfieldvalidator></td>
				</tr>
				<tr>
					<td>Mật khẩu</td>
					<td><asp:textbox id="txtPassword" Width="173px" runat="server" TextMode="Password" CssClass="solidnormal"></asp:textbox></td>
				</tr>
				<tr>
					<td>Giới tính</td>
					<td><asp:dropdownlist id="dropGender" Width="173px" runat="server" CssClass="solidnormal">
							<asp:ListItem Value="1">Nam</asp:ListItem>
							<asp:ListItem Value="0">Nữ</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Địa chỉ</td>
					<td><asp:textbox id="txtAddress" Width="173px" runat="server" CssClass="solidnormal"></asp:textbox></td>
				</tr>
				<tr>
					<td>Ngày sinh</td>
					<td><asp:textbox id="txtBirthDay" Width="173px" runat="server" CssClass="solidnormal"></asp:textbox></td>
				</tr>
				<tr>
					<td>Điện thoại</td>
					<td><asp:textbox id="txtPhone" Width="173px" runat="server" CssClass="solidnormal"></asp:textbox></td>
				</tr>
				<tr>
					<td>Super&nbsp;Admin</td>
					<td><asp:checkbox id="chkIsSuperAdmin" runat="server"></asp:checkbox></td>
				</tr>
				<tr>
					<td>Nhóm</td>
					<td><asp:listbox id="lstGroups" Width="173px" runat="server" Rows="5" SelectionMode="Multiple" CssClass="solidnormal"></asp:listbox></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:button id="cmdUpdate" Width="72px" runat="server" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:button>
						<asp:button id="cmdAddNew" Width="72px" runat="server" Text="Thêm mới" OnClick="cmdAddNew_Click" ></asp:button>
						<asp:button id="cmdEmpty" Width="72" runat="server" Text="Hủy" CausesValidation="False" OnClick="cmdEmpty_Click"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</div>