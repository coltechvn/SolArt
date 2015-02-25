<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiaoVienList.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.GiaoVienList" %>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" onitemdatabound="rptData_ItemDataBound">
<ItemTemplate>
<div class="title-left" style="margin-bottom: 15px;">
    <div class="clear">
    </div>
    <asp:Image runat="server" ID="imgAvatar" CssClass="teacher-img" />
    <h2><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
    <div>
        <asp:Literal runat="server" ID="litTeaser"></asp:Literal>
    </div>
    <asp:HyperLink runat="server" ID="lnkMore" style="float: right;" CssClass="red"></asp:HyperLink>
    <div class="clear">
    </div>
</div>
</ItemTemplate>
</asp:Repeater>