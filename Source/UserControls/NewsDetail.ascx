<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.NewsDetail" %>
<div class="title-left">
    <h1><asp:Literal runat="server" ID="litName"></asp:Literal></h1>
    <br />
    <asp:Panel runat="server" ID="pnTeaser" style="margin-bottom: 16px;" CssClass="gallery" Visible="false">
        <asp:HyperLink runat="server" ID="lnkAvatar">
            <asp:Image runat="server" ID="imgAvatar" style="float: left; margin: 0 10px 10px 0;"/>
        </asp:HyperLink>
        <b><asp:Literal runat="server" ID="litTeaser"></asp:Literal></b>
    </asp:Panel>
    
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
