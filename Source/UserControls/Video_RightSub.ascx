<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Video_RightSub.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Video_RightSub" %>
<div id="youtube_right" style="margin: 0 0 16px 20px; clear: both;">
    <h2 style="background: url(img/icon_youtube.jpg) no-repeat left top; height: 29px; line-height: 29px; padding: 0 0 0 39px; font-weight: bold; font-size: 12px; color: #bf1e2e; margin: 0 0 8px 0;"><asp:HyperLink runat="server" ID="lnkName" style="color: #bf1e2e;"></asp:HyperLink></h2>
    <asp:Repeater runat="server" EnableViewState="false" ID="rptSpecial" onitemdatabound="rptSpecial_ItemDataBound">
        <ItemTemplate>
        <div class="videosub">
            <asp:Literal Runat="server" ID="litPlayer">sss</asp:Literal>
        </div>
        </ItemTemplate>
    </asp:Repeater>
</div> 