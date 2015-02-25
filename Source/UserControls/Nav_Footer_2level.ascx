<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_Footer_2level.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Nav_Footer_2level" %>
<div id="footer_nav">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <h4>
                    <asp:Literal runat="server" ID="litZone">litZone</asp:Literal></h4>
                <asp:Repeater runat="server" ID="rptSub2" EnableViewState="false" OnItemDataBound="rptSub2_ItemDataBound">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="lnkSub2" runat="server">Zone</asp:HyperLink></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
