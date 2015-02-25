<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuyenSinhList.ascx.cs" Inherits="iDKCMS.FrontEnd.Project.TuyenSinhList" %>
<%@ Register TagPrefix="cc1" Namespace="iDKCMS.WebControls" Assembly="iDKCMS.WebControls" %>
<asp:Repeater runat="server" ID="rptData" EnableViewState="false" onitemdatabound="rptData_ItemDataBound">
<ItemTemplate>
<div class="title-left">
    <asp:Image runat="server" ID="imgAvatar" CssClass="img-event" />
    <div class="event-conten" id="divRight" runat="server">
        <h2><asp:HyperLink runat="server" ID="lnkName"></asp:HyperLink></h2>
        <p><asp:Literal runat="server" ID="litTeaser"></asp:Literal></p>
        <div>
        <p style="float: left; margin: 16px 0 0 0;"><b>Ngày khai giảng:</b> <asp:Literal runat="server" ID="litDatetime"></asp:Literal></p>
        <div class="download" style="margin: 10px 0 0 0; line-height: 30px;">
            <img src="img/dang-ky-hoc.png" style="float: left;" />
            <asp:HyperLink runat="server" ID="lnkRegister">Đăng ký học</asp:HyperLink>
        </div>
        </div>
    </div>
    <div class="clear"></div>
</div>
</ItemTemplate>
</asp:Repeater>

<div class="conten-right">
    <cc1:CollectionPager ID="CollectionPager1" ResultsLocation="None" BackNextButtonStyle="."
            BackNextDisplay="HyperLinks" UseSlider="True" ShowPageNumbers="True" ShowLabel="False"
            PageNumbersSeparator="&nbsp;&nbsp;&nbsp;" HideOnSinglePage="True" FirstText="First"
            MaxPages="100" BackText="&nbsp;<<" LastText="Last" NextText=">>" ResultsFormat="{0}-{1} (in {2})"
            PageSize="20" runat="server" LabelText="Trang" ShowFirstLast="False" BackNextLinkSeparator="&nbsp;&nbsp;&nbsp;">
        </cc1:CollectionPager>
</div>
<div class="clear"></div>