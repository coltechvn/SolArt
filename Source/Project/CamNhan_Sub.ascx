<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CamNhan_Sub.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.CamNhan_Sub" %>
<div id="camnhan_right" style="background: url('img/camnhan_sub_bg.jpg') no-repeat left top; display: block; width: 227px; height: 280px; margin: 0 0 30px 25px; clear: both; padding: 63px 0 0 17px;">
    <h2 style="text-transform: uppercase;height: 40px;"><asp:HyperLink runat="server" ID="lnkName" style="color: #fff;"></asp:HyperLink></h2>
    <div style="margin: 0 17px 10px 0; height: 170px; color: #fff;">
        <asp:Repeater runat="server" ID="rptData" 
            onitemdatabound="rptData_ItemDataBound">
            <ItemTemplate>
                <asp:Literal runat="server" ID="litContent">ssss</asp:Literal>
            </ItemTemplate>
        </asp:Repeater>
    </div>
<asp:HyperLink runat="server" ID="lnkMore" style="background-color: #138ad2; padding: 6px 10px; text-decoration: underline;">Chi tiết</asp:HyperLink>
</div>