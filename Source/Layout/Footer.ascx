<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Footer" %>
<%@ Register src="../UserControls/Nav_Footer.ascx" tagname="Nav_Footer" tagprefix="uc1" %>
<%@ Register src="../UserControls/Banner_Footer.ascx" tagname="Banner_Footer" tagprefix="uc2" %>
<%@ Register src="../UserControls/Copyright.ascx" tagname="Copyright" tagprefix="uc3" %>
<%@ Register src="../UserControls/Intro_Block.ascx" tagname="Intro_Block" tagprefix="uc4" %>
<div id="footer">
    <div class="warpper">
        <uc4:Intro_Block ID="Intro_Block1" runat="server" />
        <uc2:Banner_Footer ID="Banner_Footer1" runat="server" />
        <div class="clear"></div>
        <uc1:Nav_Footer ID="Nav_Footer1" runat="server" />
        <uc3:Copyright ID="Copyright1" runat="server" />
    </div>
</div>