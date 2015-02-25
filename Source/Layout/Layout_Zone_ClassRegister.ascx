<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout_Zone_ClassRegister.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Layout_Zone_ClassRegister" %>
<%@ Register src="../Project/ClassRegister.ascx" tagname="ClassRegister" tagprefix="uc1" %>
<%@ Register src="../UserControls/Banner_InZone.ascx" tagname="Banner_InZone" tagprefix="uc1" %>
<uc1:Banner_InZone ID="Banner_InZone1" runat="server" />
<div class="col-left">
<uc1:ClassRegister ID="ClassRegister1" runat="server" />
</div>