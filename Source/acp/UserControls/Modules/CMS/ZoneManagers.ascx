<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZoneManagers.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.ZoneManagers" %>
<%@ Register TagPrefix="cc1" Namespace="AWS.FilePicker" Assembly="FilePickerControl" %>
<div align=center>
<table  border="0" cellpadding="0" cellspacing="0" width="760">
    <tr>
        <td align="left" valign="top" style="height: 470px; width: 250px;">
            <asp:ListBox ID="lstZones" Width="100%" runat="server" Height="450px" AutoPostBack="True" CausesValidation="True" CssClass="solidnormal" OnSelectedIndexChanged="lstZones_SelectedIndexChanged"></asp:ListBox>
        </td>
        <td width="10px">
        </td>
        <td  align="left"  valign="top">
           <table  border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left"  valign="top">
                        <div id="datagrid">
                        <asp:GridView Width="100%" ID="dtgZones" runat="server" AutoGenerateColumns="False" OnRowDataBound="dtgZones_RowDataBound">
                            <HeaderStyle Font-Bold="true" CssClass="HeaderRow" />
                            <AlternatingRowStyle CssClass="DarkRow" />
                            <RowStyle CssClass="LightRow" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="lblHZone_Name" runat="server"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Zone_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lnkOrder" runat="server" Font-Overline=true Font-Underline=true OnClick="lnkOrder_Click"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlOrder" runat="server" Width="70px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Zone_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Zone_Priority") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px;"></td>
                </tr>
                <tr>
                    <td align="left"  valign="top">
                        <table  border="0" cellpadding="0" cellspacing="0" width="100%" class="Area">
                            <tr>
                                <td align="left" colspan="2" style="padding-bottom: 2px; padding-top: 2px">
                                <asp:Label ID="lblStatusUpdate" runat="server" ForeColor="#FF00FF"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%" align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Tên mục:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <asp:TextBox id="txtName" Width="265" runat="server" CssClass="solidnormal"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Mục cha:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <asp:DropDownList id="dropZones"  runat="server" CssClass="solidnormal"></asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Kiểu giao diện:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <asp:DropDownList id="dropLayout"  runat="server" CssClass="solidnormal">
                                        <asp:ListItem Value="Layout_Zone_News">Dạng bài viết, tin tức</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_Intro">Dạng Giới thiệu chung</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_IntroTeacher">Dạng Giới thiệu giáo viên</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_Video">Dạng video</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_Gallery">Dạng album ảnh</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_Khoahoc">Dạng khóa học</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_Mamnon">Dạng Mầm non SolKids</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_Contact">Dạng form Liên hệ</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_ClassRegister">Dạng Đăng ký học</asp:ListItem>
                                        <asp:ListItem Value="Layout_Zone_TuyenSinh">Dạng Tuyển sinh</asp:ListItem>
                                    </asp:DropDownList>
                                    <!--<asp:ListItem Value="Layout_Zone_Product">Dạng sản phẩm</asp:ListItem>-->
                                    <!--<asp:ListItem Value="Layout_Zone_Document">Dạng văn bản</asp:ListItem>-->
                                </td>

                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                Hiển thị tại:
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                <asp:CheckBox ID="chkMainNav" runat="server" Text="Menu chính"></asp:CheckBox><asp:CheckBox ID="chkLeftNav" runat="server" Text="Menu Trái"></asp:CheckBox>
                                <asp:CheckBox ID="chkTopNav" runat="server" Text="Trên cùng"></asp:CheckBox><asp:CheckBox ID="chkFooterNav" runat="server" Text="Chân trang" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px;">
                                Hiển thị mục con?
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px;">
                                <asp:DropDownList id="dropSubcategoryDisplay" runat="server" CssClass="solidnormal">
                                    <asp:ListItem Value="listing">Dạng danh sách rút gọn</asp:ListItem>
                                    <asp:ListItem Value="full">Dạng đầy đủ</asp:ListItem>   
                                    <asp:ListItem Value="none">Không hiện</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px;">
                                Hiển thị nội dung chính?
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px;">
                                <asp:DropDownList id="dropContentDisplay" runat="server" CssClass="solidnormal">
                                    <asp:ListItem Value="listing">Dạng danh sách</asp:ListItem>
                                    <asp:ListItem Value="one">Chỉ hiện nội dung 1 bài viết</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                Không hiện trên menu?
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                <asp:CheckBox ID="chkExcludeFromNav" runat="server"></asp:CheckBox>

                                &nbsp;|&nbsp; Không sử dụng: <asp:CheckBox ID="chkDisable" runat="server"></asp:CheckBox> &nbsp;|&nbsp; Hiển thị: <asp:CheckBox ID="chkVisible" runat="server" Checked="True"></asp:CheckBox>
                                </td>
                            </tr>

                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    Địa chỉ trỏ đến:
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:TextBox ID="txtRealUrl" runat="server" Width="266" CssClass="solidnormal"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Ảnh đại diện:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <cc1:FilePicker  CssClass="solidnormal" id="txtAvatar" Width="120px" runat="server" fpUploadDir="/Upload/CMS/Zone/" fpPopupURL="../FilePicker/FilePicker.aspx"></cc1:FilePicker>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    Friendly Url:
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:TextBox ID="txtFriendlyUrl" runat="server" Width="266" CssClass="solidnormal"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    Meta (mô tả):
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:TextBox ID="txtMetaDescription" runat="server" Width="266" CssClass="solidnormal" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    Meta (từ khóa):
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:TextBox ID="txtMetaKeywords" runat="server" Width="266" CssClass="solidnormal" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td colspan="2" align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:Button  Width="100px" ID="btnUpdate" runat="server" Text="Cập nhật sửa đổi" Enabled="False" OnClick="btnUpdate_Click" />&nbsp;
                                    <asp:Button Width="80px" ID="btnAdd" runat="server" Text="Thêm mới" 
                                        onclick="btnAdd_Click" />&nbsp;
                                    <asp:Button Width="80px" ID="btnDelete" runat="server" Text="Xóa" 
                                        Enabled="False" onclick="btnDelete_Click" />&nbsp;<input
                                        id="btnReset" style="width:80px;" type="reset" runat="server" value="" />
                                </td>
                               
                            </tr>
                        </table>
                    
                    </td>
                    
                </tr>
            </table>
            <asp:HiddenField ID="hddID" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="height: 20px;">Mô tả:</td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Height="50px" Width="100%"></asp:TextBox>
        </td>
    </tr>
    
</table>
</div>
&nbsp;
<script language="javascript" >

    function ConfirmDelete(mess) {
        return confirm(mess);
    }
</script>