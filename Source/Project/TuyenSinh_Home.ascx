<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuyenSinh_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.TuyenSinh_Home" %>
<div class="banner-conten" style="margin-bottom: 16px;">
    <img src="img/tuyen-sinh.png" style=" margin: 20px 0 0 30px;" />
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" onitemdatabound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul style="height: 220px; padding-left: 15px">
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:HyperLink runat="server" ID="lnkOther" CssClass="button" style="background:#F00">Các lớp khác</asp:HyperLink>

    <asp:HyperLink runat="server" ID="lnkRegister"  style="float:right; margin: -20px 10px 0 0;"><img src="img/dang-ky-ngay.png" /></asp:HyperLink>
</div>