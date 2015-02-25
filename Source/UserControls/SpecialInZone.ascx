<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialInZone.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.SpecialInZone" %>
<div class="col-left" style="background: url(img/bg-big-event.png) repeat;">
    <asp:Repeater runat="server" ID="rptData" 
        onitemdatabound="rptData_ItemDataBound">
        <ItemTemplate>
            <asp:HyperLink runat="server" ID="lnkAvatar" Style="float: left">
                <asp:Image runat="server" ID="imgAvatar" Style="padding: 2px; border: #999 2px solid;" />
            </asp:HyperLink>
            <div style="float: left; margin: 0 15px; width: 295px; float: left">
                <img src="img/su-kien-noi-bat.jpg" />
                <div class="clear">
                </div>
                <h2>
                    <asp:HyperLink runat="server" ID="lnkName" Style="color: #C00; font-weight: bold;
                        font-size: 13px;"></asp:HyperLink>
                </h2>
                <p>
                    <asp:Literal runat="server" ID="litTeaser"></asp:Literal>
                </p>
            </div>
            <div class="clear">
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
