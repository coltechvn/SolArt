<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubCategory.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.SubCategory" %>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink runat="server" ID="lnkZone"></asp:HyperLink></li>
        <li>
            <img src="img/border.png" /></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<div class="clear">
</div>
