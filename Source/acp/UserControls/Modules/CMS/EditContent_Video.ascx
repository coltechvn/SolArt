<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent_Video.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.EditContent_Video" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="AWS.FilePicker" Assembly="FilePickerControl" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
    
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
                    <td>Loại</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="dropType" runat="server" CssClass="solidnormal">
                            <asp:ListItem Value="youtube">YouTuBe</asp:ListItem>
                            <asp:ListItem Value="flash">Flash (flv)</asp:ListItem>
                            <asp:ListItem Value="video">Video (avi, mpg ...)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
					<td><strong>File Video</strong>&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;Hiển thị: <asp:CheckBox runat="server" ID="chkVisible" Checked="true"/>&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;ID: <asp:TextBox runat="server" ID="txtID" Width="20px" ReadOnly="true"></asp:TextBox></td>
				</tr>
				<tr>
					<td><cc1:FilePicker  CssClass="solidnormal" id="txtFile" Width="300px" runat="server" fpUploadDir="/Upload/Video/" fpPopupURL="../FilePicker/FilePicker.aspx"></cc1:FilePicker>
                    </td>
				</tr>
                <tr>
                    <td>Youtube</td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtYoutube" CssClass="solidheight" runat="server" TextMode="MultiLine" Height="50px" Width="504px"></asp:TextBox></td>
                </tr>
				<tr>
					<td><b>Tiêu đề</b></td>
				</tr>
				<tr>
					<td>
						<asp:TextBox id="txtName" runat="server" Width="504px" Height="30px" TextMode="MultiLine" CssClass="solidnormal"></asp:TextBox>
						</td>
				</tr>
				<tr>
					<td><b>Mô tả</b></td>
				</tr>
				<tr>
					<td>
						<asp:TextBox id="txtTeaser" runat="server" Width="504px" Height="70px" TextMode="MultiLine" CssClass="solidnormal"></asp:TextBox></td>
				</tr>
                <tr>
                    <td>
                        
                        <asp:button id="cmdUpdate" runat="server" Width="110px" Text="Cập nhật sửa đổi" 
                            CausesValidation="False" onclick="cmdUpdate_Click"></asp:button>
                        <asp:button id="btnAddNew" runat="server" Width="110px" Text="Thêm video mới" 
                            CausesValidation="False" onclick="btnAddNew_Click"></asp:button>
                            <asp:Label id="lblStatusUpdate2" runat="server"></asp:Label>
                            

                    </td>
                </tr>
			</table>
            
		</td>
	</tr>
    <tr>
        <td>
            <div id="datagrid">
            <cc1:NewDataGrid ID="dtgData" runat="server" Width="100%" AutoGenerateColumns="False"
                        CellPadding="2" PageSize="20" AllowPaging="True" OrderBy="ASC"
                        AllowSorting="True" BorderWidth="0px" 
                    onitemcommand="dtgData_ItemCommand" onitemdatabound="dtgData_ItemDataBound">
                        <AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
                        <ItemStyle CssClass="LightRow"></ItemStyle>
                        <HeaderStyle Font-Bold="True" CssClass="HeaderRow"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="Video_ID" ReadOnly="True"></asp:BoundColumn>
                            <asp:BoundColumn ReadOnly="True" HeaderText="Stt">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Video" SortExpression="Video_Name">
                                <itemtemplate>
									<asp:HyperLink runat="server" ID="lnkVideo" CssClass="link"></asp:HyperLink>
</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Video_Type" ReadOnly="True" HeaderText="Loại" SortExpression="Video_Type">
                                <headerstyle width="50px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Url">
                                <itemtemplate>
									<asp:TextBox id="txtUrl" Runat="server" TextMode="MultiLine"></asp:TextBox>
												
</itemtemplate>
                                <headerstyle width="100px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="Ng&#224;y tạo" SortExpression="Video_CreateDate">
                                <itemtemplate>
													<asp:Label id="lblDatetime" Runat="server"></asp:Label>
												
</itemtemplate>
                                <headerstyle width="80px" horizontalalign="Center"></headerstyle>
                                <itemstyle width="80px" horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Video_View" ReadOnly="True" HeaderText="Xem" SortExpression="Video_View">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="SX" SortExpression="Video_Priority">
                                <itemtemplate>
													<asp:TextBox id="txtPriority" Runat="server" CssClass="solid"></asp:TextBox>
												
</itemtemplate>
                                <headerstyle width="30px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="V" SortExpression="Video_Visible">
                                <itemtemplate>
													<asp:CheckBox id="chkVisible" Runat="server" Checked='<%#((bool)DataBinder.Eval(Container.DataItem,"Video_Visible"))%>'>
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
        </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label></td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>