<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent.ascx.cs"
    Inherits="iDKCMS.BackEnd.UserControls.Modules.CMS.EditContent" %>
<%@ Register Src="EditContent_Basic.ascx" TagName="EditContent_Basic" TagPrefix="uc1" %>
<%@ Register Src="EditContent_Images.ascx" TagName="EditContent_Images" TagPrefix="uc2" %>
<%@ Register Src="EditContent_Documents.ascx" TagName="EditContent_Documents" TagPrefix="uc4" %>
<%@ Register Src="EditContent_Video.ascx" TagName="EditContent_Video" TagPrefix="uc5" %>
<%@ Register Src="EditContent_Product.ascx" TagName="EditContent_Product" TagPrefix="uc6" %>
<%@ Register Src="EditContent_Poll.ascx" TagName="EditContent_Poll" TagPrefix="uc7" %>
<%@ Register Src="EditContent_Box.ascx" TagName="EditContent_Box" TagPrefix="uc3" %>
<%@ Register src="../Solart/EditContent_KhoaHoc.ascx" tagname="EditContent_KhoaHoc" tagprefix="uc8" %>
<div align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="760" align="center">
        <tr>
            <td class="Area">
                <div id="content_tab">
                    <ul class="idTabs iTabs clearfix">
                        <li><a href="#idTab1">Thông tin cơ bản</a></li>
                        <li><a href="#idTab2">Ảnh</a></li>
                        <li><a href="#idTab3">Tài liệu</a></li>
                        <li><a href="#idTab4">Video</a></li>
                        <li style="display:  none"><a href="#idTab5">Thông tin sản phẩm</a></li>
                        <li><a href="#idTab6">Bầu chọn (Poll)</a></li>
                        <li><a href="#idTab7">Box bổ trợ</a></li>
                        <li><a href="#idTab8">Khóa học</a></li>
                    </ul>
                </div>
                <div id="data_sheet">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <div class="block_content">
                        <div id="idTab1">
                            <uc1:EditContent_Basic ID="EditContent_Basic1" runat="server" />
                        </div>
                        <div id="idTab2">
                            <uc2:EditContent_Images ID="EditContent_Images1" runat="server" />
                        </div>
                        <div id="idTab3">
                            <uc4:EditContent_Documents ID="EditContent_Documents1" runat="server" />
                        </div>
                        <div id="idTab4">
                            <uc5:EditContent_Video ID="EditContent_Video1" runat="server" />
                        </div>
                        <div id="idTab5" style="display:  none">
                            <uc6:EditContent_Product ID="EditContent_Product1" runat="server" />
                        </div>
                        <div id="idTab6">
                            <uc7:EditContent_Poll ID="EditContent_Poll1" runat="server" />
                        </div>
                        <div id="idTab7">
                            <uc3:EditContent_Box ID="EditContent_Box1" runat="server" />
                        </div>
                        <div id="idTab8">
                            <uc8:EditContent_KhoaHoc ID="EditContent_KhoaHoc1" runat="server" />
                        </div>
                    </div>
                </div>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="overlay" id="overlay">
                            <img src="/acp/img/ajax-loading.gif" alt="" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</div>
