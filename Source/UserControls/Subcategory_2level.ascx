<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Subcategory_2level.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.Subcategory_2level" %>
<div class="col-right-conten clear">
    <img src="img/img-title.png" style="float: left; margin-top: 20px;" />
    <div class="title">
        <h1>
            <asp:HyperLink runat="server" ID="lnkZoneName" Style="color: #C00;">Khóa học Sol Art</asp:HyperLink>
        </h1>
    </div>
    <div class="clear">
    </div>
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <ItemTemplate>
            <div class="link">
                <b>
                    <asp:Literal runat="server" ID="litZone">litZone</asp:Literal></b>
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
                <div class="clear">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
</div>
