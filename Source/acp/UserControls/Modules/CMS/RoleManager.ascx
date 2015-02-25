<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleManager.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.RoleManager" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<table cellspacing="0" cellpadding="0" width="760" border="0">
	<tr>
		<td width="60%" valign="top">
			<cc1:datagrid id="dtgUsers" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
				PageSize="15" CellPadding="2" OnItemCommand="dtgUsers_ItemCommand">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="User_ID" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="User_Email" HeaderText="Email">
						<HeaderStyle Width="30%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="User_FullName" HeaderText="Tên">
						<HeaderStyle Width="35%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="1%"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="Button2" Width="80px" CausesValidation="False" CommandName="roles" runat="server"
								Text="Phân quyền"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</cc1:datagrid>
		</td>
		<td width="5"></td>
		<td valign="top">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" class="SidePanel">
				<tr>
					<td style="height: 20px;">
						Email : &nbsp;<asp:Label id="lblUserEmail" runat="server" ForeColor="Red"></asp:Label></td>
				</tr>
				<tr>
					<td style="height: 40px;">
						<asp:CheckBoxList id="chkRoles" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns=1>
							<asp:ListItem Value="2">Admin</asp:ListItem>
							<asp:ListItem Value="1">Quản lý chuyên mục</asp:ListItem>
							<asp:ListItem Value="0">Biên tập viên</asp:ListItem>
						</asp:CheckBoxList></td>
				</tr>
				<tr>
				    <td style="height: 10px;"></td>
				</tr>
				<tr>
					<td style="height: 20px;">Quyền chuyên mục</td>
				</tr>
				<tr>
				    <td><asp:ListBox id="lstCMSRoles" runat="server" SelectionMode="Multiple" Width="100%" Rows="15" CssClass="solidnormal"></asp:ListBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="lblUpdateStatus" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td align="center">
						<asp:Button id="cmdUpdate" runat="server" Text="Cập nhật" Width="88px" OnClick="cmdUpdate_Click"></asp:Button></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</div>