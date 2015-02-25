<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.News_Home" %>
<div class="col-3" style="background:url(img/tin-tuc-1.png) no-repeat center; margin-left: 23px;">
    <div class="news-conten">
        <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
            <ItemTemplate>
                <ul>
                    <li class="news-left">
                        <p class="date">
                            <asp:Literal runat="server" ID="litDay"></asp:Literal></p>
                        <p class="month">
                            Tháng
                            <asp:Literal runat="server" ID="litMonth"></asp:Literal></p>
                    </li>
                    <li class="news-right">
                        <asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink>
                    </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:HyperLink runat="server" ID="lnkOther" CssClass="button" Style="background: #06F">Xem thêm</asp:HyperLink>
    <div class="clear">
    </div>
</div>
