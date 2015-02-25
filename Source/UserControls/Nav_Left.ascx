<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_Left.ascx.cs" Inherits="iDKCMS.FrontEnd.UserControls.Nav_Left" %>
<div id="category_block">
	<h4>Danh mục:</h4>
	<ul>
		<li class="selected"><a href="/">Tất cả</a></li>
        <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <ItemTemplate>
		<li class="sep">
		<img alt="" src="img/category_sep.gif" /></li>
		<li><asp:HyperLink ID="lnkZone" runat="server"></asp:HyperLink></li> <!--  (107) -->
        </ItemTemplate>
        </asp:Repeater>
	</ul>
</div>