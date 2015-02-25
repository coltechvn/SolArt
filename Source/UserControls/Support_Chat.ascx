<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Support_Chat.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Support_Chat" %>
<div class="block" id="support_block">
	<h4>Hỗ trợ trực tuyến</h4>
	<div class="block_content clearfix">
		<ul>
			<li class="clearfix" runat="server" id="liYM1"><p class="label">Mydeal</p><p class="icon"><a href="ymsgr:sendim?<%=Ym1 %>">
			<img alt="" src="http://opi.yahoo.com/online?u=<%=Ym1 %>&t=2" /></a></p></li>
            <li class="clearfix" runat="server" id="liYM2"><p class="label">Mydeal 2</p><p class="icon"><a href="ymsgr:sendim?<%=Ym2 %>">
			<img alt="" src="http://opi.yahoo.com/online?u=<%=Ym2 %>&t=2" /></a></p></li>
		</ul>
	</div>
</div>
