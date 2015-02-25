<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="iDKCMS.BackEnd.Common.Header" %>
<%@ Register TagPrefix="componentart" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register src="LanguageChoice.ascx" tagname="LanguageChoice" tagprefix="uc1" %>
<div id="headertop">
    <div class="menutop">
        <div class="language">
            <uc1:LanguageChoice ID="LanguageChoice1" runat="server" />
        </div>
        <div class="menuitem">
<asp:HyperLink Runat="server" ID="lnkOrder">[đăng ký học]</asp:HyperLink><asp:Image Runat="server" ID="imgOrder" ImageUrl="/acp/img/new2.gif"></asp:Image><asp:HyperLink Runat="server" ID="lnkMail">[hộp thư]</asp:HyperLink><asp:Image Runat="server" ID="imgMail" ImageUrl="/acp/img/new2.gif"></asp:Image><asp:HyperLink Runat="server" ID="lnkError">[danh sách lỗi]</asp:HyperLink><asp:Image Runat="server" ID="imgError" ImageUrl="/acp/img/new2.gif"></asp:Image>[<a href="#d">cài đặt</a>][<a
                href="#d">thực thi</a>][<a href="/">hệ thống</a>]</div>
    </div>
    <div class="welcome">
        Welcome back, <span><a href="?cmd=mainuserprofile" class="name">
            <asp:Label runat="server" ID="lblFullName"></asp:Label></a></span>! [<asp:LinkButton
                runat="server" ID="lnkSignout" CausesValidation="False" OnClick="lnkSignout_Click">đăng xuất</asp:LinkButton>]</div>
</div>
<div id="tabbarbg">
    <componentart:Menu ID="mnuCommands" CssClass="TopMenuGroup" DefaultGroupCssClass="MenuGroup"
        DefaultItemLookId="DefaultItemLook" DefaultGroupItemSpacing="0" ExpandDelay="100"
        EnableViewState="false" ClientScriptLocation="/Scripts/componentart_webui_client/"
        runat="server">
        <ItemLooks>
            <componentart:ItemLook LookId="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover"
                LabelPaddingLeft="20" LabelPaddingRight="0" LabelPaddingTop="0" LabelPaddingBottom="2" />
            <componentart:ItemLook LookId="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover"
                LabelPaddingLeft="10" LabelPaddingRight="10" LabelPaddingTop="4" LabelPaddingBottom="4" />
        </ItemLooks>
    </componentart:Menu>
</div>
