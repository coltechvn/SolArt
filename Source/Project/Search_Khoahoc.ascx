<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search_Khoahoc.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.Search_Khoahoc" %>
<div class="col-right-conten clear" style="background: url(img/gray.png)repeat;">
    <asp:Panel runat="server" ID="pnSearchKH" DefaultButton="butSearch">
    <img src="img/list-red.png" style="float:left; margin-top: 25px ;" />
        <div class="title"><h2>Tìm kiếm khóa học</h2></div>
        <div class="clear"></div>
    <div style="width: 220px; margin: 0 0 10px 10px">
            <b>Chọn môn học</b> <br />
            <asp:DropDownList runat="server" ID="dropFilterMonHoc" style="width: 210px; height: 20px; line-height: 20px; margin-top: 5px;"></asp:DropDownList>
            <div class="clear"></div>
    </div>
<div style="width: 100px; margin: 0 0 10px 10px; float:left;">
            <b>Độ tuổi</b> <br />
            <asp:DropDownList runat="server" ID="dropFilterDoTuoi" style="width: 100px; height: 20px; line-height: 20px; margin-top: 5px;">
                <asp:ListItem Value="">Chọn độ tuổi</asp:ListItem>
                <asp:ListItem Value="1">1 tuổi</asp:ListItem>
                <asp:ListItem Value="2">2 tuổi</asp:ListItem>
                <asp:ListItem Value="3">3 tuổi</asp:ListItem>
                <asp:ListItem Value="4">4 tuổi</asp:ListItem>
                <asp:ListItem Value="5">5 tuổi</asp:ListItem>
                <asp:ListItem Value="6">6 tuổi</asp:ListItem>
                <asp:ListItem Value="7">7 tuổi</asp:ListItem>
                <asp:ListItem Value="8">8 tuổi</asp:ListItem>
                <asp:ListItem Value="9">9 tuổi</asp:ListItem>
                <asp:ListItem Value="10">10 tuổi</asp:ListItem>
                <asp:ListItem Value="11">11 tuổi</asp:ListItem>
                <asp:ListItem Value="12">12 tuổi</asp:ListItem>
                <asp:ListItem Value="13">13 tuổi</asp:ListItem>
                <asp:ListItem Value="14">14 tuổi</asp:ListItem>
                <asp:ListItem Value="15">15 tuổi</asp:ListItem>
                <asp:ListItem Value="16">16 tuổi</asp:ListItem>
                <asp:ListItem Value="17">17 tuổi trở lên</asp:ListItem>
                </asp:DropDownList>
            <div class="clear"></div>
    </div>
        <div style="width: 100px; margin: 0 0 10px 10px; float:left;">
            <b>Cơ sở</b> <br />
               <asp:DropDownList runat="server" ID="dropFilterCoso"  style="width: 100px; height: 20px; line-height: 20px; margin-top: 5px;" />
            <div class="clear"></div>
        </div>
        <asp:Button runat="server" ID="butSearch" Text="Tìm kiếm"  style=" background: #F00; border: none; color: #fff; margin: 20px 0 0 10px; cursor: pointer;" CssClass="button" onclick="butSearch_Click" />
        <img src="img/gray-bottom.png" />
    <div class="clear"></div>
    </asp:Panel>
    </div>
