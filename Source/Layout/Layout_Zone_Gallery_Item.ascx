<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_Gallery_Item.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_Gallery_Item" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<%@ Register src="../UserControls/Pix_List.ascx" tagname="Pix_List" tagprefix="uc2" %>
<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
<uc2:Pix_List ID="Pix_List1" runat="server" />
</div>




