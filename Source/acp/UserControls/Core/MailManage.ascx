<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailManage.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.MailManage" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<div align="center">
<table cellspacing="0" cellpadding="0" width="99%" border="0">
    <tr>
        <td><asp:Label ID="lblUpdateStatus" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <div id="datagrid">
            <cc1:NewDataGrid ID="dtgMail" runat="server" BorderWidth="0px" Width="100%" AllowPaging="True"
                OrderBy="DESC" AutoGenerateColumns="False" AllowSorting="True" CellPadding="2"
                PageSize="50" OnItemCommand="dtgMail_ItemCommand" OnItemDataBound="dtgMail_ItemDataBound">
                <AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
                <ItemStyle CssClass="LightRow"></ItemStyle>
                <HeaderStyle CssClass="HeaderRow"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn ReadOnly="True" DataField="Mail_ID" Visible="False"></asp:BoundColumn>
                    <asp:TemplateColumn>
                        <HeaderStyle horizontalalign="Center" width="20px"></HeaderStyle>
                        <ItemStyle horizontalalign="Center"></ItemStyle>
                        <ItemTemplate>
																<asp:CheckBox Runat="server" ID="chkSelect"></asp:CheckBox>
															</ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn ReadOnly="True" HeaderText="Stt">
                        <HeaderStyle width="30px" horizontalalign="Center"></HeaderStyle>
                        <ItemStyle horizontalalign="Center"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Tên" SortExpression="Mail_Name">
                        <ItemTemplate>
																<asp:HyperLink id="lnkName" Runat="server" Target="_blank" CssClass="link"></asp:HyperLink>
															</ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn HeaderText="Điện thoại" SortExpression="Mail_Phone" DataField="Mail_Phone">
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Địa chỉ" SortExpression="Mail_Address" DataField="Mail_Address">
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Nội dung" SortExpression="Mail_Content">
                        <ItemTemplate>
																<asp:Literal Runat="server" ID="litContent"></asp:Literal>
															</ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Thời gian" SortExpression="Mail_Datetime">
                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
																<asp:Label Runat="server" ID="lblDatetime"></asp:Label>
															</ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Trả lời" SortExpression="Mail_Answer">
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
																<asp:CheckBox Runat="server" ID="chkAnswer" Checked='<%#((bool)DataBinder.Eval(Container.DataItem,"Mail_Answer"))%>'>
																</asp:CheckBox>
															</ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn>
                        <HeaderStyle width="40px" horizontalalign="Center"></HeaderStyle>
                        <ItemStyle horizontalalign="Center"></ItemStyle>
                        <ItemTemplate>
																<asp:ImageButton CommandName="editrow" runat="server" ImageUrl="/acp/img/icon_enter.gif" ID="btn_updaterow"></asp:ImageButton>
																<asp:ImageButton id="btn_delete" runat="server" ImageUrl="/acp/img/icon_delete.gif" CommandName="delete"></asp:ImageButton>
															</ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
                <PagerStyle Mode="NumericPages"></PagerStyle>
            </cc1:NewDataGrid>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td style="text-align: right;">
            <asp:Button ID="butDellChecked" runat="server" Text="Xóa đánh dấu" OnClick="butDellChecked_Click">
            </asp:Button>
            <asp:Button ID="butDelAll" runat="server" Text="Cập nhập tất cả" OnClick="butDelAll_Click">
            </asp:Button></td>
    </tr>
</table>
</div>