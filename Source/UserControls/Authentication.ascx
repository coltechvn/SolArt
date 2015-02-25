<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Authentication.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Authentication" %>
<div id="login_block_top">
    <asp:Panel runat="server" ID="pnLogin" DefaultButton="butSubmit">
	<p class="inputwrap"><asp:TextBox runat="server" ID="txtEmail" CssClass="textbox"></asp:TextBox></p>
	<p class="inputwrap"><asp:TextBox runat="server" ID="txtPassword" CssClass="textbox" TextMode="Password"></asp:TextBox></p>
	<p class="submit_wrap"><asp:Button ID="butSubmit" runat="server" Text="" 
            CssClass="butsubmit" onclick="butSubmit_Click" /></p>
	<p class="rememberme"><asp:CheckBox runat="server" ID="chkRemember" />Ghi nhớ</p>
	<p class="control"><a href="#d">Quên mật khẩu?</a> | <a href="/?tab=register">Đăng ký</a> |
	<a href="#d">Kích hoạt</a></p>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnUserInfo">
        <div id="userinfo_block">
        Xin chào, <b><asp:HyperLink runat="server" ID="lnkMemberInfo"></asp:HyperLink>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:HyperLink runat="server" ID="lnkUserCP">Thông tin cá nhân</asp:HyperLink>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton runat="server" ID="butLogout" OnClick="butLogout_Click" Text="Thoát"></asp:LinkButton></b>
        </div>
    </asp:Panel>
</div>