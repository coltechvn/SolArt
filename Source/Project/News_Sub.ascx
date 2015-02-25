<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Sub.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.News_Sub" %>
<div class="col-right-conten clear" style="background: url(img/gray.png)repeat;">
    <img src="img/img-title.png" style="float:left; margin-top: 20px ;" />
    <div class="title"><h1><asp:HyperLink runat="server" ID="lnkZoneName"></asp:HyperLink></h1></div>
    <div class="clear"></div>
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
    <ItemTemplate>
    <div style="width: 235px; margin-bottom: 16px">
        <div><img src="img/img-small-news.jpg" class="small-img" />
        <h2 style="font-size:  12px;"><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2> 
            <div style="margin-left:  10px;"><asp:Literal runat="server" ID="litTeaser"></asp:Literal></div>
        </div>
        <div class="clear"></div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink runat="server" ID="lnkMore" CssClass="button" style=" background: #F00; margin: 0 0 10px 10px;;">Chi tiết</asp:HyperLink>
    <img src="img/gray-bottom.png" />
    <div class="clear"></div>
</div>
