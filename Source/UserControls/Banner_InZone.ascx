<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner_InZone.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Banner_InZone" %>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
    <ItemTemplate>
        <asp:Literal runat="server" ID="litAdv">adv</asp:Literal>
    </ItemTemplate>
</asp:Repeater>