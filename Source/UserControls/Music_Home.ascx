<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Music_Home.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Music_Home" %>
<%@ Register Assembly="ASPNetAudio.NET4" Namespace="ASPNetAudio" TagPrefix="ASPNetAudio" %>
<div class="clear"></div>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="baicatsolart" style="margin: 0 0 30px 20px; background: url(img/icon_baica.jpg) no-repeat left top; height: 38px; line-height: 38px; display: block; padding-left: 124px;" class="clearfix">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <ASPNetAudio:Audio ID="Audio1" runat="server" Loop="True" AutoPlay="False"></ASPNetAudio:Audio>

        <input type="button" value="" onClick='ASPNetMedia.Audio("Audio1").PlayMedia ()' style="background: url('img/icon_play.png') no-repeat left top; display: block; width: 32px; height: 32px; border: none; cursor: pointer; float: left;" />
        <input type="button" value="" onClick='ASPNetMedia.Audio("Audio1").PauseMedia ()'  style="background: url('img/icon_pause.png') no-repeat left top; display: block; width: 32px; height: 32px; border: none; cursor: pointer; float: left;" />
        <input type="button" value="" onClick='ASPNetMedia.Audio("Audio1").StopMedia ()'  style="background: url('img/icon_stop.png') no-repeat left top; display: block; width: 32px; height: 32px; border: none; cursor: pointer; float: left;" />
    </ContentTemplate>                   
</asp:UpdatePanel>
</div>        

