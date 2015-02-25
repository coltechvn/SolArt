<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Subcategory_2level_Center.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Subcategory_2level_Center" %>
<div id="cat_khoahoc" class="clearfix">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
    <HeaderTemplate>
    <ul class="clearfix">
    </HeaderTemplate>
    <ItemTemplate>
        <li class="clearfix">
            <asp:Image runat="server" ID="imgAvatar" />
            <div class="right">
                <h2><asp:Literal runat="server" ID="litZone">litZone</asp:Literal></h2>
                <asp:Repeater runat="server" ID="rptSub2" EnableViewState="false" OnItemDataBound="rptSub2_ItemDataBound">
                <HeaderTemplate>
                <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li><asp:HyperLink ID="lnkSub2" runat="server">Zone</asp:HyperLink></li>
                    </ItemTemplate>
                    <FooterTemplate>
                </ul>
                </FooterTemplate>
                </asp:Repeater>
                <p><asp:Literal runat="server" ID="litDescription">litDes</asp:Literal></p>
            </div>
        </li>
        </ItemTemplate>
        <FooterTemplate>
    </ul>
    </FooterTemplate>
    </asp:Repeater>
    <div class="download">
        <img src="img/download-thong-tin.png" style="float: left;" />
        <asp:HyperLink runat="server" ID="lnkDownload">Download thông tin chung các khoá học</asp:HyperLink>
    </div>
</div>