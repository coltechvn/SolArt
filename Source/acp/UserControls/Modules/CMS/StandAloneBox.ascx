<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StandAloneBox.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.StandAloneBox" %>
<%@ Register TagPrefix="cc1" Namespace="AWS.FilePicker" Assembly="FilePickerControl" %>
<%@ Register src="../../Controls/Editor.ascx" tagname="Editor" tagprefix="uc1" %>
<div align=center>
<table  border="0" cellpadding="0" cellspacing="0" width="760">
    <tr>
        <td align="left" valign="top" style="height: 470px; width: 250px;">
            <asp:ListBox ID="lstZones" Width="100%" runat="server" Height="450px" AutoPostBack="True" CausesValidation="True" CssClass="solidnormal" OnSelectedIndexChanged="lstZones_SelectedIndexChanged"></asp:ListBox>
        </td>
        <td width="10px">
        </td>
        <td  align="left"  valign="top">
           <table  border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left"  valign="top">
                        <table  border="0" cellpadding="0" cellspacing="0" width="100%" class="Area">
                            <tr>
                                <td align="left" colspan="2" style="padding-bottom: 2px; padding-top: 2px">
                                <asp:Label ID="lblStatusUpdate" runat="server" ForeColor="#FF00FF"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%" align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Tên box:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <asp:TextBox id="txtName" Width="265" runat="server" CssClass="solidnormal"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Mục trỏ đến:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <asp:DropDownList id="dropZones"  runat="server" CssClass="solidnormal"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    Địa chỉ trỏ đến:
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:TextBox ID="txtRealUrl" runat="server" Width="266" CssClass="solidnormal"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td align="left" style="padding-bottom:2px; padding-top:2px;">
                                    Ảnh đại diện:
                                </td>
                                <td  align="left" style="padding-bottom:2px; padding-top:2px;">
                                    <cc1:FilePicker  CssClass="solidnormal" id="txtAvatar" Width="120px" runat="server" fpUploadDir="/Upload/CMS/Zone/" fpPopupURL="../FilePicker/FilePicker.aspx"></cc1:FilePicker>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    Tên kỹ thuật:
                                </td>
                                <td align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:TextBox ID="txtFriendlyUrl" runat="server" Width="266" CssClass="solidnormal"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left" style="padding-bottom: 2px; padding-top: 2px">
                                    <asp:Button  Width="100px" ID="btnUpdate" runat="server" Text="Cập nhật sửa đổi" Enabled="False" OnClick="btnUpdate_Click" />&nbsp;
                                    <asp:Button Width="80px" ID="btnAdd" runat="server" Text="Thêm mới" 
                                        onclick="btnAdd_Click" />&nbsp;
                                    <asp:Button Width="80px" ID="btnDelete" runat="server" Text="Xóa" 
                                        Enabled="False" onclick="btnDelete_Click" />&nbsp;<input
                                        id="btnReset" style="width:80px;" type="reset" runat="server" value="" />
                                </td>
                               
                            </tr>
                        </table>
                    
                    </td>  
                </tr>
                 <tr>
                    <td style="height: 20px;">Nội dung box:</td>
                </tr>
                <tr>
                    <td>
                        <uc1:Editor ID="txtDescriptionCK" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hddID" runat="server" />
        </td>
    </tr>
    
</table>
</div>
&nbsp;
<script language="javascript" >

    function ConfirmDelete(mess) {
        return confirm(mess);
    }
</script>
