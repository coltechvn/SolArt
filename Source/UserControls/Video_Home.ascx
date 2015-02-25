<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Video_Home" %>
<div class="col-3" style="background: url(img/video2.png) no-repeat center;">
    <div class="news-conten">
        <asp:Repeater runat="server" EnableViewState="false" ID="rptSpecial" 
            onitemdatabound="rptSpecial_ItemDataBound">
            <ItemTemplate>
            <div class="video">
                <asp:Literal Runat="server" ID="litPlayer">sss</asp:Literal>
            </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater runat="server" EnableViewState="false" ID="rptData" 
            onitemdatabound="rptData_ItemDataBound">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li style="float:  none">
                    <asp:HyperLink runat="server" ID="lnkName" style="padding: 5px 15px"></asp:HyperLink>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <asp:HyperLink runat="server" ID="lnkOther" CssClass="button" style="background:#900">Xem thêm</asp:HyperLink>
    <div class="clear"></div>
</div>