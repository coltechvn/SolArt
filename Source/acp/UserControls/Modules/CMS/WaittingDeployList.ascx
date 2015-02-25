<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WaittingDeployList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.WaittingDeployList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<TABLE class="Area" id="Table1" cellSpacing="0" cellPadding="3" width="760" align="center">
	<TR>
		<TD>Chuyên mục</TD>
		<TD>
			<asp:dropdownlist id="dropZones" Width="480px" runat="server" AutoPostBack="True" CssClass="solidnormal"></asp:dropdownlist>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="(*)" Display="Dynamic"
				ControlToValidate="dropZones"></asp:RequiredFieldValidator></TD>
	</TR>
	<TR>
		<TD colSpan="2">
		<div id="datagrid">
			<cc1:datagrid id="dtgWaitingDeployList" AutoGenerateColumns="False" CellPadding="2" Width="100%"
				runat="server" PageSize="15" AllowPaging="True" OnItemCommand="dtgWaitingDeployList_ItemCommand" OnItemDataBound="dtgWaitingDeployList_ItemDataBound">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Content_ID" HeaderText="ID">
						<HeaderStyle Width="5%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="T&#234;n b&#224;i">
						<HeaderStyle Width="80%"></HeaderStyle>
						<ItemTemplate>
							<asp:HyperLink id="lnkHeadline" runat="server" CssClass="link"></asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Thao t&#225;c">
						<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Button ID="cmdDeploy" Runat="server" CommandName="deploy" CssClass="FlatButton" Text="Đăng"></asp:Button>
							<asp:Button ID="cmdReturn" Runat="server" CommandName="return" CssClass="FlatButton" Text="Trả lại"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
			</cc1:datagrid>
			</div>
		</TD>
	</TR>
	<TR>
		<TD colSpan="2">
			<asp:Label id="lblStatusUpdate" runat="server"></asp:Label></TD>
	</TR>
</TABLE>
<br>
<TABLE class="SidePanel" cellSpacing="0" cellPadding="3" width="760" align="center">
	<tr>
		<td>Lý do trả lại</td>
	</tr>
	<tr>
		<td>
			<asp:TextBox id="txtComment" runat="server" Width="100%" TextMode="MultiLine" Rows="5" ToolTip="Lý do trả lại"></asp:TextBox>
		</td>
	</tr>
</TABLE>
</div>