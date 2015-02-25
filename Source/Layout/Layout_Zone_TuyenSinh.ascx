<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_TuyenSinh.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_TuyenSinh" %>
<%@ Register src="../UserControls/SpecialInZone.ascx" tagname="SpecialInZone" tagprefix="uc1" %>
<%@ Register src="../UserControls/SubCategory.ascx" tagname="SubCategory" tagprefix="uc2" %>
<uc1:SpecialInZone ID="SpecialInZone1" runat="server" />

<div class="col-left" style="padding-bottom:  0;">
    <div class="title-left">
        <img src="img/icon-news.jpg" style="float: left;" />
        <div class="title">
            <h1 style="text-transform: uppercase;">
            <asp:HyperLink runat="server" ID="lnkZone"></asp:HyperLink>
                </h1>
        </div>
        <div class="clear">
        </div>
        <uc2:SubCategory ID="SubCategory1" runat="server" />
    </div>
</div>
<div class="col-left">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</div>
