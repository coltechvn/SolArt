<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Subcategory_Full_2level.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.Subcategory_Full_2level" %>
<div class="col-left" style="padding-top: 0;">
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
</div>