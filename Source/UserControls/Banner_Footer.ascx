<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner_Footer.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Banner_Footer" %>
<div class="ft-right">
    <img src="img/network.png" style="float: right" />
    <div class="clear">
    </div>
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul style="float: right;">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:Literal runat="server" ID="litAdv">adv</asp:Literal></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <br />
</div>
