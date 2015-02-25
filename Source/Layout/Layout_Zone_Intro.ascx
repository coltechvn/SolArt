<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_Intro.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_Intro" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<%@ Register src="../Project/IntroSolInZone.ascx" tagname="IntroSolInZone" tagprefix="uc2" %>
<%@ Register src="../UserControls/SubCategory_Full.ascx" tagname="SubCategory_Full" tagprefix="uc3" %>

<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
<uc2:IntroSolInZone ID="IntroSolInZone1" runat="server" />
<uc3:SubCategory_Full ID="SubCategory_Full1" runat="server" />
</div>