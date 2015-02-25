using System;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Active_Member : System.Web.UI.UserControl
    {
        private int _memberid;
        private string _activeCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            _memberid = ConvertUtility.ToInt32(Request.QueryString["mi"]);
            _activeCode = ConvertUtility.ToString(Request.QueryString["code"]);
            string notApprove = "Mã kích hoạt không hợp lệ, vui lòng kiểm tra email đăng ký để có mã kích hoạt hợp lệ.";

            if (_activeCode.Length >= 150)
            {
                notice.InnerHtml = notApprove;
                return;
            }

            var memberInfo = MemberDB.GetInfo(_memberid);

            if (memberInfo != null)
            {
                if (_activeCode == memberInfo.Member_ActiveCode)
                {
                    memberInfo.Member_Active = true;

                    MemberDB.Update(memberInfo);
                    notice.InnerHtml = "Chúc mừng bạn đã kích hoạt tài khoản thành công. Từ bây giờ bạn có thể đăng nhập và mua sắm cùng My-Deal.vn";
                }
                else
                {
                    notice.InnerHtml = notApprove;
                }
            }
            else
            {
                notice.InnerHtml = notApprove;
            }




        }
    }
}