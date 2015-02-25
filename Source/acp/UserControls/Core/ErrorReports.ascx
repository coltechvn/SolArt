<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorReports.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Core.ErrorReports" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>

<script language="JavaScript" src="/Scripts/vietuni.js" type="text/javascript"></script>

<script language="JavaScript">    setTypingMode(1);</script>

<div align="center">
    <table cellspacing="0" cellpadding="0" width="99%" border="0">
        <tr>
            <td>
                <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
            <div id="datagrid">
                <cc1:NewDataGrid ID="dtgError" runat="server" BorderWidth="0px" Width="100%" AllowPaging="True"
                    OrderBy="DESC" AutoGenerateColumns="False" AllowSorting="True" CellPadding="2"
                    PageSize="50" OnItemCommand="dtgError_ItemCommand" OnItemDataBound="dtgError_ItemDataBound">
                    <AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="LightRow"></ItemStyle>
                    <HeaderStyle CssClass="HeaderRow"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn ReadOnly="True" DataField="Error_ID" Visible="False"></asp:BoundColumn>
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
                        <asp:TemplateColumn HeaderText="Url" SortExpression="Error_Url">
                            <ItemTemplate>
																<asp:HyperLink id="lnkUrl" Runat="server" Target="_blank" CssClass="link"></asp:HyperLink>
															</ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn ReadOnly="True" DataField="Error_String" HeaderText="String" SortExpression="Error_String">
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Time" SortExpression="Error_Datetime">
                            <HeaderStyle horizontalalign="Center"></HeaderStyle>
                            <ItemStyle horizontalalign="Center"></ItemStyle>
                            <ItemTemplate>
																<asp:Label Runat="server" ID="lblDate"></asp:Label>
															</ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle width="20px" horizontalalign="Center"></HeaderStyle>
                            <ItemStyle horizontalalign="Center"></ItemStyle>
                            <ItemTemplate>
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
                </asp:Button>&nbsp;
                <asp:Button ID="butDelAll" runat="server" Text="Xóa tất cả" OnClick="butDelAll_Click">
                </asp:Button></td>
        </tr>
    </table>
</div>
