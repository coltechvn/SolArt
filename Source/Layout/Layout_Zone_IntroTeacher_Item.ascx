<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_IntroTeacher_Item.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_IntroTeacher_Item" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<%@ Register src="../Project/IntroSolInZone.ascx" tagname="IntroSolInZone" tagprefix="uc2" %>
<%@ Register src="../UserControls/NewsDetail.ascx" tagname="NewsDetail" tagprefix="uc3" %>
<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
<uc2:IntroSolInZone ID="IntroSolInZone1" runat="server" />
<asp:Panel runat="server" ID="pnZoneName">
    <div style="border-bottom: 1px dashed #666666; margin-bottom: 20px; padding: 5px 0 15px;">
    <h1><asp:Literal runat="server" ID="litZoneName"></asp:Literal></h1>
    </div>
</asp:Panel>
<uc3:NewsDetail ID="NewsDetail1" runat="server" />
</div>

