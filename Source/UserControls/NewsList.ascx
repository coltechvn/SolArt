<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.NewsList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" onitemdatabound="rptData_ItemDataBound">
<ItemTemplate>
<div class="title-left">
    <asp:Image runat="server" ID="imgAvatar" CssClass="img-event" />
    <div class="event-conten">
        <p><asp:Literal runat="server" ID="litDatetime"></asp:Literal></p>
        <h2><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
        <p><asp:Literal runat="server" ID="litTeaser"></asp:Literal></p>
    </div>
    <div class="clear"></div>
</div>
</ItemTemplate>
</asp:Repeater>

<div class="conten-right">
    <cc1:CollectionPager ID="CollectionPager1" ResultsLocation="None" BackNextButtonStyle="."
            BackNextDisplay="HyperLinks" UseSlider="True" ShowPageNumbers="True" ShowLabel="False"
            PageNumbersSeparator="&nbsp;&nbsp;&nbsp;" HideOnSinglePage="True" FirstText="First"
            MaxPages="100" BackText="&nbsp;<<" LastText="Last" NextText=">>" ResultsFormat="{0}-{1} (in {2})"
            PageSize="10" runat="server" LabelText="Trang" ShowFirstLast="False" BackNextLinkSeparator="&nbsp;&nbsp;&nbsp;">
        </cc1:CollectionPager>
</div>
<div class="clear"></div>