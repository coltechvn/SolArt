<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderList.ascx.cs" Inherits="iDKCMS.BackEnd.UserControls.Modules.Order.OrderList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>

<script language="JavaScript" src="/Scripts/vietuni.js" type="text/javascript"></script>

<script language="JavaScript">setTypingMode(1);</script>

<div align="center">
    <table cellspacing="1" cellpadding="2" width="99%" border="0">
        <tr>
            <td>
                <table border="0" id="table1" cellspacing="0" cellpadding="0" width="100%" class="Area">
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0" width="100%" runat="server" id="Table2">
                                <tr>
                                    <td width="60">
                                        <b>Search:</b></td>
                                    <td class="textwhite">
                                        <asp:TextBox ID="txtSearch" CssClass="solid" runat="server"></asp:TextBox></td>
                                    <td width="8">
                                    </td>
                                    <td width="100">
                                        <asp:DropDownList runat="server" ID="dropSearchBy" CssClass="px">
                                            <asp:ListItem Value="Order_ID">Số order</asp:ListItem>
                                            <asp:ListItem Value="Order_Fullname">Tên</asp:ListItem>
                                            <asp:ListItem Value="Order_Email">Email</asp:ListItem>
                                            <asp:ListItem Value="Order_Tel">Điện thoại</asp:ListItem>
                                            <asp:ListItem Value="Order_Address">Địa chỉ</asp:ListItem>
                                            <asp:ListItem Value="Order_District">Mobile</asp:ListItem>
                                            <asp:ListItem Value="Order_City">Mobile</asp:ListItem>
                                            <asp:ListItem Value="Order_Note">Nội dung</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="4">
                                    </td>
                                    <td width="100">
                                        <asp:DropDownList runat="server" ID="dropSearchStatus" CssClass="px">
                                            <asp:ListItem Value="all">Tất cả</asp:ListItem>
                                            <asp:ListItem Value="0">Chưa confirm</asp:ListItem>
                                            <asp:ListItem Value="1">Đã confirm</asp:ListItem>
                                            <asp:ListItem Value="2">Đã chuyển hàng</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="4">
                                    </td>
                                    <td width="30" align="center">
                                        <asp:ImageButton ID="btnsearch" runat="server" ImageUrl="/acp/img/icon_search.gif">
                                        </asp:ImageButton></td>
                                </tr>
                            </table>
                        </td>
                        <td width="150" align="center">
                            <input type="radio" name="switcher" value="OFF" onfocus="setTypingMode(0)">Off<input
                                type="radio" name="switcher" value="TELEX" checked onfocus="setTypingMode(1)">Telex<input
                                    type="radio" name="switcher" value="VNI" onfocus="setTypingMode(2)">VNI</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="alignleft">
                <asp:Label ID="lblUpdateStatus" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="alignleft">
                <asp:Label ID="lblTotalUp" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <div id="datagrid">
                    <cc1:NewDataGrid ID="dtgOrder" runat="server" Width="100%" AutoGenerateColumns="False"
                        CellPadding="2" PageSize="20" AllowPaging="True" OrderBy="DESC" AllowSorting="True"
                        BorderWidth="0px" OnItemCommand="dtgProduct_ItemCommand" OnItemDataBound="dtgProduct_ItemDataBound">
                        <AlternatingItemStyle CssClass="DarkRow"></AlternatingItemStyle>
                        <ItemStyle CssClass="LightRow"></ItemStyle>
                        <HeaderStyle CssClass="HeaderRow"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn Visible="True" DataField="Order_ID" ReadOnly="True" HeaderText="ID">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn>
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                                <itemtemplate>
													<asp:CheckBox id="chkSelect" Runat="server"></asp:CheckBox>
												</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Ngày tạo" SortExpression="Order_CreateDate">
                                <headerstyle width="80px" horizontalalign="Center"></headerstyle>
                                <itemstyle width="80px" horizontalalign="Center"></itemstyle>
                                <itemtemplate>
													<asp:Label id="lblDatetime" Runat="server"></asp:Label>
												</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Họ tên" SortExpression="Order_Fullname">
                                <headerstyle horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"></itemstyle>
                                <itemtemplate>
													<asp:HyperLink id="lnkOrderName" Runat="server" CssClass="link"></asp:HyperLink>
												</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Điện thoại" SortExpression="Order_Tel" DataField="Order_Tel">
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Địa chỉ" SortExpression="Order_Address">
                                <headerstyle width="200px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"></itemstyle>
                                <itemtemplate>
													<asp:Label Runat="server" ID="lblAddress"></asp:Label>
												</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Mobile" SortExpression="Order_District" DataField="Order_District">
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Mobile" SortExpression="Order_City" DataField="Order_City">
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="P" SortExpression="Order_Status">
                                <headerstyle width="20px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                                <itemtemplate>
												<asp:DropDownList runat="server" ID="dropStatus" CssClass="px">
                                                    <asp:ListItem Value="0">Chưa confirm</asp:ListItem>
                                                    <asp:ListItem Value="1">Đã confirm</asp:ListItem>
                                                    <asp:ListItem Value="2">Đã chuyển hàng</asp:ListItem>
                                                </asp:DropDownList>
												</itemtemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thao tác">
                                <headerstyle width="70px" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                                <itemtemplate>
													<asp:ImageButton id="btn_updaterow" runat="server" ImageUrl="/acp/img/icon_enter.gif" CommandName="updaterow"></asp:ImageButton>
													<a class="link" href='?cmd=orderview&amp;orderid=<%#DataBinder.Eval(Container.DataItem,"Order_ID")%>'><asp:Image id="btn_update" runat="server" ImageUrl="/acp/img/icon_view.gif"></asp:Image></a>
													<asp:ImageButton id="btn_delete" runat="server" ImageUrl="/acp/img/icon_delete.gif" CommandName="delete"></asp:ImageButton>
												</itemtemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="Bottom" Mode="NumericPages"></PagerStyle>
                    </cc1:NewDataGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td class="alignleft">
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td class="alignright">
                <asp:Button ID="butUpdateAll" runat="server" Text="Cập nhật tất cả" OnClick="butUpdateAll_Click">
                </asp:Button>&nbsp;<asp:Button ID="butDeleteChecked" runat="server" Text="Xóa đánh dấu"
                    OnClick="butDeleteChecked_Click"></asp:Button>&nbsp;</td>
        </tr>
    </table>
</div>
