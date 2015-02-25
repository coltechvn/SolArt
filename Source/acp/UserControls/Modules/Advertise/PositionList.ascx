<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Advertise.PositionList" %>
<div align="center">
<TABLE cellSpacing="0" cellPadding="0" width="760" border="0">
	<TR>
		<TD valign="top">
			<asp:DataGrid id="dtgPositions" runat="server" Width="100%" AutoGenerateColumns="False" OnItemCommand="dtgPositions_ItemCommand" OnItemDataBound="dtgPositions_ItemDataBound">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Pos_ID" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="Pos_Position" HeaderText="Vị tr&#237;">
						<HeaderStyle Width="25%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Pos_Name" HeaderText="T&#234;n">
						<HeaderStyle Width="40%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Pos_Type" HeaderText="Kiểu">
						<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="1%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="ImageButton1" runat="server" CausesValidation="False" Width="60" Text="Sửa"
								CommandName="edit"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="1%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="cmdDel" CausesValidation="False" runat="server" Text="Xóa" Width="60" CommandName="del"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center">
			<br>
			<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0" class="Area">
				<TR>
					<TD colSpan="2">
						<asp:Label id="lblUpdateStatus" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD width="20%"></TD>
					<TD>
						<asp:TextBox id="txtID" Width="250px" runat="server" Visible="False" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>Tên</TD>
					<TD>
						<asp:TextBox id="txtName" Width="250px" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="(*)" Display="Dynamic"
							ControlToValidate="txtName"></asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD>Vị trí</TD>
					<TD>
						<asp:TextBox id="txtPosition" Width="250px" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" Display="Dynamic"
							ControlToValidate="txtPosition"></asp:RequiredFieldValidator></TD>
				</TR>
				<TR>
					<TD>Kiểu quảng cáo</TD>
					<TD>
						<asp:DropDownList id="dropType" runat="server">
							<asp:ListItem Value="default">Chiều dọc</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD>Kích thước</TD>
					<TD>
						<asp:textbox id="txtWidth" Width="40px" runat="server">0</asp:textbox>&nbsp;x
						<asp:textbox id="txtHeight" Width="40px" runat="server">0</asp:textbox>&nbsp;(pixel)</TD>
				</TR>
				<TR>
					<TD>Đoạn HTML giữa<BR>
						các quảng cáo</TD>
					<TD>
						<asp:TextBox id="txtSeparateCode" Width="250px" runat="server" Rows="4" TextMode="MultiLine"></asp:TextBox></TD>
				</TR>
			</TABLE>
			<br>
			<TABLE cellSpacing="0" cellPadding="3" width="100%" height="40" border="0" class="ActionBox">
				<TR>
					<TD align="center">
						<asp:Button id="cmdUpdate" Width="80px" runat="server" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:Button>
						<asp:Button id="cmdAddNew" Width="80px" runat="server" Text="Thêm mới" OnClick="cmdAddNew_Click"></asp:Button>
						<asp:Button id="cmdEmpty" Width="80px" runat="server" Text="Hủy" CausesValidation="False" OnClick="cmdEmpty_Click"></asp:Button></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
</div>