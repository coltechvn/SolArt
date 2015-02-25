<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_List.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.Video_List" %>
<h2 class="zone_title">
    <asp:HyperLink runat="server" ID="lnkZone"></asp:HyperLink>
    >
    <asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
    <HeaderTemplate>
        <ul class="videolist clearfix">
    </HeaderTemplate>
    <ItemTemplate>
        <li runat="server" id="liAvatar" style="margin: 20px 0;text-align: center;width: 100%;">
            <div class="video_block">
                <asp:Literal runat="server" ID="litPlayer">player</asp:Literal>
            </div>
            <div class="video_des" style="margin: 10px 0 0 20px; width: 560px;">
                <asp:Literal runat="server" ID="litDescription">des</asp:Literal>
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<div class="clear">
</div>
