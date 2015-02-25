using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.Solart;

namespace iDKCMS.FrontEnd.Project
{
    public partial class ClassRegister : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dt = DataHelper.GetDataFromTable("SELECT * FROM KhoaHocSolart");
                dtgClass.DataSource = dt;
                dtgClass.DataBind();

                dropCoso.DataSource = CosoDB.GetAll();
                dropCoso.DataTextField = "Coso_Name";
                dropCoso.DataValueField = "Coso_ID";
                dropCoso.DataBind();
            }
        }

        protected void dtgClass_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var litMonhoc = (Literal)e.Item.FindControl("litMonhoc");

                var monhocId = ConvertUtility.ToInt32(curData["Monhoc_ID"]);

                litMonhoc.Text = MonhocDB.GetNameByID(monhocId);
            }
        }

        protected void butSend_Click(object sender, EventArgs e)
        {
            var contactEmail = AppEnv.ContactEmail;

            if (txtHocsinhName.Text.Trim().Length == 0 || txtPhuHuynh.Text.Trim().Length == 0 || txtPhone.Text.Trim().Length == 0 || txtAddress.Text.Trim().Length == 0)
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
            sb.Append("<b>Ho ten hoc sinh</b>: ");
            sb.Append(txtHocsinhName.Text);
            sb.Append("<br><b>Ten phu huynh</b>: ");
            sb.Append(txtPhuHuynh.Text);
            sb.Append("<br><b>Email</b>: ");
            sb.Append(txtEmail.Text);
            sb.Append("<br><b>Dien thoai</b>:<br>");
            sb.Append(txtPhone.Text);
            sb.Append("<br><b>Dia chi</b>: ");
            sb.Append(txtAddress.Text);
            sb.Append("<br><b>Ngay sinh</b>:<br>");
            sb.Append(txtBirthday.Text);
            sb.Append("<br><b>Co so</b>:<br>");
            sb.Append(CosoDB.GetNameByID(ConvertUtility.ToInt32(dropCoso.SelectedValue)));
            sb.Append("<br><b>Ghi chu</b>:<br>");
            sb.Append(txtContent.Text);


            // new email solution start
            var email = new MailMessage(txtEmail.Text, contactEmail)
            {
                Subject = "Dang ky khoa hoc tu website",
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
                Mail_Name = HTMLUtility.SecureHTML(txtHocsinhName.Text),
                Mail_Email = HTMLUtility.SecureHTML(txtEmail.Text),
                Mail_Phone = HTMLUtility.SecureHTML(txtPhone.Text),
                Mail_Address = HTMLUtility.SecureHTML(txtAddress.Text),
                Mail_Content = HTMLUtility.SecureHTML(sb.ToString()),
                Pix_ID = 0,
                Mail_Answer = ConvertUtility.ToBoolean(false),
                Mail_Datetime = DateTime.Now
            };

            MailDB.Insert(info);

            try
            {
                smtp.Send(email);
                notice.InnerHtml = "<br><br><br><font color=red><b>Thông tin đăng ký đã được gửi tới " + contactEmail + "...</b></font>";
            }
            catch (Exception ex)
            {
                notice.InnerHtml = "<br><br><br><font color=red><b>Thông tin đăng ký đã được gửi đi... Xin chân thành cảm ơn.</b></font>";
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