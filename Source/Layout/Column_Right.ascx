<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Column_Right.ascx.cs" Inherits="iDKCMS.FrontEnd.Layout.Column_Right" %>
<%@ Register src="../Project/TuyenSinh_Home.ascx" tagname="TuyenSinh_Home" tagprefix="uc4" %>
<%@ Register src="../UserControls/Music_Home.ascx" tagname="Music_Home" tagprefix="uc1" %>
<%@ Register src="../UserControls/Video_RightSub.ascx" tagname="Video_RightSub" tagprefix="uc2" %>
<%@ Register src="../Project/CamNhan_Sub.ascx" tagname="CamNhan_Sub" tagprefix="uc3" %>
<%@ Register src="../UserControls/Subcategory_2level.ascx" tagname="Subcategory_2level" tagprefix="uc5" %>
<%@ Register src="../Project/News_Sub.ascx" tagname="News_Sub" tagprefix="uc6" %>
<%@ Register src="../Project/Search_Khoahoc.ascx" tagname="Search_Khoahoc" tagprefix="uc7" %>
<div class="col-right">
    <uc4:TuyenSinh_Home ID="TuyenSinh_Home1" runat="server" Visible="false" />
    <uc7:Search_Khoahoc ID="Search_Khoahoc1" runat="server"  Visible="false"/>
    <uc5:Subcategory_2level ID="Subcategory_2level1" runat="server"  Visible="false"/>
    <uc3:CamNhan_Sub ID="CamNhan_Sub1" runat="server"  Visible="false"/>
    <uc1:Music_Home ID="Music_Home1" runat="server"  Visible="false"/>
    <uc6:News_Sub ID="News_Sub1" runat="server"  Visible="false"/>
    <uc2:Video_RightSub ID="Video_RightSub1" runat="server"  Visible="false"/>
</div>


