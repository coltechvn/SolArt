<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CamNhan_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.CamNhan_Home" %>
<div class="warpper" style="border-top: 1px solid #CBCBCB; margin-top: 30px; width: 908px;">
    
    <div class="cam-nghi-ve-sol">
        <asp:HyperLink runat="server" ID="lnkZone"><img src="img/cam-nhan.png" style="margin: 12px 12px 0 0; float: left;" /></asp:HyperLink>
        <div class="clear"></div>
        <asp:Repeater runat="server" ID="rptData" EnableViewState="false" onitemdatabound="rptData_ItemDataBound">
            <ItemTemplate>
                <ul>
                    <li class="ava" style="overflow: hidden;"><asp:Image runat="server" ID="imgAvatar" /></li>
                    <li class="comment"><asp:Literal runat="server" ID="litTeaser"></asp:Literal></li>
                </ul>
                <div class="clear"></div>
                <p><b><asp:Literal runat="server" ID="litName"></asp:Literal></b><br /><asp:Literal runat="server" ID="litDatetime"></asp:Literal></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
</div>