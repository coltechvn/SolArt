<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Subcategory_Full_Giaovien.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.Subcategory_Full_Giaovien" %>
<asp:Panel runat="server" ID="pnZoneName">
    <div style="border-bottom: 1px dashed #666666; margin-bottom: 20px; padding: 5px 0 15px;">
    <h1><asp:Literal runat="server" ID="litZoneName"></asp:Literal></h1>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pntSub">
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
<ItemTemplate>
<div class="title-left" style="border-bottom:  none;">
    <img src="img/list-red.png" style="margin: 10px 10px 0 0; float:left;" />
    <h2><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
    <div class="clear"></div>
    <asp:Image runat="server" ID="imgAvatar" CssClass="img-bo-mon"/>
    <span style="line-height: 22px;"><b><asp:Literal runat="server" ID="litDescription"></asp:Literal></b></span>
	<div class="clear"></div>
</div>
</ItemTemplate>
</asp:Repeater>
</asp:Panel>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>