using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Register_Member : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAgree.Checked)
                {
                    string email = txtEmail.Text.Trim();
                    string password = txtPassword.Text.Trim();
                    string confirmpassword = txtConfirmPassword.Text.Trim();
                    string fullname = txtFullName.Text.Trim();

                    if (ConvertUtility.ToInt32(MemberDB.GetIDByEmail(email)) > 0)
                    {
                        MessageBox.Show("Email này đã được sử dụng trên my-deal.vn");
                        return;
                    }


                    if (!MiscUtility.CheckEmail(email))
                    {
                        MessageBox.Show("Email đăng ký không hợp lệ");
                        return;
                    }
                    if (email.Length == 0 || password.Length == 0 || confirmpassword.Length == 0 || fullname.Length == 0)
                    {
                        MessageBox.Show("Bạn phải điền đầy đủ các trường yêu cầu (*)");
                        return;
                    }
                    if (password != confirmpassword)
                    {
                        MessageBox.Show("Bạn nhập lại mật khẩu không đúng");
                        return;
                    }

                    string newpassword = SecurityMethod.MD5Encrypt(password);

                    var memberInfo = new MemberInfo
                    {
                        Member_Email = email,
                        Member_Password = newpassword,
                        Member_Fullname = HTMLUtility.SecureHTML(fullname),
                        Member_Gender = 2,
                        Member_Avatar = "",
                        Member_Tel = "",
                        Member_Address = "",
                        Member_District = "",
                        Member_City = "",
                        Member_Rank = 0,
                        Member_Birthday = DateTime.Now,
                        Member_Active = false,
                        Member_ActiveCode = newpassword,
                        Member_IsForgotPassword = false
                    };

                    int memberid = MemberDB.Insert(memberInfo);

                    string activeUrl = "http://" + Request.Url.Host + AppEnv.WEB_CMD + "active&code=" + newpassword + "&mi=" + memberid;
                    string manuactiveUrl = "http://" + Request.Url.Host + AppEnv.WEB_CMD + "activemanual";

                    var sb = new StringBuilder();
                    sb.Append("Xin chao, ");
                    sb.Append(fullname);
                    sb.Append("<br /><br />Chao mung ban den voi My-Deal.vn!");
                    sb.Append("<br />De hoan tat thu tuc dang ky, ban hay click vao day de kich hoat tai khoan cua minh");
                    sb.Append("<br />");
                    sb.Append("<a href=\"" + activeUrl + "\">" + activeUrl + "</a>");
                    sb.Append("<br /><br />");
                    sb.Append("Hoac ban vao duong dan duoi day:");
                    sb.Append("<br />");
                    sb.Append(manuactiveUrl);
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("Va dien vao cac thong tin sau:");
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("MI: " + memberid);
                    sb.Append("<br />");
                    sb.Append("Ma kich hoat: " + newpassword);
                    sb.Append("<br />");
                    sb.Append("<br />");
                    sb.Append("Xin chan thanh cam on!");
                    sb.Append("<br />My-Deal.vn");

                    string adminEmail = AppEnv.ContactEmail;


                    // new email solution start
                    MailMessage emailmess = new MailMessage(adminEmail, email);
                    emailmess.Subject = "Kich hoat tai khoan tai My-Deal.vn";
                    emailmess.IsBodyHtml = true;
                    emailmess.Body = sb.ToString();

                    SmtpClient smtp = new SmtpClient();

                    if (AppEnv.MailServer.Length == 0)
                        smtp.Host = "localhost";
                    else
                        smtp.Host = AppEnv.MailServer;

                    if (AppEnv.MailServerPort.Length == 0)
                        smtp.Port = 25;
                    else
                        smtp.Port = ConvertUtility.ToInt32(AppEnv.MailServerPort);

                    // if authentication
                    if (AppEnv.MailUsername.Length > 0 && AppEnv.MailPassword.Length > 0)
                    {
                        smtp.Credentials = new NetworkCredential(AppEnv.MailUsername, AppEnv.MailPassword);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    }
                    // if authentication end

                    try
                    {
                        smtp.Send(emailmess);
                        notice.InnerHtml = "<br><br><br><font color=red><b>Email kích hoạt đã được gửi tới hòm thư " + email + ", vui lòng kiểm trả hòm thư đăng ký để hoàn tất thủ tục đăng ký.<br /><br />Xin chân thành cảm ơn</b></font>";
                    }
                    catch (Exception ex)
                    {
                        notice.InnerHtml = "<br /><br /><br /><font color=red><b>Email kích hoạt đã được gửi tới cho bạn, vui lòng kiểm tra hòm thư đăng ký để hoàn tất thủ tục đăng ký.<br /><br />Xin chân thành cảm ơn.</b></font>";
                        ErrorReportDB.NewReport(Request.RawUrl, ex.ToString());
                    }
                    finally
                    {
                        pnRegister.Visible = false;
                        notice.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải lựa chọn đồng ý với các điều khỏa của MyDeal");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}