<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Album_List.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Album_List" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>

<h2 class="zone_title"><asp:HyperLink runat="server" ID="lnkZone"></asp:HyperLink></h2>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" onitemdatabound="rptData_ItemDataBound">
<ItemTemplate>
<div class="title-left">
    <asp:HyperLink runat="server" ID="lnkAvatar">
    <asp:Image runat="server" ID="imgAvatar" CssClass="gallery-avatar" /></asp:HyperLink>
    <div class="event-conten" style="width: 390px; margin-top: 10px;">
        <h2><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
    </div>
    <div class="clear"></div>
</div>
</ItemTemplate>
</asp:Repeater>

<div class="conten-right" style="padding-left: 10px">
    <cc1:CollectionPager ID="CollectionPager1" ResultsLocation="None" BackNextButtonStyle="."
            BackNextDisplay="HyperLinks" UseSlider="True" ShowPageNumbers="True" ShowLabel="False"
            PageNumbersSeparator="&nbsp;&nbsp;&nbsp;" HideOnSinglePage="True" FirstText="First"
            MaxPages="100" BackText="&nbsp;<<" LastText="Last" NextText=">>" ResultsFormat="{0}-{1} (in {2})"
            PageSize="10" runat="server" LabelText="Trang" ShowFirstLast="False" BackNextLinkSeparator="&nbsp;&nbsp;&nbsp;">
        </cc1:CollectionPager>
</div>
<div class="clear"></div>
