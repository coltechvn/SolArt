using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd
{
    public partial class Default : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;
            LoadControls();
        }

        private void LoadControls()
        {
            string cmd = ConvertUtility.ToString(Request.QueryString["cmd"]);

            if (cmd == string.Empty)
            {
                placeControls.Controls.Add(LoadControl(AppEnv.ADMIN_PATH + "/UserControls/Core/WelCome.ascx"));
                return;
            }

            if ((cmd == "management") && (CurrentAdminInfo.User_Email == AppEnv.ADMIN_EMAIL))
            {
                placeControls.Controls.Add(LoadControl(AppEnv.ADMIN_PATH + "/UserControls/Core/CmdManager.ascx"));
                return;
            }
            if (cmd == "accessdeny")
            {
                placeControls.Controls.Add(LoadControl(AppEnv.ADMIN_PATH + "/UserControls/Core/AccessDeny.ascx"));
                return;
            }

            CmdInfo info = CmdDB.GetInfo(CmdDB.GetIDByCmd(cmd));
            if (info == null || !info.Cmd_Enable) Response.Redirect(AppEnv.ADMIN_ACCESSDENY);

            lblCommandName.Text = info.Cmd_Name;
            if ((!CurrentAdminInfo.User_SuperAdmin) && (!CmdRoleDB.CheckRole(CurrentAdminInfo.User_ID, info.Cmd_ID)))
                Response.Redirect(AppEnv.ADMIN_ACCESSDENY);

            string modulePath = AppEnv.ADMIN_PATH + info.Cmd_Path;

            //modulePath.Replace("//", "/");

            if (File.Exists(Server.MapPath(modulePath)))
            {
                placeControls.Controls.Add(LoadControl(modulePath));
                return;
            }

            modulePath = AppEnv.MODULE_PATH + info.Cmd_Path;

            ////modulePath.Replace("//", "/");

            //Response.Write(modulePath);
            //Response.End();

            if (File.Exists(Server.MapPath(modulePath)))
            {
                placeControls.Controls.Add(LoadControl(modulePath));
                return;
            }
            lblErrorMessage.Text = " Không tìm thấy module, kiểm tra lại đường dẫn !";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (litTitle != null) litTitle.Text = Title;
        }
    }
}