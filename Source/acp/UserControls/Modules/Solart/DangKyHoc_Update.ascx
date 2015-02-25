<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DangKyHoc_Update.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Solart.DangKyHoc_Update" %>

<script language="JavaScript" src="/JScripts/vietuni.js" type="text/javascript"></script>

<script language="JavaScript">    setTypingMode(1);</script>

<style type="text/css">
    .submit_form { width: 100%;}   
    .submit_form td { border-bottom: solid 1px #ccc; padding: 4px;}   
    .submit_form .label {font-weight: bold; width: 300px;}
    .submit_form3 .label {font-weight: bold;}
    .submit_form .sub, .submit_form3 .sub {font-weight: normal; font-size: 10px; font-style: italic;}
    .submit_form3 .info, .submit_form .info {font-weight: normal; padding: 10px 0 20px 10px; border-bottom: solid 1px #ccc}
    .submit_form .info_right {font-weight: normal; padding: 0 0 0 10px;}
    .submit_form .info_noborder {border: none;}
   
</style>
<div align="center">
    <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label>
    <table cellspacing="1" cellpadding="2" width="99%" border="0" class="Area">
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="vertical-align:  top;">
                <table>
                    <tr>
                        <td style="vertical-align:  top;">
                            <table cellspacing="1" cellpadding="2" width="100%" border="0">
                    <tr>
                        <td width="100">
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Ngày đăng ký:</strong></td>
                        <td>
                            <asp:Label ID="lblDateTime" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Học sinh:</strong></td>
                        <td><asp:HyperLink runat="server" ID="lnkFullname"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Phụ huynh:</strong></td>
                        <td><asp:Label ID="lblPhuHuynh" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 23px">
                            <strong>Email:</strong></td>
                        <td style="height: 23px">
                            <asp:Label ID="lblEmail" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Điện thoại:</strong></td>
                        <td>
                            <asp:Label ID="lblPhone" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Địa chỉ:</strong></td>
                        <td>
                            <asp:Label ID="lblAddress" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Ngày sinh:</strong></td>
                        <td>
                            <asp:Label ID="lblBirthday" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Thông tin thêm:</strong></td>
                        <td>
                            <asp:Label ID="lblContent" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Đang học?</strong></td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkIsLearning"  /></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="butUpdate" runat="server" Text="Cập nhật" OnClick="butUpdate_Click">
                            </asp:Button>
                            <asp:Button ID="butDelete" runat="server" Text="Xóa" OnClick="butDelete_Click"></asp:Button>
                            <asp:Button ID="butCancel" runat="server" Text="Quay trở lại" OnClick="butCancel_Click">
                            </asp:Button></td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    
                </table>
                        </td>
                        <td style="vertical-align:  top; padding-left: 30px;">
                        <p>
                            <strong>Lớp học đăng ký:</strong>
                        </p>
                            <asp:DataList ID="dtlProduct" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                    BorderWidth="0" RepeatColumns="1" RepeatDirection="Horizontal" 
                                OnItemDataBound="dtlProduct_ItemDataBound" 
                                onitemcommand="dtlProduct_ItemCommand">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="table47">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="table48">
                                        <tr>
                                            <td valign="top">
                                                <p style="padding: 0; margin: 0; font-weight: bold;">
                                                    <asp:Button ID="butRowDelete" runat="server" Text="Xóa" CommandName="delete"></asp:Button>&nbsp;<asp:HyperLink runat="server" ID="lnkName">lnkKhoahocName</asp:HyperLink></p>
                                                <p style="padding: 10px 0 0 0; margin: 0; line-height: 18px;">
                                                    <b>Lớp học:</b> <asp:Literal runat="server" ID="litLophoc"></asp:Literal><br />
                                                    <b>Ngày khai giảng:</b> <asp:Literal runat="server" ID="litKhaiGiang"></asp:Literal><br />
                                                    <b>Nội dung học:</b> <asp:Literal runat="server" ID="litNoiDungHoc"></asp:Literal><br />
                                                    <b>Độ tuổi:</b> <asp:Literal runat="server" ID="litDoTuoi"></asp:Literal><br />
                                                    <b>Giờ học:</b> <asp:Literal runat="server" ID="litGioHoc"></asp:Literal><br />
                                                    <b>Cơ sở:</b> <asp:Repeater runat="server" ID="rptCoso">
                                                        <ItemTemplate><asp:Literal runat="server" ID="litCoso"></asp:Literal></ItemTemplate>
                                                        <SeparatorTemplate>, </SeparatorTemplate>
                                                    </asp:Repeater><br />
                                                </p>
                                                <p>
                                                    
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
