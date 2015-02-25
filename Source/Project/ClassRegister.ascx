<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassRegister.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.ClassRegister" %>
<div id="lophoc" style="border-bottom: 1px dashed #666666; padding-bottom: 20px; margin-bottom: 20px">
<h2 class="zone_title" style="text-transform:  none; margin-bottom: 16px;">Bước 1: Lựa chọn các lớp đang tuyển sinh</h2>
<div id="lophoc_filter">
    <table>
        <tr>
            <td><b>Thu gọn</b></td>
            <td>&nbsp;</td>
            <td><asp:DropDownList runat="server" ID="dropFilterDoTuoi">
                <asp:ListItem Value="">Chọn độ tuổi</asp:ListItem>
                <asp:ListItem Value="1">1 tuổi</asp:ListItem>
                <asp:ListItem Value="2">2 tuổi</asp:ListItem>
                <asp:ListItem Value="3">3 tuổi</asp:ListItem>
                <asp:ListItem Value="4">4 tuổi</asp:ListItem>
                <asp:ListItem Value="5">5 tuổi</asp:ListItem>
                <asp:ListItem Value="6">6 tuổi</asp:ListItem>
                <asp:ListItem Value="7">7 tuổi</asp:ListItem>
                <asp:ListItem Value="8">8 tuổi</asp:ListItem>
                <asp:ListItem Value="9">9 tuổi</asp:ListItem>
                <asp:ListItem Value="10">10 tuổi</asp:ListItem>
                <asp:ListItem Value="11">11 tuổi</asp:ListItem>
                <asp:ListItem Value="12">12 tuổi</asp:ListItem>
                <asp:ListItem Value="13">13 tuổi</asp:ListItem>
                <asp:ListItem Value="14">14 tuổi</asp:ListItem>
                <asp:ListItem Value="15">15 tuổi</asp:ListItem>
                <asp:ListItem Value="16">16 tuổi</asp:ListItem>
                <asp:ListItem Value="17">17 tuổi trở lên</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td><asp:DropDownList runat="server" ID="dropFilterMonHoc"></asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td><asp:DropDownList runat="server" ID="dropFilterCoso" /></td>
            <td>&nbsp;</td>
            <td style="width: 150px;"><asp:DropDownList runat="server" ID="dropFilterLopHoc" Width="100%" /></td>
            <td>&nbsp;</td>
            <td><asp:Button runat="server" ID="butSearch" Text="Tìm kiếm" 
                    onclick="butSearch_Click" /></td>
        </tr>
    </table>
</div>
    <asp:datagrid id="dtgClass" runat="server" AutoGenerateColumns="False" 
    CssClass="dg" onitemdatabound="dtgClass_ItemDataBound" Width="900px">
		<HeaderStyle CssClass="dgheader"></HeaderStyle>
        <ItemStyle CssClass="dglight"></ItemStyle>
        <AlternatingItemStyle CssClass="dgdark"></AlternatingItemStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="Content_ID" HeaderText="ID"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Chọn">
                <itemtemplate>
                    <asp:CheckBox runat="server" runat="server" ID="chkSelect"/>
				</itemtemplate>
                <headerstyle width="30px" horizontalalign="Center" CssClass="dgheaderitem"></headerstyle>
                <itemstyle horizontalalign="Center" CssClass="dgheaderitem"></itemstyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Ngày khai giảng">
                <itemtemplate>
                    <asp:Literal runat="server" ID="litKhaiGiang"></asp:Literal>
				</itemtemplate>
                <HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="140px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Tên lớp">
                <itemtemplate>
                    <asp:Literal runat="server" ID="litLophoc"></asp:Literal>
				</itemtemplate>
                <HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="100px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Độ tuổi học sinh">
                <itemtemplate>
                    <asp:Literal runat="server" ID="litDotuoi"></asp:Literal>
				</itemtemplate>
                <HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="110px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Nội dung học">
                <itemtemplate>
                    <asp:Literal runat="server" ID="litNoiDungHoc"></asp:Literal>
				</itemtemplate>
                <HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Giờ học hàng tuần">
                <itemtemplate>
                    <asp:Literal runat="server" ID="litGioHoc"></asp:Literal>
				</itemtemplate>
                <HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Cơ sở">
                <itemtemplate>
                    <asp:Repeater runat="server" ID="rptCoso" OnItemDataBound="rptCoso_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal runat="server" ID="litCoso"></asp:Literal>
                        </ItemTemplate>
                        <SeparatorTemplate><br /></SeparatorTemplate>
                    </asp:Repeater>
				</itemtemplate>
                <HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="60px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateColumn>
		</Columns>
	</asp:datagrid>
    <div runat="server" id="divNotice" style="text-align: center; font-weight: bold; color: red; margin: 20px;"><asp:Literal runat="server" ID="litNotice"></asp:Literal></div>
</div>
<h2 class="zone_title" style="text-transform:  none">Bước 2: Điền thông tin theo mẫu dưới đây</h2>
<div runat="server" id="notice"></div>
<asp:Panel runat="server" ID="pnform">
    <div class="title-left" style="margin-top: 20px; border-bottom: none;">
        <table style="width: 500px;">
            <tr>
                <td style="width: 140px;">Họ tên học sinh: *</td>
                <td><asp:TextBox runat="server" ID="txtHocsinhName" Style="margin: 5px 0 10px 0; width: 300px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Tên phụ huynh: *</td>
                <td><asp:TextBox runat="server" ID="txtPhuHuynh" Style="margin: 5px 0 10px 0; width: 300px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox runat="server" ID="txtEmail" Style="margin: 5px 0 10px 0; width: 300px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Số điện thoại: *</td>
                <td><asp:TextBox runat="server" ID="txtPhone" Style="margin: 5px 0 10px 0; width: 300px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Địa chỉ: *</td>
                <td><asp:TextBox runat="server" ID="txtAddress" Style="margin: 5px 0 10px 0; width: 300px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày sinh của học sinh:</td>
                <td>
                    <table cellSpacing="0" cellPadding="0" border="0">
	                    <tr>
		                    <td>Ngày
			                    <asp:DropDownList id="dropDay" runat="server" Width="50"></asp:DropDownList></td>
		                    <td>&nbsp;Tháng
			                    <asp:DropDownList id="dropMonth" runat="server" Width="50"></asp:DropDownList></td>
		                    <td>&nbsp;Năm
			                    <asp:DropDownList id="dropYear" runat="server" Width="60"></asp:DropDownList></td>
	                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>Thôn tin thêm</td>
                <td><asp:TextBox runat="server" ID="txtContent" 
                        Style="margin: 5px 0 10px 0; width: 300px;" TextMode="MultiLine" Height="50px" 
                        CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:  left;"><asp:Button runat="server" Text="Đăng ký học" 
                        ID="butSend" Style="background: #C00; color: #FFF;
                padding: 5px 10px; font-size: 11px;" onclick="butSend_Click" /></td>
            </tr>
        </table>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div class="clear">
</div>
