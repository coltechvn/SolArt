<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactForm.ascx.cs"
    Inherits="iDKCMS.FrontEnd.UserControls.ContactForm" %>
<div class="title-left" style="padding-top: 20px;">
    <asp:Literal runat="server" ID="litContent"></asp:Literal>
</div>
<div runat="server" id="notice">
</div>
<asp:Panel runat="server" ID="pnform">
    <div class="title-left" style="margin-top: 20px; border-bottom: none;">
        <div class="col-2" style="border-left: none;">
            <h2>
                Gửi câu hỏi/ chia sẻ thắc mắc</h2>
            Họ tên
            <br />
            <asp:TextBox runat="server" ID="txtName" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox>
            <br />
            Email
            <br />
            <asp:TextBox runat="server" ID="txtEmail" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox>
            Tiêu đề
            <br />
            <asp:TextBox runat="server" ID="txtSubject" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox><br />
            Số điện thoại
            <br />
            <asp:TextBox runat="server" ID="txtPhone" Style="margin: 5px 0 10px 0; width: 250px;"
                CssClass="solid"></asp:TextBox>
            <p style="float: left;">
                Giới tính</p>
            <div style="margin: 0 0 0 70px;">
                <asp:RadioButtonList runat="server" ID="rdolGender">
                    <asp:ListItem Value="Nam">Nam</asp:ListItem>
                    <asp:ListItem Value="Nu">Nữ</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="col-2" style="border-left: none; margin-top: 16px;">
            <h2>
            </h2>
            Lời nhắn / câu hỏi
            <br />
            <asp:TextBox runat="server" ID="txtContent" Style="margin: 5px 0 10px 0; width: 300px;
                height: 210px;" CssClass="solid" TextMode="MultiLine"></asp:TextBox>
            <input type="reset" name="reset" value="Viết lại" style="background: #C00; color: #FFF;
                padding: 5px 25px; margin: 5px 20px 0 0;" />
            <asp:Button runat="server" Text="Gửi đi" ID="butSend" Style="background: #C00; color: #FFF;
                padding: 5px 25px; margin: 5px 20px 0 0;" OnClick="butSend_Click" />
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div class="clear">
</div>
