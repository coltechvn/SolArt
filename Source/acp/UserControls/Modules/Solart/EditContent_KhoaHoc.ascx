<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent_KhoaHoc.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Solart.EditContent_KhoaHoc" %>
<table cellSpacing="0" cellPadding="3" width="100%" align="center">
	<tr>
		<td>
        <asp:UpdatePanel runat="server" ID="UpdatePanelStatus">
        <ContentTemplate>
			<asp:Label id="lblStatusUpdate" runat="server"></asp:Label>
            </ContentTemplate>
            </asp:UpdatePanel></td>
	</tr>
	<tr>
		<td>
            <table cellSpacing="0" cellPadding="4" width="100%" align="center" border="0">
                <tr>
                    <td><b>Lớp học</b></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList runat="server" ID="dropLopHoc"/>
                    </td>
                </tr>
                <tr>
					<td><b>Cơ sở</b></td>
				</tr>
				<tr>
					<td>
                        <asp:CheckBoxList runat="server" ID="chklCoso" RepeatColumns="5"></asp:CheckBoxList>
                    </td>
				</tr>
                <tr>
					<td><b>Môn học (nội dung text)</b></td>
				</tr>
				<tr>
					<td><asp:TextBox id="txtNoiDungHocText" runat="server" Width="260px" TextMode="MultiLine " CssClass="solidnormal"></asp:TextBox></td>
				</tr>
                <tr>
					<td><b>Môn học</b></td>
				</tr>
				<tr>
					<td><asp:CheckBoxList runat="server" ID="chklMonHoc" RepeatColumns="5"></asp:CheckBoxList></td>
				</tr>
                <tr>
					<td><b>Độ tuổi (nội dung text)</b></td>
				</tr>
                <tr>
                    <td>
                        <asp:TextBox id="txtDoTuoiText" runat="server" Width="260px" TextMode="MultiLine " CssClass="solidnormal"></asp:TextBox>
                    </td>
                </tr>
                <tr>
					<td><b>Độ tuổi</b></td>
				</tr>
				<tr>
					<td><asp:ListBox ID="lstDoTuoi" runat="server" Width="220px" Height="100px" SelectionMode="Multiple" CssClass="solidnormal">
                            <asp:ListItem Value="-">Lựa chọn độ tuổi</asp:ListItem>
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
                        </asp:ListBox>
                    </td>
								
				</tr>
                <tr>
					<td><b>Giờ học</b></td>
				</tr>
				<tr>
					<td>
                        <asp:TextBox id="txtGioHoc" runat="server" Width="260px" TextMode="MultiLine " CssClass="solidnormal"></asp:TextBox></td>
								
				</tr>
				<tr>
					<td><b>Khai giảng</b></td>
				</tr>
				<tr>
					<td>
                        <asp:TextBox id="txtKhaiGiang" runat="server" Width="260px" TextMode="MultiLine " CssClass="solidnormal"></asp:TextBox></td>
								
				</tr>
                <tr>
					<td>Hoạt động&nbsp;<asp:CheckBox runat="server" ID="chkVisible" /></td>
								
				</tr>        
			</table>
		</td>
	</tr>
	<tr>
		<td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
			<p align="center">
            
				<asp:button id="cmdUpdate" accessKey="s" runat="server" Width="110px" 
                    Text="Cập nhật" CausesValidation="False" onclick="cmdUpdate_Click"></asp:button>&nbsp;&nbsp;&nbsp;
                    <asp:button id="butDelete" runat="server" Width="110px" 
                    Text="Xóa thông tin" CausesValidation="False" onclick="butDelete_Click" ></asp:button>&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblSuccess" Visible="false">abc</asp:Label>
            </p>
           </ContentTemplate>
            </asp:UpdatePanel>
		</td>
	</tr>
</table>