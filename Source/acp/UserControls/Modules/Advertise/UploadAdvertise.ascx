<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadAdvertise.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Advertise.UploadAdvertise" %>
<%@ Register TagPrefix="cc1" Namespace="AWS.FilePicker" Assembly="FilePickerControl" %>
<%@ Register src="../../Controls/SelectDate.ascx" tagname="SelectDate" tagprefix="uc1" %>
<div align="Center">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="760" border="0">
	<TR align="center">
		<TD width="170"><B>Vị trí</B></TD>
		<TD><B>Khu vực</B></TD>
	</TR>
	<TR align="center">
		<TD>
		    <asp:UpdatePanel runat="server">
                <ContentTemplate>
                
			<asp:listbox AutoPostBack="true" id="lstPositions" runat="server" Width="160px" Height="152px" CssClass="solidnormal" OnSelectedIndexChanged="lstPositions_SelectedIndexChanged"></asp:listbox>
			</ContentTemplate>
            </asp:UpdatePanel>
			</TD>
		<TD>
			<asp:listbox id="lstZones" runat="server" Width="100%" Height="152px" SelectionMode="Multiple" CssClass="solidnormal"></asp:listbox></TD>
	</TR>
</TABLE>
<BR>
<TABLE class="SidePanel" cellSpacing="0" cellPadding="4" width="760" border="0">
	<TR>
		<TD colSpan="2"><asp:label id="lblStatusUpdate" runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD width="15%"></TD>
		<TD><asp:textbox id="txtID" Width="352px" runat="server" Enabled="False" Visible="False"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="15%">Tên quảng cáo</TD>
		<TD><asp:textbox id="txtName" Width="352px" runat="server" CssClass="solidnormal"></asp:textbox>
			<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Display="Dynamic" ControlToValidate="txtName"
				ErrorMessage="(*)"></asp:requiredfieldvalidator></TD>
	</TR>
	<TR>
		<TD width="15%">Kiểu quảng cáo</TD>
		<TD><asp:dropdownlist id="dropType" runat="server" CssClass="solidnormal">
				<asp:ListItem Value="image">Image</asp:ListItem>
				<asp:ListItem Value="flash">Flash animation</asp:ListItem>
				<asp:ListItem Value="media">Video Media Player</asp:ListItem>
				<asp:ListItem Value="flv">Flash Media Player</asp:ListItem>
				<asp:ListItem Value="embed">Youtube (or Embed) Player</asp:ListItem>
			</asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD>File</TD>
		<TD><cc1:filepicker id="txtPath" Width="352px" runat="server" fpPopupURL="/FilePicker/FilePicker.aspx" CssClass="solidnormal"></cc1:filepicker></TD>
	</TR>
	<TR>
		<TD>Địa chỉ trỏ tới</TD>
		<TD><asp:textbox id="txtUrl" Width="352px" runat="server" CssClass="solidnormal">http://</asp:textbox></TD>
	</TR>
	<TR>
		<TD>Kích thước</TD>
		<TD>
		<asp:UpdatePanel runat="server">
            <ContentTemplate>
            
		<asp:textbox id="txtWidth" Width="40px" runat="server" CssClass="solidnormal">0</asp:textbox>&nbsp;x
			<asp:textbox id="txtHeight" Width="40px" runat="server" CssClass="solidnormal">0</asp:textbox>&nbsp;(pixel)
            </ContentTemplate>
        </asp:UpdatePanel>
            </TD>
	</TR>
	<TR>
		<TD>Ngày bắt đầu</TD>
		<TD>
            <uc1:SelectDate ID="SelectDate1" runat="server" />
        </TD>
	</TR>
	<TR>
		<TD>Ngày kết thúc</TD>
		<TD>
            <uc1:SelectDate ID="SelectDate2" runat="server" />
        </TD>
	</TR>
	<TR>
		<TD>Sử dụng</TD>
		<TD><asp:checkbox id="chkEnable" runat="server" Checked="True"></asp:checkbox></TD>
	</TR>
	<TR>
		<TD colSpan="2"><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="lstPositions" ErrorMessage="Phải nhập vị trí đăng quảng cáo"></asp:requiredfieldvalidator><BR>
			<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Phải nhập khu vực đăng quảng cáo"
				ControlToValidate="lstZones"></asp:requiredfieldvalidator></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="2">
			<asp:button id="cmdUpdate" Width="73px" runat="server" Text="Cập nhật" OnClick="cmdUpdate_Click"></asp:button>
			<asp:button id="cmdAddNew" Width="73px" runat="server" Text="Thêm mới" OnClick="cmdAddNew_Click"></asp:button>
			<asp:button id="cmdAddNext" Width="73px" runat="server" Text="Thêm tiếp" OnClick="cmdAddNext_Click"></asp:button>
			<asp:Button id="cmdEmpty" Width="73px" runat="server" Text="Hủy" CausesValidation="False" OnClick="cmdEmpty_Click"></asp:Button></TD>
	</TR>
	<tr>
	    <td>Youtube or Embed</td>
	    <td><asp:TextBox runat="server" ID="txtEmbed" TextMode="MultiLine" Height="50px" CssClass="solid"></asp:TextBox></td>
	</tr>
</TABLE>
</div>