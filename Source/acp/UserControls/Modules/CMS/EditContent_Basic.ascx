<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent_Basic.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.EditContent_Basic"  %>
<%@ Register src="../../Controls/Editor.ascx" tagname="Editor" tagprefix="uc1" %>
<table cellSpacing="0" cellPadding="3" width="100%" align="center">
	<tr>
		<td><asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <ContentTemplate>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="List"></asp:ValidationSummary>
			<asp:Label id="lblStatusUpdate" runat="server"></asp:Label>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
	</tr>
	<tr>
		<td>
            <table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                <tr>
                    <td style="vertical-align: top;">
                        <table cellSpacing="0" cellPadding="4" width="100%" align="center" border="0">
                            <tr runat="server" id="trRank">
								<td>
                                <fieldset>
                                    <legend><b>Cấp độ</b></legend>
									<asp:RadioButtonList id="rdoContentRanks" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
										<asp:ListItem Value="0" Selected="True">B&#236;nh thường</asp:ListItem>
										<asp:ListItem Value="1">Ti&#234;u điểm</asp:ListItem>
										<asp:ListItem Value="2">Nổi bật</asp:ListItem>
									</asp:RadioButtonList>
                                </fieldset>
                                </td>
							</tr>
                            <tr>
								<td>
                                <table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                                    <tr>
                                        <td style="width: 50%">
                                            <fieldset>
                                                <legend><b>Kiểu giao diện</b></legend>
									            <asp:DropDownList runat="server" ID="dropLayout">
                                                    <asp:ListItem Value="zone">Theo mục cha</asp:ListItem>
                                                    <asp:ListItem Value="Layout_Zone_News">Dạng tin tức</asp:ListItem>
                                                    <asp:ListItem Value="Layout_Zone_Product">Dạng sản phẩm</asp:ListItem>
                                                    <asp:ListItem Value="Layout_Zone_Video">Dạng video</asp:ListItem>
                                                    <asp:ListItem Value="Layout_Zone_Document">Dạng văn bản</asp:ListItem>
                                                    <asp:ListItem Value="Layout_Zone_Gallery">Dạng album ảnh</asp:ListItem>
                                                </asp:DropDownList>
                                            </fieldset>
                                        </td>
                                        <td style="text-align:  right">
                                            Hiển thị <asp:CheckBox runat="server" ID="chkVisible" Checked="true" /><br />
                                            Loại bỏ khỏi công cụ tìm kiếm<asp:CheckBox runat="server" ID="chkExcludeFromSearch" />
                                        </td>
                                    </tr>
                                </table>
                                            
                                </td>
							</tr>
                            <tr>
								<td>
                                <fieldset>
                                    <legend><b>Phân loại</b></legend>
									<asp:CheckBox runat="server" ID="chkIsPhoto" Text="Album ảnh" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox runat="server" ID="chkIsDownload" Text="Tài liệu download" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox runat="server" ID="chkIsVideo" Text="Video" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox runat="server" ID="chkIsProduct" Text="Sản phẩm" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox runat="server" ID="chkIsPoll" Text="Bầu chọn" />
                                </fieldset>
                                </td>
							</tr>
							<tr>
								<td><b>Mục lưu tin</b></td>
							</tr>
							<tr>
								<td>
									<asp:DropDownList id="dropZones" runat="server" Width="504px" CssClass="solidnormal"></asp:DropDownList>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="dropZones" ErrorMessage="Chưa chọn mục lưu tin"
										Display="Dynamic">(*)</asp:RequiredFieldValidator></td>
								
							</tr>
							<tr>
								<td><b>Tiêu đề</b></td>
							</tr>
							<tr>
								<td>
									<asp:TextBox id="txtName" runat="server" Width="504px" Height="30px" TextMode="MultiLine" CssClass="solidnormal"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Chưa nhập tiêu đề"
										Display="Dynamic">(*)</asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td><b>Tóm tắt</b><span runat="server" id="spanDisableHeader">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(tắt tóm tắt<asp:CheckBox runat="server" ID="chkDisableTeaser"/>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(tắt ảnh đại diện<asp:CheckBox runat="server" ID="chkDisableAvatar"/>)</span></td>
							</tr>
							<tr>
								<td>
									<asp:TextBox id="txtTeaser" runat="server" Width="504px" Height="70px" TextMode="MultiLine" CssClass="solidnormal"></asp:TextBox></td>
							</tr>
                            <tr>
				                <td>
				                Tác giả: 
				                </td>
				            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox id="txtAuthor" runat="server" Width="504px" CssClass="solidnormal" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
				                <td>
				                Friendly Url 
				                </td>
				            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox id="txtFriendlyUrl" runat="server" Width="504px" CssClass="solidnormal" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
						</table>
                    </td>
                    <td style="width: 210px; vertical-align: top;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <table cellSpacing="0" cellPadding="4" width="100%" align="center" border="0">
                            <tr>
                                <td>Đồng thời đăng vào mục</td>
                            </tr>
                            <tr>
                                <td><asp:listbox id="lstZones" runat="server" Width="220px" Height="270px"
							SelectionMode="Multiple" CssClass="solidnormal"></asp:listbox></td>
                            </tr>
                            <tr>
                                <td><asp:Calendar ID="Calendar1" runat="server" 
                                        onselectionchanged="Calendar1_SelectionChanged">
                        </asp:Calendar></td>
                            </tr>
                            <tr>
                                <td style="text-align:  right;">
                        Ngày sự kiện: <asp:TextBox ID="txtEventDate" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="text-align:  right;">
                        Ngày tạo: <asp:TextBox ID="txtCreateDate" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
		</td>
	</tr>
	<tr>
		<td><b>Nội dung chính</b></td>
	</tr>
	<tr>
		<td>
            <uc1:Editor ID="Editor1" runat="server" /></td>
	</tr>
	<tr>
		<td>
            <asp:UpdatePanel runat="server" ID="UpdatePanelStatus2">
            <ContentTemplate>
			<p align="center">
				<asp:button id="cmdUpdate" accessKey="s" runat="server" Width="110px" 
                    Text="Cập nhật" ToolTip="Alt + S"
					CausesValidation="False" onclick="cmdUpdate_Click"></asp:button><asp:Label id="lblStatusUpdate2" runat="server"></asp:Label></p>
                    </ContentTemplate>
                    </asp:UpdatePanel>
		</td>
	</tr>
</table>