<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubCategory_Full.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.SubCategory_Full" %>
<asp:Panel runat="server" ID="pntSub">
<div class="title-left" id="subcategory_full">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
    <HeaderTemplate>
        <ul class="clearfix">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <img src="img/star.jpg" style="float: left; margin: 10px 0 0;" />
            <div style="line-height: 40px;">
                <h2>
                    <i><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></i></h2>
            </div>
            <p>
                <asp:Image runat="server" ID="imgAvatar" CssClass="col-2-img"/>
                <asp:Literal runat="server" ID="litDescription"></asp:Literal>
                <div class="clear">
                </div>
            </p>
            <div class="clear">
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
</div>
</asp:Panel>
<asp:Panel runat="server" ID="pnZoneName" Visible="false">
    <div style="border-bottom: 1px dashed #666666; margin-bottom: 20px; padding: 5px 0 15px;">
    <h1><asp:Literal runat="server" ID="litZoneName"></asp:Literal></h1>
    </div>
</asp:Panel>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>