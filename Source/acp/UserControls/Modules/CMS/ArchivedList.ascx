<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArchivedList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.ArchivedList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<TABLE class="Area" id="Table1" cellSpacing="0" cellPadding="3" width="760" align="center">
	<TR>
		<TD Width="12%">Chuyên mục</TD>
		<TD><asp:dropdownlist id="dropZones" runat="server" AutoPostBack="True" Width="480px" OnSelectedIndexChanged="dropZones_SelectedIndexChanged" CssClass="solidnormal"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD colSpan="2">
		<div id="datagrid">
		<cc1:datagrid id="dtgWaitingDeployList" runat="server" Width="100%" CellPadding="2" AutoGenerateColumns="False"
				PageSize="15" AllowPaging="True" OnItemCommand="dtgWaitingDeployList_ItemCommand" OnItemDataBound="dtgWaitingDeployList_ItemDataBound">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Content_ID" HeaderText="ID">
						<HeaderStyle Width="5%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="T&#234;n b&#224;i">
						<HeaderStyle></HeaderStyle>
						<ItemTemplate>
							<asp:HyperLink id="lnkHeadline" runat="server" CssClass="link"></asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Thao t&#225;c">
						<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" CssClass="FlatButton" Text="Gửi lên" CommandName="deploywaiting"></asp:Button>
							<asp:Button id="Button2" runat="server" CssClass="FlatButton" Text="Sửa" CommandName="edit"></asp:Button>
							<asp:Button id="cmdDel" runat="server" CssClass="FlatButton" Text="Xóa" CommandName="delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
			</cc1:datagrid>
			</div>
			</TD>
	</TR>
	<tr>
		<td colspan="2">
			<asp:label id="lblStatusUpdate" runat="server"></asp:label></td>
	</tr>
</TABLE>
</div>