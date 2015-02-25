<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderView.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Order.OrderView" %>

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
                        <td>
                            <table cellspacing="1" cellpadding="2" width="100%" border="0">
                    <tr>
                        <td width="100">
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>#ID:</strong></td>
                        <td>
                            <b>
                                <asp:Label ID="lblID" runat="server">Label</asp:Label></b></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Ngày tháng:</strong></td>
                        <td>
                            <asp:Label ID="lblDateTime" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Tổng tiền:</strong></td>
                        <td>
                            <b>
                                <asp:Label ID="lblPrice" runat="server" ForeColor="Red">Label</asp:Label></b></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Họ tên:</strong></td>
                        <td><asp:HyperLink runat="server" ID="lnkFullname"></asp:HyperLink></td>
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
                            <strong>Quận:</strong></td>
                        <td>
                            <asp:Label ID="lblDistrict" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Thành phố:</strong></td>
                        <td>
                            <asp:Label ID="lblCity" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Nội dung:</strong></td>
                        <td>
                            <asp:Label ID="lblContent" runat="server">Label</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Tình Trạng:</strong></td>
                        <td>
                            <asp:DropDownList runat="server" ID="dropStatus" CssClass="px">
                                                    <asp:ListItem Value="0">Chưa confirm</asp:ListItem>
                                                    <asp:ListItem Value="1">Đã confirm</asp:ListItem>
                                                    <asp:ListItem Value="2">Đã chuyển hàng</asp:ListItem>
                                                </asp:DropDownList></td>
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
                        <td style="vertical-align:  top;">
                        <p>
                            <strong>Sản phẩm:</strong> [<asp:Label runat="server" ID="lblQuantity"></asp:Label> loại sản phẩm]
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
                                            <td width="160" valign="top">
                                                <asp:Image runat="server" ID="imgAvatar" Width="150px"></asp:Image></td>
                                            <td valign="top">
                                                <p style="padding: 0; margin: 0; font-weight: bold;">
                                                    <asp:HyperLink runat="server" ID="lnkName">lnkProductName</asp:HyperLink></p>
                                                <p style="padding: 6px 0 0 0; margin: 0; font-size: 11px;">
                                                    <asp:Label runat="server" ID="lblConfig"></asp:Label></p>
                                                <p style="padding: 10px 0 0 0; margin: 0;">
                                                    Đơn giá:
                                                    <asp:Label runat="server" ID="lblProductPrice" ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;Số
                                                    lượng:
                                                    <asp:TextBox runat="server" ID="txtQuantity" CssClass="solidnormal" Width="20px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;Thành
                                                    tiền:
                                                    <asp:Label runat="server" ID="lblPriceSum" ForeColor="Red"></asp:Label></p>
                                                <p>
                                                    <asp:Button ID="butRowUpdate" runat="server" Text="Cập nhật" CommandName="updaterow"></asp:Button>
                                                    <asp:Button ID="butRowDelete" runat="server" Text="Xóa" CommandName="delete"></asp:Button>
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
