<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_IntroTeacher.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_IntroTeacher" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<%@ Register src="../Project/IntroSolInZone.ascx" tagname="IntroSolInZone" tagprefix="uc2" %>


<%@ Register src="../Project/Subcategory_Full_Giaovien.ascx" tagname="Subcategory_Full_Giaovien" tagprefix="uc3" %>


<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
<uc2:IntroSolInZone ID="IntroSolInZone1" runat="server" />
<uc3:Subcategory_Full_Giaovien ID="Subcategory_Full_Giaovien1" runat="server" />
</div>

