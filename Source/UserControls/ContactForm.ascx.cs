using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class ContactForm : System.Web.UI.UserControl
    {
        private int _zonecurrent;

        protected void Page_Load(object sender, EventArgs e)
        {
            _zonecurrent = ZoneUtility.GetZoneCurrent();
            butSend.Text = AppEnv.GetDefaultLanguage() == "vi-VN" ? "Gửi đi" : "Send message";

            ShowInfo();
        }

        private void ShowInfo()
        {
            var dtContent = DistributionDB.GetContentByZoneIDselfAndNumberRecord(_zonecurrent, 1);

            if (dtContent.Rows.Count != 0)
            {
                var rowIntro = dtContent.Rows[0];

                litContent.Text = rowIntro["Content_Body"].ToString();
            }
        }

        protected void butSend_Click(object sender, EventArgs e)
        {
            var contactEmail = AppEnv.ContactEmail;

            if (txtName.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0 || txtContent.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải điền tất cả các ô có dấu (*)");
                return;
            }
            //if(txtCode.Text.Trim() != FormShield1.GetText())
            //{
            //    MessageBox.Show("Bạn nhập không đúng mã bảo vệ");
            //    return;
            //}

            const string matchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                             + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                             + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            if (Regex.IsMatch(txtEmail.Text.Trim(), matchEmailPattern) == false)
            {
                MessageBox.Show("Email không đúng !!!");
                return;
            }

            var sb = new StringBuilder();
            sb.Append("<b>Ho ten</b>: ");
            sb.Append(txtName.Text);
            sb.Append("<br><b>Email</b>: ");
            sb.Append(txtEmail.Text);
            sb.Append("<br><b>Dien thoai</b>:<br>");
            sb.Append(txtPhone.Text);
            sb.Append("<br><b>Gioi tinh</b>:<br>");
            sb.Append(rdolGender.SelectedValue);
            sb.Append("<br><b>Tieu de</b>:<br>");
            sb.Append(txtSubject.Text);
            sb.Append("<br><b>Content</b>:<br>");
            sb.Append(txtContent.Text);


            // new email solution start
            var email = new MailMessage(txtEmail.Text, contactEmail)
                            {
                                Subject = "Lien he tu khach hang ghe tham website",
                                IsBodyHtml = true,
                                Body = sb.ToString()
                            };

            var smtp = new SmtpClient
                           {
                               Host = AppEnv.MailServer.Length == 0 ? "localhost" : AppEnv.MailServer,
                               Port =
                                   AppEnv.MailServerPort.Length == 0 ? 25 : ConvertUtility.ToInt32(AppEnv.MailServerPort)
                           };



            // if authentication
            if (AppEnv.MailUsername.Length > 0 && AppEnv.MailPassword.Length > 0)
            {
                smtp.Credentials = new NetworkCredential(AppEnv.MailUsername, AppEnv.MailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            }
            // if authentication end

            var info = new MailInfo
                           {
                               Mail_Kind = "lienhe",
                               Mail_Name = HTMLUtility.SecureHTML(txtName.Text),
                               Mail_Email = HTMLUtility.SecureHTML(txtEmail.Text),
                               Mail_Phone = HTMLUtility.SecureHTML(txtPhone.Text),
                               Mail_Address = "",
                               Mail_Content = HTMLUtility.SecureHTML(txtContent.Text),
                               Pix_ID = 0,
                               Mail_Answer = ConvertUtility.ToBoolean(false),
                               Mail_Datetime = DateTime.Now
                           };

            MailDB.Insert(info);

            try
            {
                smtp.Send(email);
                notice.InnerHtml = "<br><br><br><font color=red><b>Email đã được gửi tới " + contactEmail + "...</b></font>";
            }
            catch (Exception ex)
            {
                notice.InnerHtml = "<br><br><br><font color=red><b>Email đã được gửi đi... Xin chân thành cảm ơn.</b></font>";
                ErrorReportDB.NewReport(Request.RawUrl, ex.ToString());
                //notice.InnerHtml = "<br><br><br><font color=red><b>Lỗi trong quá trình gửi mail...</b></font><br>" + ex.Message;
            }
            finally
            {
                pnform.Visible = false;
                notice.Visible = true;
            }
        }
    }
}