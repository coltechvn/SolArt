<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_Footer.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.Nav_Footer" %>

<div class="ft-left" style="margin-top: 20px;">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:HyperLink ID="lnkZone" runat="server">Zone</asp:HyperLink></li>
        </ItemTemplate>
        <SeparatorTemplate><li>|</li></SeparatorTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
