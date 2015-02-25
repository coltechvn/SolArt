<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Cart" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<h1 class="zone_title">
    Giỏ hàng</h1>
<div id="cart_block_center" class="carttable">
    <asp:Repeater runat="server" ID="rptCart" OnItemCommand="rptCart_ItemCommand" OnItemDataBound="rptCart_ItemDataBound">
    <HeaderTemplate>
    <table>
        <tr>
            <td class="header cell1">
                Deal
            </td>
            <td class="header cell2">
                Số lượng
            </td>
            <td class="header cell3">
                Đơn giá
            </td>
            <td class="header cell4">
                Thành tiền
            </td>
            <td class="header cell5"></td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
            <td class="item item1">
                <asp:Literal runat="server" ID="litName"></asp:Literal>
            </td>
            <td class="item item2">
                <p class="txtwrap">
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtquantity"></asp:TextBox>
                </p>
            </td>
            <td class="item item3">
                <asp:Literal runat="server" ID="litRetailPrice"></asp:Literal>
            </td>
            <td class="item item4">
                <asp:Literal runat="server" ID="litPrice"></asp:Literal>
            </td>
            <td class="item item5">
                <asp:LinkButton runat="server" ID="lnkUpdate" Text="[Cập nhật]" CommandName="update"
                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'></asp:LinkButton>&nbsp;-&nbsp;<asp:LinkButton runat="server" ID="lnkRemove" Text="[Xóa]" CommandName="delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'></asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
    </table>
    </FooterTemplate>
    </asp:Repeater>
    <p class="totalprice">
        Tổng số tiền: <asp:Literal runat="server" ID="litTotalPrice"></asp:Literal></p>
    <p class="return"><asp:HyperLink runat="server" ID="lnkReturn" CssClass="button"><span class="inner">Quay trở lại</span></asp:HyperLink></p>
</div>
<cc1:NewDataGrid ID="dtgProduct" runat="server" AutoGenerateColumns="False" Visible="False">
    <Columns>
        <asp:BoundColumn DataField="id" ReadOnly="True"></asp:BoundColumn>
        <asp:BoundColumn DataField="Quantity" ReadOnly="True"></asp:BoundColumn>
        <asp:BoundColumn DataField="Price" ReadOnly="True"></asp:BoundColumn>
    </Columns>
</cc1:NewDataGrid>
<div id="notice" style="text-align: center; color: red" runat="server">Bạn cần đăng nhập để có thể mua deal này</div>
<asp:Panel runat="server" ID="pnPayment">
<div id="customer_info" class="formstyle customerinfotable clearfix">
    <h4 class="zone_title">
        Thông tin giao hàng</h4>
    <table>
        <tr>
            <td class="label">
                Tên
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFullName" CssClass="txtinput"></asp:TextBox>
                &nbsp;*</td>
        </tr>
        <tr>
            <td class="label">
                Điện thoại
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTel" CssClass="txtinput"></asp:TextBox>
                &nbsp;*</td>
        </tr>
        <tr>
            <td class="label">
                Địa chỉ
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress" CssClass="txtinput"></asp:TextBox>
                &nbsp;*</td>
        </tr>
        <tr>
            <td class="label">
                Quận / Huyện
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDistrict" CssClass="txtinput"></asp:TextBox>
                &nbsp;*</td>
        </tr>
        <tr>
            <td class="label">
                Tỉnh / Thành phố
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCity" CssClass="txtinput"></asp:TextBox>
                &nbsp;*</td>
        </tr>
        <tr>
            <td class="label" style="vertical-align: top;">
                Thông tin thêm
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNote" CssClass="tainput" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="agreement">
        <asp:CheckBox runat="server" ID="chkAgree"/>Tôi đã đọc và đồng ý với các <a href="#d">
            Điều khoản</a> và <a href="#d">Quy định</a> của My-deal.vn</div>
    <div class="button-wrap">
        <asp:Button runat="server" ID="butSubmit" Text="Đồng ý mua" CssClass="button" 
            onclick="butSubmit_Click"/>
    </div>
</div>
<div id="payment_method">
    <h4 class="zone_title">
        Hình thức thanh toán</h4>
    <ul>
        <li class="clearfix">
            <div class="img_block">
                <img alt="" src="img/icon_truck.jpg" /></div>
            <div class="content_block">
                <div class="payment_name">
                    Mydeal đến thu tiền tận nơi <span class="free">(Miễn phí giao phiếu)</span></div>
                <div class="payment_description">
                    Trong thời gian từ 2-7 ngày làm việc, nhân viên Mydeal sẽ giao phiếu đến tận nơi
                    cho Quý khách và thu tiền</div>
            </div>
        </li>
    </ul>
</div>
</asp:Panel>