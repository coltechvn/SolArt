<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register_Member.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Register_Member" %>
<div id="register_block" class="formstyle customerinfotable clearfix">
	<h4 class="zone_title">Đăng ký thành viên</h4>
    <asp:Panel runat="server" ID="pnRegister">
	<table>
        <tr>
			<td class="label">Họ và tên</td>
			<td><asp:TextBox runat="server" ID="txtFullName" CssClass="txtinput"></asp:TextBox> *</td>
		</tr>
        <tr>
			<td class="label">Email</td>
			<td><asp:TextBox runat="server" ID="txtEmail" CssClass="txtinput"></asp:TextBox> *</td>
		</tr>
        <tr>
			<td class="label">Mật khẩu</td>
			<td><asp:TextBox runat="server" ID="txtPassword" CssClass="txtinput" TextMode="Password"></asp:TextBox> *</td>
		</tr>
        <tr>
			<td class="label">Nhập lại mật khẩu</td>
			<td><asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="txtinput" TextMode="Password"></asp:TextBox> *</td>
		</tr>
	</table>
	<div class="agreement">
		<asp:CheckBox runat="server" ID="chkAgree"/> Tôi đã đọc và đồng ý với các 
		<a href="#d">Điều khoản</a> và <a href="#d">Quy định</a> của My-deal.vn</div>
	<div class="button-wrap">
        <asp:Button runat="server" ID="butRegister" CssClass="button" Text="Đăng ký" 
            onclick="butRegister_Click" /></div>
    </asp:Panel>
    <div id="notice" runat="server" style="text-align: center"></div>
</div>
