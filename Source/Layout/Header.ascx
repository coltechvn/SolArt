<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Header" %>
<%@ Register src="../UserControls/Facebook_Like.ascx" tagname="Facebook_Like" tagprefix="uc1" %>
<%@ Register src="../UserControls/Nav_Main_Image.ascx" tagname="Nav_Main_Image" tagprefix="uc2" %>
<div id="header">
    	<div class="warpper">
    		<div id="logo">
	        	<a href="/"><img src="img/logo.png" alt=""/></a>
        	</div>
            <uc1:Facebook_Like ID="Facebook_Like1" runat="server" />
            <div class="clear"></div>
        </div> 
  		<uc2:Nav_Main_Image ID="Nav_Main_Image1" runat="server" />
        <div class="clear"></div>
    </div>






