<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Banner_Home" %>
<div id="slider-wrapper">
	<div id="slider" class="nivoSlider">
        <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litAdv">adv</asp:Literal>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>