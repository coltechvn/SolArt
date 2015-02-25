<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KhoaHoc_List.ascx.cs"
    Inherits="iDKCMS.FrontEnd.Project.KhoaHoc_List" %>
<div class="col-left">
    <asp:Repeater runat="server" ID="rptData" EnableViewState="false" OnItemDataBound="rptData_ItemDataBound">
        <ItemTemplate>
            <div class="title-left" style="margin-bottom: 20px;">
                <h1 style="margin-bottom: 4px; text-transform: uppercase">
                    <asp:Literal runat="server" ID="litName"></asp:Literal></h1>
                <asp:Repeater runat="server" ID="rptDocument" EnableViewState="false" OnItemDataBound="rptDocument_ItemDataBound">
                    <ItemTemplate>
                        <div class="download">
                            <img src="img/download-thong-tin.png" style="float: left;" />
                            <asp:HyperLink runat="server" ID="lnkDownload">Download thông tin khoá học</asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="download">
                    <img src="img/dang-ky-hoc.png" style="float: left;" />
                    <asp:HyperLink runat="server" ID="lnkRegister">Đăng ký học</asp:HyperLink>
                </div>
                <div class="clear">
                </div>
                <div class="maincontent">
                    <asp:Literal runat="server" ID="litContent"></asp:Literal>
                </div>
                <div class="clear">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
