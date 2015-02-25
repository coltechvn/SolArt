<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iDKCMS.BackEnd.Default" %>
<%@ Register src="Common/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="Common/Footer.ascx" tagname="Footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>iDK Control Panel: <asp:literal id="litTitle" runat="server"></asp:literal></title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link rel="stylesheet" type="text/css" href="theme/iDK/css/default.css" />
    <link rel="stylesheet" type="text/css" href="theme/iDK/css/menuStyle.css" />
    
    <script src="/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="/Scripts/jquery.idTabs.modified.js"></script>

    <script language="JavaScript" src="/Scripts/vietuni.js" type="text/javascript"></script>

    <script language="JavaScript">setTypingMode(1);</script>
</head>
<body class="cp">
    <form id="form2" runat="server">
    <div style="height:  100%; min-height: 100%;">
    <div id="LoadingDiv">
        <table cellpadding="0" cellspacing="0" border="0" height="30">
            <tr>
                <td align="center" valign="middle">
                    <img src="theme/iDK/img/indicator_blue_large.gif" alt="" class="boderw0" /></td>
            </tr>
        </table>
    </div>
        <table cellpadding="0" cellspacing="0" id="maincontainer">
            <tr>
                <td class="borderleft">
                    <img alt="" src="theme/iDK/img/Head_left.gif" width="20" height="130" /></td>
                <td class="maintd">
                    <table style="width: 100%" cellpadding="0" cellspacing="0" class="mainbody">
                        <tr>
                            <td class="headertd">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bodytd">
                                <div class="cmdtitle">
                                    <asp:Label ID="lblCommandName" runat="server"></asp:Label></div>
                                <div id="maincontent">
                                    <asp:PlaceHolder ID="placeControls" runat="server"></asp:PlaceHolder>
                                    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="footertd">
                                <uc2:Footer ID="Footer1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="borderright">
                    <img alt="" src="theme/iDK/img/Head_right.gif" width="20" height="130" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>