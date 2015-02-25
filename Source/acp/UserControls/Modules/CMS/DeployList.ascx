<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeployList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.DeployList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align=center>
<TABLE class="Area" id="Table1" cellSpacing="0" cellPadding="3" width="95%" align="center">
	<TR>
		<TD Width="12%">Chuyên mục</TD>
		<TD><asp:dropdownlist id="dropZones" AutoPostBack="True" runat="server" Width="480px" CssClass="solidnormal"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD colSpan="2">
		<div id="datagrid">
		<cc1:datagrid id="dtgDeployList" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="2"
				PageSize="15" AllowPaging="True" AllowCustomPaging="True" OnItemCommand="dtgDeployList_ItemCommand" OnItemDataBound="dtgDeployList_ItemDataBound">
				<AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
				<ItemStyle CssClass="LightRow"></ItemStyle>
				<HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Distribution_ID" HeaderText="ID">
						<HeaderStyle Width="5%"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Distribution_ContentID"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="T&#234;n b&#224;i">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemTemplate>
							<asp:HyperLink id="lnkHeadline" runat="server" CssClass="link"></asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Distribution_View" HeaderText="Xem">
						<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<HeaderTemplate>
							<asp:LinkButton id="cmdUpdateRank" runat="server" Width="90px" CommandName="updaterank" CssClass="FlatButton">Cập nhật</asp:LinkButton>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:DropDownList id="dropContentRank" runat="server" Width="90px" CssClass="solidnormal">
								<asp:ListItem Value="0">B&#236;nh thường</asp:ListItem>
								<asp:ListItem Value="1">Ti&#234;u điểm</asp:ListItem>
								<asp:ListItem Value="2">Nổi bật</asp:ListItem>
							</asp:DropDownList>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="10%"></HeaderStyle>
						<HeaderTemplate>
							<asp:LinkButton id="cmdUpdateIndex" runat="server" Width="60" CommandName="updatepriority" CssClass="FlatButton">Thứ tự</asp:LinkButton>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:DropDownList id="dropIndex" runat="server" Width="60" CssClass="solidnormal"></asp:DropDownList>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Thao t&#225;c">
						<HeaderStyle HorizontalAlign="Center" Width="28%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:button id="cmdRemove" runat="server" CssClass="FlatButton" CommandName="remover" Text="Gỡ khỏi mục"></asp:button>
							<asp:button id="cmdEdit" runat="server" CssClass="FlatButton" CommandName="edit" Text="Sửa"></asp:button>
							<asp:button id="cmdDel" runat="server" CssClass="FlatButton" CommandName="delete" Text="Xóa hoàn toàn"></asp:button>
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