<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gallery_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Gallery_Home" %>
<div class="col-3" style="background:  url(img/gallery-3.png) no-repeat center;">
  	<div class="news-conten">
        <asp:Image runat="server" ID="imgAvatar" CssClass="gal-img"/>
        <asp:HyperLink runat="server" ID="lnkName" style="padding: 0 20px;"></asp:HyperLink>
    </div>
    <asp:HyperLink runat="server" ID="lnkOther" CssClass="button" style="background:#F00">Xem thêm</asp:HyperLink>
    <div class="clear"></div>
</div>
