<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_Main_Image.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Nav_Main_Image" %>
<div class="navigation">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <HeaderTemplate>
            <ul style="float: left;">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="lnkZone" runat="server">
                    <asp:Image runat="server" ID="imgAvatar" />
                </asp:HyperLink>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
</div>
