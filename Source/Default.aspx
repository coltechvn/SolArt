<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iDKCMS.FrontEnd.Default" %>

<%@ Register src="Layout/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="Layout/Footer.ascx" tagname="Footer" tagprefix="uc2" %>

<%@ Register src="Layout/Column_Right.ascx" tagname="Column_Right" tagprefix="uc4" %>

<%@ Register src="Project/TuyenSinh_Home.ascx" tagname="TuyenSinh_Home" tagprefix="uc3" %>

<%@ Register src="Layout/Home_AloneArea.ascx" tagname="Home_AloneArea" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal runat="server" ID="litWebTitle"></asp:Literal></title>
    <asp:Literal runat="server" ID="litDescription"></asp:Literal>
    <asp:Literal runat="server" ID="litKeyword"></asp:Literal>
    <link rel="stylesheet" type="text/css" media="all" href="css/style.css" />
    <link rel="stylesheet" type="text/css" media="all" href="css/reset.css" />

    <script type="text/javascript" src="/Scripts/jquery-1.4.4.min.js"></script>

    <link rel="stylesheet" href="css/prettyPhoto.css" type="text/css" media="screen"
        title="prettyPhoto main stylesheet" charset="utf-8" />
    <script src="/Scripts/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>


    <link rel="stylesheet" href="css/jquery.nivo.slider.css" type="text/css"  />
    <script type="text/javascript" src="/Scripts/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>

    <script type="text/javascript" src="/Scripts/swfobject.js"></script>
</head>
<body id="body">
    <form id="form1" runat="server">
    <div id="fb-root"></div>
        <script>
            window.fbAsyncInit = function () {
                FB.init({
                    appId: 'YOUR_APP_ID', // App ID
                    channelUrl: '//WWW.YOUR_DOMAIN.COM/channel.html', // Channel File
                    status: true, // check login status
                    cookie: true, // enable cookies to allow the server to access the session
                    xfbml: true  // parse XFBML
                });

                // Additional initialization code here
            };

            // Load the SDK Asynchronously
            (function (d) {
                var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
                if (d.getElementById(id)) { return; }
                js = d.createElement('script'); js.id = id; js.async = true;
                js.src = "//connect.facebook.net/en_US/all.js";
                ref.parentNode.insertBefore(js, ref);
            } (document));
    </script>

    <uc1:Header ID="Header1" runat="server" />
	<div id="banner">
    	<div class="warpper clearfix <%=Pageclass %>">
    		<div class="slide-banner">
            	<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>
            <uc3:TuyenSinh_Home ID="TuyenSinh_Home1" runat="server" Visible="false" />
            <uc4:Column_Right ID="Column_Right1" runat="server" />
            <div class="clear"></div>
        </div>
    </div>

    <uc5:Home_AloneArea ID="Home_AloneArea1" runat="server" Visible="false" />
    
    <uc2:Footer ID="Footer1" runat="server" />

    </form>
</body>
</html>
