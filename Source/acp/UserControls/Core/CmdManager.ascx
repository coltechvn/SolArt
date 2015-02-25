<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CmdManager.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.CmdManager" %>
<%@ Register TagPrefix="componentart" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<link href="theme/iDK/css/treeStyle.css" type="text/css" rel="stylesheet" />
<div align=center>
<table height="100%" cellspacing="0" cellpadding="0" width="760" border="0">
	<tr>
		<td valign="top" style="width: 350px">
			<componentart:treeview id="tvwCmds" runat="server" ClientScriptLocation="/Scripts/componentart_webui_client/"
				NoExpandImageUrl="/acp/img/TreeView/noexp.gif" ExpandImageUrl="/acp/img/TreeView/col.gif"
				CollapseImageUrl="/acp/img/TreeView/exp.gif" NodeIndent="15" ExpandCollapseImageHeight="11"
				ExpandCollapseImageWidth="14" SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode"
				NodeRowCssClass="TreeNodeRow" NodeCssClass="TreeNode" CssClass="TreeView" KeyboardEnabled="true" NodeEditingEnabled="false"
				Height="100%" Width="350" AutoPostBackOnSelect="True" PreloadCurrentPath="True" CausesValidation="False" OnNodeSelected="tvwCmds_NodeSelected"></componentart:treeview></td>
		<td style="width: 5px"></td>
		<td valign="top">
			<table class="Area" id="Table3" cellspacing="0" cellpadding="5" width="100%" border="0">
				<tr>
					<td colspan="2">
						<asp:Label id="lblUpdateStatus" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td style="width: 25%">ID</td>
					<td>
						<asp:TextBox id="txtID" Width="224px" runat="server" Enabled="False" CssClass="solidnormal"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Tên</td>
					<td>
						<asp:TextBox id="txtName" Width="224px" runat="server" CssClass="solidnormal"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtName"
							ErrorMessage="(*)"></asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td>Lệnh</td>
					<td>
						<asp:TextBox id="txtCmd" Width="224px" runat="server" CssClass="solidnormal"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Tham số</td>
					<td>
						<asp:TextBox id="txtParams" Width="224px" runat="server" CssClass="solidnormal"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Link Url</td>
					<td>
						<asp:TextBox id="txtUrl" Width="224px" runat="server" CssClass="solidnormal"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Đường dẫn</td>
					<td>
						<asp:TextBox id="txtPath" Width="224px" runat="server" CssClass="solidnormal"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Cha</td>
					<td>
						<asp:DropDownList id="dropParent" Width="224px" runat="server" CssClass="solidnormal"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>Thứ tự</td>
					<td>
						<asp:DropDownList id="dropIndex" Width="88px" runat="server" CssClass="solidnormal"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>Hoạt động</td>
					<td>
						<asp:CheckBox id="chkEnable"  runat="server" Checked="True"></asp:CheckBox></td>
				</tr>
				<tr>
					<td>Hiển thị</td>
					<td>
						<asp:CheckBox id="chkVisble"  runat="server" Checked="True"></asp:CheckBox></td>
				</tr>
			</table>
			<br />
			<table class="SidePanel" id="Table2" height="35" cellspacing="0" cellpadding="3" width="100%"
				border="0">
				<tr>
					<td align="left">
						<asp:Button id="cmdUpdate" Width="77" runat="server" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:Button>
						<asp:Button id="cmdAddNew" Width="77px" runat="server" Text="Thêm mới" OnClick="cmdAddNew_Click" ></asp:Button>
						<asp:Button id="cmdDelete" Width="77px" runat="server" Text="Xóa" OnClick="cmdDelete_Click" ></asp:Button>
						<asp:Button id="cmdEmpty" Width="77" runat="server" Text="Hủy" CausesValidation="False" OnClick="cmdEmpty_Click"></asp:Button></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</div>