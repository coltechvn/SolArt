<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_Video_Item.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_Video_Item" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<%@ Register src="../UserControls/Video_List.ascx" tagname="Video_List" tagprefix="uc2" %>
<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
    <uc2:Video_List ID="Video_List1" runat="server" />
</div>
