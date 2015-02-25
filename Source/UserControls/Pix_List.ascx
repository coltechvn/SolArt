<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pix_List.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Pix_List" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
    <h2 class="zone_title">
        <asp:HyperLink runat="server" ID="lnkZone"></asp:HyperLink> > <asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" 
        onitemdatabound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul class="pixlist clearfix gallery">
        </HeaderTemplate>
        <ItemTemplate>
            <li runat="server" id="liAvatar">
                <div class="img_block">
                <asp:HyperLink runat="server" ID="lnkAvatar">
                    <asp:Image runat="server" ID="imgAvatar" />
                </asp:HyperLink>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <div class="conten-right">
        <cc1:CollectionPager ID="CollectionPager1" ResultsLocation="None" BackNextButtonStyle="."
            BackNextDisplay="HyperLinks" UseSlider="True" ShowPageNumbers="True" ShowLabel="False"
            PageNumbersSeparator="&nbsp;&nbsp;&nbsp;" HideOnSinglePage="True" FirstText="First"
            MaxPages="100" BackText="&nbsp;<<" LastText="Last" NextText=">>" ResultsFormat="{0}-{1} (in {2})"
            PageSize="30" runat="server" LabelText="Trang" ShowFirstLast="False" BackNextLinkSeparator="&nbsp;&nbsp;&nbsp;">
        </cc1:CollectionPager>
    </div>
    <div class="clear">
    </div>
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animationSpeed: 'slow', theme: 'light_square', slideshow: 2000, autoplay_slideshow: false });
            $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animationSpeed: 'fast', slideshow: 10000 });
        });
</script>
