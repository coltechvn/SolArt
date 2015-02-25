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
        private string _dotuoi = string.Empty;
        private string _monhoc = string.Empty;
        private string _coso = string.Empty;
        private string _lophoc = string.Empty;
        private int _khoahocid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dotuoi = ConvertUtility.ToString(Request.QueryString["dt"]);
            _monhoc = ConvertUtility.ToString(Request.QueryString["mh"]);
            _coso = ConvertUtility.ToString(Request.QueryString["cs"]);
            _lophoc = ConvertUtility.ToString(Request.QueryString["lh"]);
            _khoahocid = ConvertUtility.ToInt32(Request.QueryString["khoahocid"]);

            if (!IsPostBack)
            {
                MiscUtility.FillIndex(dropDay, 1, 31, DateTime.Now.Day);
                MiscUtility.FillIndex(dropMonth, 1, 12, DateTime.Now.Month);
                MiscUtility.FillIndex(dropYear, 1950, DateTime.Now.Year, DateTime.Now.Year);

                dropFilterMonHoc.DataSource = MonhocDB.GetAll();
                dropFilterMonHoc.DataTextField = "Monhoc_Name";
                dropFilterMonHoc.DataValueField = "Monhoc_ID";
                dropFilterMonHoc.DataBind();
                dropFilterMonHoc.Items.Insert(0, new ListItem("Chọn môn học", ""));

                dropFilterCoso.DataSource = CosoDB.GetAll();
                dropFilterCoso.DataTextField = "Coso_Name";
                dropFilterCoso.DataValueField = "Coso_ID";
                dropFilterCoso.DataBind();
                dropFilterCoso.Items.Insert(0, new ListItem("Chọn cơ sở", ""));

                ZoneUtility.LoadZonesByParentID(dropFilterLopHoc.Items, ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneKhoaHoc + AppEnv.GetLanguage())));
                dropFilterLopHoc.Items.Insert(0, new ListItem("Chọn lớp học", ""));

                MiscUtility.SetSelected(dropFilterDoTuoi.Items, _dotuoi);
                MiscUtility.SetSelected(dropFilterMonHoc.Items, _monhoc);
                MiscUtility.SetSelected(dropFilterLopHoc.Items, _lophoc);
                MiscUtility.SetSelected(dropFilterCoso.Items, _coso);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var sql = "SELECT Khoahoc_ID, Content_ID, Khoahoc_KhaiGiang, Zone_Name, Khoahoc_DoTuoiText, Khoahoc_DoTuoi, Khoehoc_NoiDungHoc, Khoahoc_GioHoc ";
            sql += "FROM KH ";
            sql += "WHERE 1=1 ";
            if(_khoahocid > 0)
            {
                sql += " AND Khoahoc_ID = " + _khoahocid + " ";
            }
            else
            {
                if (_dotuoi != "") sql += " AND Khoahoc_DoTuoi LIKE '%|" + ConvertUtility.ToInt32(_dotuoi) + "|%' ";
                if (_monhoc != "") sql += " AND Monhoc_ID = " + ConvertUtility.ToInt32(_monhoc) + " ";
                if (_coso != "") sql += " AND Coso_ID = " + ConvertUtility.ToInt32(_coso) + " ";
                if (_lophoc != "") sql += " AND Zone_ID = " + ConvertUtility.ToInt32(_lophoc) + " ";
            }
            sql += "GROUP BY Khoahoc_ID, Content_ID, Khoahoc_KhaiGiang, Zone_Name, Khoahoc_DoTuoiText, Khoahoc_DoTuoi, Khoehoc_NoiDungHoc, Khoahoc_GioHoc ";

            var dt = DataHelper.GetDataFromTable(sql);
            if(dt.Rows.Count > 0)
            {
                dtgClass.DataSource = dt;
                dtgClass.DataBind();
                divNotice.Visible = false;
            }
            else
            {
                divNotice.Visible = true;
                litNotice.Text = "Xin lỗi, hiện tại thông tin lớp học bạn đang cần tìm đang không tuyển sinh.<br /><br />Bạn có thể đăng ký vào danh sách chờ theo mẫu đơn bên dưới.<br />Chúng tôi sẽ liên hệ lại với bạn khi có lớp.<br /><br />Xin chân thành cảm ơn.";
            }
            
        }

        protected void dtgClass_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView)e.Item.DataItem;

                var litNoiDungHoc = (Literal)e.Item.FindControl("litNoiDungHoc");
                var litGioHoc = (Literal)e.Item.FindControl("litGioHoc");
                var litDotuoi = (Literal)e.Item.FindControl("litDotuoi");
                var litKhaiGiang = (Literal)e.Item.FindControl("litKhaiGiang");
                var litLophoc = (Literal)e.Item.FindControl("litLophoc");
                var rptCoso = (Repeater)e.Item.FindControl("rptCoso");
                var chkSelect = (CheckBox)e.Item.FindControl("chkSelect");

                var khoahocid = ConvertUtility.ToInt32(curData["Khoahoc_ID"]);

                if (khoahocid == _khoahocid) chkSelect.Checked = true;


                //var lophocId = ConvertUtility.ToInt32(curData["Zone_ID"]);
                litLophoc.Text = curData["Zone_Name"].ToString();//ZoneDB.GetZoneNameByID(lophocId);

                litKhaiGiang.Text = curData["Khoahoc_KhaiGiang"].ToString().Replace("\n", "<br />");
                litDotuoi.Text = curData["Khoahoc_DoTuoiText"].ToString().Replace("\n", "<br />");
                litNoiDungHoc.Text = curData["Khoehoc_NoiDungHoc"].ToString().Replace("\n", "<br />");
                litGioHoc.Text = curData["Khoahoc_GioHoc"].ToString().Replace("\n", "<br />");

                rptCoso.DataSource = KhoahocCosoDB.GetCosoDeployed(khoahocid);
                rptCoso.DataBind();
            }
        }

        protected void rptCoso_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var curData = (DataRowView) e.Item.DataItem;

                var litCoso = (Literal)e.Item.FindControl("litCoso");

                litCoso.Text = CosoDB.GetNameByID(ConvertUtility.ToInt32(curData["Coso_ID"]));
            }
        }

        protected void butSend_Click(object sender, EventArgs e)
        {
            var contactEmail = AppEnv.ContactEmail;

            var hocsinhname = txtHocsinhName.Text.Trim();
            var phuhuynhname = txtPhuHuynh.Text.Trim();
            var emailregister = txtEmail.Text.Trim();
            var phoneregister = txtPhone.Text.Trim();
            var addressregister = txtAddress.Text.Trim();
            var noteregister = txtContent.Text;


            if (hocsinhname.Length == 0 || phuhuynhname.Length == 0 || emailregister.Length == 0 || phoneregister.Length == 0 || addressregister.Length == 0)
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

            //insert db
            var hocsinhinfo = new HocsinhInfo();
            hocsinhinfo.Hocsinh_Name = hocsinhname;
            hocsinhinfo.Hocsinh_Parent = phuhuynhname;
            hocsinhinfo.Hocsinh_Email = emailregister;
            hocsinhinfo.Hocsinh_Tel = phoneregister;
            hocsinhinfo.Hocsinh_Address = addressregister;
            hocsinhinfo.Hocsinh_Birthday = dropDay.SelectedValue + "/" + dropMonth.SelectedValue + "/" +
                                           dropYear.SelectedValue;
            hocsinhinfo.Hocsinh_Note = noteregister;
            hocsinhinfo.Hocsinh_CreateDate = DateTime.Now;
            hocsinhinfo.Hocsinh_IsLearning = true;

            int hocsinhId = HocsinhDB.Insert(hocsinhinfo);

            var i = 0;

            foreach (DataGridItem item in dtgClass.Items)
            {
                var chkSelect = (CheckBox)item.FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    var id = ConvertUtility.ToInt32(item.Cells[0].Text);

                    var registerInfo = new HocsinhRegisterInfo();
                    registerInfo.Hocsinh_ID = hocsinhId;
                    registerInfo.Content_ID = id;
                    registerInfo.RegisterTime = DateTime.Now;

                    HocsinhRegisterDB.Insert(registerInfo);

                    i = 1 + 1;
                }
            }

            //noi dung mail

            var contentmail = string.Empty;
            if(i == 0)
            {
                contentmail = "Dang ky cho lop khai giang";
                contentmail += "<br /><br />" + noteregister;
            }
            else
            {
                contentmail = noteregister;
            }

            var sb = new StringBuilder();
            sb.Append("<b>Ho ten hoc sinh</b>: ");
            sb.Append(hocsinhname);
            sb.Append("<br /><b>Ten phu huynh</b>: ");
            sb.Append(phuhuynhname);
            sb.Append("<br /><b>Email</b>: ");
            sb.Append(emailregister);
            sb.Append("<br /><b>Dien thoai</b>:<br />");
            sb.Append(phoneregister);
            sb.Append("<br /><b>Dia chi</b>: ");
            sb.Append(addressregister);
            sb.Append("<br /><b>Ngay sinh</b>:<br />");
            sb.Append(dropDay.SelectedValue + "/" + dropMonth.SelectedValue + "/" + dropYear.SelectedValue);
            sb.Append("<br /><b>Thong tin them</b>:<br />");
            sb.Append(contentmail);


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
                notice.InnerHtml = "<br><br><br><font color=red><b>Thông tin đăng ký đã được gửi tới " + contactEmail + "...<br />Chúng tôi sẽ liên hệ lại trong thời gian ngắn nhất.<br />Xin chân thành cảm ơn.</b></font>";
            }
            catch (Exception ex)
            {
                notice.InnerHtml = "<br><br><br><font color=red><b>Thông tin đăng ký đã được gửi đi...<br />Chúng tôi sẽ liên hệ lại trong thời gian ngắn nhất.<br />Xin chân thành cảm ơn.</b></font>";
                ErrorReportDB.NewReport(Request.RawUrl, ex.ToString());
                //notice.InnerHtml = "<br><br><br><font color=red><b>Lỗi trong quá trình gửi mail...</b></font><br>" + ex.Message;
            }
            finally
            {
                pnform.Visible = false;
                notice.Visible = true;
            }
        }

        protected void butSearch_Click(object sender, EventArgs e)
        {
            var dotuoi = dropFilterDoTuoi.SelectedValue;
            var monhoc = dropFilterMonHoc.SelectedValue;
            var coso = dropFilterCoso.SelectedValue;
            var lophoc = dropFilterLopHoc.SelectedValue;

            Response.Redirect(UrlFilter.BuildUrlByZoneID(ConvertUtility.ToInt32(SettingDB.GetValue(AppEnv.CMS_ZoneClassRegister + AppEnv.GetLanguageFrontEnd()))) + "&dt=" + dotuoi + "&mh=" + monhoc + "&cs=" + coso + "&lh=" + lophoc, true);
        }
    }
}