<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuyenSinh_Detail.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.TuyenSinh_Detail" %>
<div class="title-left">
    <h1><asp:Literal runat="server" ID="litName"></asp:Literal></h1>
    <br />
    <asp:Panel runat="server" ID="pnTeaser" style="margin-bottom: 16px;" CssClass="gallery" Visible="false">
        <asp:HyperLink runat="server" ID="lnkAvatar">
            <asp:Image runat="server" ID="imgAvatar" style="float: left; margin: 0 10px 10px 0;"/>
        </asp:HyperLink>
        <b><asp:Literal runat="server" ID="litTeaser"></asp:Literal></b>
    </asp:Panel>
    <div>
        <p style="float: left; margin: 16px 0 0 0;"><b>Ngày khai giảng:</b> <asp:Literal runat="server" ID="litDatetime"></asp:Literal></p>
        <div class="download" style="margin: 10px 0 0 0; line-height: 30px;">
            <img src="img/dang-ky-hoc.png" style="float: left;" />
            <asp:HyperLink runat="server" ID="lnkRegister">Đăng ký học</asp:HyperLink>
        </div>
        </div>
    <div class="maincontent clear">
        <asp:Literal runat="server" ID="litContent"></asp:Literal>
    </div>
    <div class="clear">
    </div>
</div>
<script type="text/javascript" charset="utf-8">
    $(document).ready(function () {
        $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animationSpeed: 'slow', theme: 'light_square', slideshow: 2000, autoplay_slideshow: false });
        $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animationSpeed: 'fast', slideshow: 10000 });
    });
</script>
<div class="clear">
</div>
