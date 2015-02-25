<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_Main.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Nav_Main" %>
<div id="main_nav" class="clearfix">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul class="clearfix">
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:HyperLink ID="lnkZone" runat="server"></asp:HyperLink></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
