<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_Gallery.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_Gallery" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>

<%@ Register src="../UserControls/Album_List.ascx" tagname="Album_List" tagprefix="uc2" %>

<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
    <uc2:Album_List ID="Album_List1" runat="server" />
</div>
