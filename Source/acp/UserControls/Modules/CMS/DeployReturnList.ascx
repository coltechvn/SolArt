<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeployReturnList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.DeployReturnList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<TABLE class="Area" id="Table1" cellSpacing="0" cellPadding="3" width="760" align="center">
	<TR>
		<TD Width="12%">Chuyên mục</TD>
		<TD>
			<asp:dropdownlist id="dropZones" Width="480px" runat="server" AutoPostBack="True" CssClass="solidnormal"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD colSpan="2">
		<div id="datagrid">
			<cc1:datagrid id="dtgReturnList" AutoGenerateColumns="False" CellPadding="2" Width="100%" runat="server"
				PageSize="15" AllowPaging="True" OnItemCommand="dtgReturnList_ItemCommand" OnItemDataBound="dtgReturnList_ItemDataBound">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Content_ID" HeaderText="ID">
						<HeaderStyle Width="5%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="T&#234;n b&#224;i">
						<HeaderStyle Width="70%"></HeaderStyle>
						<ItemTemplate>
							<asp:HyperLink id="lnkHeadline" runat="server" CssClass="link"></asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Thao t&#225;c">
						<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:button id="cmdDeployWaiting" runat="server" CommandName="deploywaiting" CssClass="FlatButton"
								Text="Gửi lên"></asp:button>
							<asp:button id="cmdEdit" runat="server" CommandName="edit" CssClass="FlatButton" Text="Sửa"></asp:button>
							<asp:button id="cmdDel" runat="server" CommandName="delete" CssClass="FlatButton" Text="Xóa"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
			</cc1:datagrid>
			</div>
			</TD>
	<tr>
		<td colspan="2">
			<asp:Label id="lblStatusUpdate" runat="server"></asp:Label></td>
	</tr>
</TABLE>
</div>