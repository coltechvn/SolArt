<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent_Documents.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.EditContent_Documents" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>

<table cellSpacing="0" cellPadding="3" width="100%" align="center">
	<tr>
		<td>
        
			<asp:Label id="lblStatusUpdate" runat="server"></asp:Label>
        
            </td>
	</tr>
	<tr>
		<td>
        
           <table cellSpacing="0" cellPadding="4" width="100%" align="center" border="0">
                <tr>
					<td><asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                            <strong>File</strong>&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;Hiển thị: <asp:CheckBox runat="server" ID="chkVisible" Checked="true"/>&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;ID: <asp:TextBox runat="server" ID="txtID" Width="20px" ReadOnly="true"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                            </td>
				</tr>
				<tr>
					<td><asp:FileUpload ID="txtFile" runat="server" CssClass="solidnormal" />
                    </td>
				</tr>
				<tr>
					<td><b>Tiêu đề</b></td>
				</tr>
				<tr>
					<td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            
						<asp:TextBox id="txtName" runat="server" Width="504px" Height="30px" TextMode="MultiLine" CssClass="solidnormal"></asp:TextBox>
                        </ContentTemplate>
                        </asp:UpdatePanel>
						</td>
				</tr>
				<tr>
					<td><b>Mô tả</b></td>
				</tr>
				<tr>
					<td>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
						<asp:TextBox id="txtTeaser" runat="server" Width="504px" Height="70px" TextMode="MultiLine" CssClass="solidnormal"></asp:TextBox>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
				</tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                        <asp:button id="cmdUpdate" runat="server" Width="110px" Text="Cập nhật sửa đổi" CausesValidation="False" onclick="cmdUpdate_Click"></asp:button>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:button id="btnAddNew" runat="server" Width="110px" Text="Thêm file mới" CausesValidation="False" onclick="btnAddNew_Click"></asp:button>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                            <asp:Label id="lblStatusUpdate2" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
			</table>
            
		</td>
	</tr>
    <tr>
        <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
            <div id="datagrid">
            
                
            <cc1:NewDataGrid ID="dtgPix" runat="server" Width="100%" AutoGenerateColumns="False"
                        CellPadding="2" PageSize="20" AllowPaging="True" OrderBy="ASC"
                        AllowSorting="True" BorderWidth="0px" OnItemCommand="dtgPix_ItemCommand" OnItemDataBound="dtgPix_ItemDataBound">
                        <AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
                        <ItemStyle CssClass="LightRow"></ItemStyle>
                        <HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="Download_ID" ReadOnly="True"></asp:BoundColumn>
                            <asp:BoundColumn ReadOnly="True" HeaderText="Stt">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Tên" SortExpression="Download_Name">
                                <itemtemplate>
													<asp:HyperLink runat="server" ID="lnkName" CssClass="link"></asp:HyperLink>
</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="File">
                                <itemtemplate>
													<asp:TextBox id="txtUrl" Runat="server"></asp:TextBox>
												
</itemtemplate>
                                <headerstyle width="100px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="Ng&#224;y tạo" SortExpression="Download_CreateDate">
                                <itemtemplate>
													<asp:Label id="lblDatetime" Runat="server"></asp:Label>
												
</itemtemplate>
                                <headerstyle width="80px" horizontalalign="Center"></headerstyle>
                                <itemstyle width="80px" horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Download_View" ReadOnly="True" HeaderText="Xem" SortExpression="Download_View">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Download_FileSize" ReadOnly="True" HeaderText="Size" SortExpression="Download_FileSize">
                                <headerstyle width="50px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Download_Extension" ReadOnly="True" HeaderText="Ext" SortExpression="Download_Extension">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="SX" SortExpression="Download_Priority">
                                <itemtemplate>
													<asp:TextBox id="txtPriority" Runat="server" CssClass="solid"></asp:TextBox>
												
</itemtemplate>
                                <headerstyle width="30px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="V" SortExpression="Download_Visible">
                                <itemtemplate>
													<asp:CheckBox id="chkVisible" Runat="server" Checked='<%#((bool)DataBinder.Eval(Container.DataItem,"Download_Visible"))%>'>
													</asp:CheckBox>
												
</itemtemplate>
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="U" SortExpression="User_ID">
                                <itemtemplate>
													<a href='?cmd=mainusermanager&amp;act=edit&id=<%#DataBinder.Eval(Container.DataItem,"User_ID")%>' target=_blank class="link">
														<asp:Image id="imgUser" Runat="server" ImageUrl="/acp/img/icon_user2.gif"></asp:Image></a>
												
</itemtemplate>
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thao t&#225;c">
                                <itemtemplate>
													<asp:ImageButton id="btn_updaterow" runat="server" ImageUrl="/acp/img/icon_enter.gif" CommandName="updaterow" CausesValidation="false"></asp:ImageButton>
                                                    <asp:ImageButton id="btn_edit" runat="server" ImageUrl="/acp/img/icon_edit.gif" CommandName="editrow" CausesValidation="false"></asp:ImageButton>
													<asp:ImageButton id="btn_delete" runat="server" ImageUrl="/acp/img/icon_delete.gif" CommandName="delete" CausesValidation="false"></asp:ImageButton>
												
</itemtemplate>
                                <headerstyle width="70px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages"></PagerStyle>
                    </cc1:NewDataGrid>
                    </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label></td>
</tr>
</table>
