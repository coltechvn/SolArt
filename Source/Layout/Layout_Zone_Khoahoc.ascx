<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_Khoahoc.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_Khoahoc" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<%@ Register src="../Project/KhoaHoc_List.ascx" tagname="KhoaHoc_List" tagprefix="uc2" %>
<%@ Register src="../Project/Subcategory_Full_2level.ascx" tagname="Subcategory_Full_2level" tagprefix="uc3" %>
<%@ Register src="../UserControls/Subcategory_2level_Center.ascx" tagname="Subcategory_2level_Center" tagprefix="uc4" %>
<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<h1 class="zone_title_main"><asp:HyperLink runat="server" ID="lnkZone"></asp:HyperLink></h1>
<uc4:Subcategory_2level_Center ID="Subcategory_2level_Center1" runat="server" />
<uc2:KhoaHoc_List ID="KhoaHoc_List1" runat="server" />
<uc3:Subcategory_Full_2level ID="Subcategory_Full_2level1" runat="server" />