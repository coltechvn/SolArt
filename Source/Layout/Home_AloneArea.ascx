<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home_AloneArea.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Home_AloneArea" %>
    <%@ Register src="../UserControls/News_Home.ascx" tagname="News_Home" tagprefix="uc1" %>
<%@ Register src="../Project/CamNhan_Home.ascx" tagname="CamNhan_Home" tagprefix="uc2" %>
<%@ Register src="../UserControls/Gallery_Home.ascx" tagname="Gallery_Home" tagprefix="uc3" %>
<%@ Register src="../UserControls/Video_Home.ascx" tagname="Video_Home" tagprefix="uc4" %>
    <div class="warpper">
    	<uc1:News_Home ID="News_Home1" runat="server" />
  	    <uc3:Gallery_Home ID="Gallery_Home1" runat="server" />
  	    <uc4:Video_Home ID="Video_Home1" runat="server" />
    	
        <div class="clear"></div>
    	
        <uc2:CamNhan_Home ID="CamNhan_Home1" runat="server" />
        
        <div class="clear"></div>
    </div>
