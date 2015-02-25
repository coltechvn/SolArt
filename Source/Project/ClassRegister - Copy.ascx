<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassRegister.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.ClassRegister" %>
<div id="lophoc" style="border-bottom: 1px dashed #666666; padding-bottom: 20px; margin-bottom: 20px">
<h2 class="zone_title" style="text-transform:  none">Các lớp tuyển sinh</h2>
<asp:datagrid id="dtgClass" runat="server" AutoGenerateColumns="False" 
    CssClass="dg" onitemdatabound="dtgClass_ItemDataBound">
		<HeaderStyle CssClass="dgheader"></HeaderStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="Distribution_ContentID" HeaderText="ID"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Chọn">
                <itemtemplate>
                    <asp:CheckBox runat="server" runat="server" ID="chkCover"/>
				</itemtemplate>
                <headerstyle width="40px" horizontalalign="Center" CssClass="dgheaderitem"></headerstyle>
                <itemstyle horizontalalign="Center" CssClass="dgheaderitem"></itemstyle>
            </asp:TemplateColumn>
			<asp:BoundColumn DataField="Content_Name" HeaderText="Lớp">
				<HeaderStyle CssClass="dgheaderitem"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem"></ItemStyle>
			</asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Môn học">
				<HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="90px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" CssClass="dgheaderitem"></ItemStyle>
				<ItemTemplate>
					<asp:Literal runat="server" ID="litMonhoc"></asp:Literal>
				</ItemTemplate>
			</asp:TemplateColumn>
            <asp:BoundColumn DataField="Khoahoc_DoTuoi" HeaderText="Độ tuổi">
				<HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="80px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
			</asp:BoundColumn>
            <asp:BoundColumn DataField="Khoahoc_GioHoc" HeaderText="Giờ học">
				<HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="80px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
			</asp:BoundColumn>
            <asp:BoundColumn DataField="Khoahoc_KhaiGiang" HeaderText="Khai giảng">
				<HeaderStyle CssClass="dgheaderitem" HorizontalAlign="Center" Width="80px"></HeaderStyle>
                <ItemStyle CssClass="dgheaderitem" HorizontalAlign="Center"></ItemStyle>
			</asp:BoundColumn>
		</Columns>
	</asp:datagrid>
</div>
<h2 class="zone_title" style="text-transform:  none">Đăng ký học</h2>
<div runat="server" id="notice"></div>
<asp:Panel runat="server" ID="pnform">
    <div class="title-left" style="margin-top: 20px; border-bottom: none;">
        <table style="width: 500px;">
            <tr>
                <td style="width: 140px;">Họ tên học sinh: *</td>
                <td><asp:TextBox runat="server" ID="txtHocsinhName" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Tên phụ huynh: *</td>
                <td><asp:TextBox runat="server" ID="txtPhuHuynh" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox runat="server" ID="txtEmail" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Số điện thoại: *</td>
                <td><asp:TextBox runat="server" ID="txtPhone" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Địa chỉ: *</td>
                <td><asp:TextBox runat="server" ID="txtAddress" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày sinh của học sinh:</td>
                <td><asp:TextBox runat="server" ID="txtBirthday" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Học tại:</td>
                <td><asp:DropDownList runat="server" ID="dropCoso" /></td>
            </tr>
            <tr>
                <td>Ghi chú</td>
                <td><asp:TextBox runat="server" ID="txtContent" 
                        Style="margin: 5px 0 10px 0; width: 250px;" TextMode="MultiLine" Height="50px" 
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
