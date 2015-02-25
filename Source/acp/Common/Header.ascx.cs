using System;
using System.Collections;
using System.Data;
using ComponentArt.Web.UI;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;

namespace iDKCMS.BackEnd.Common
{
    public partial class Header : AdminControl
    {
        private string arrCmdRoles, path, cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkMail.NavigateUrl = AppEnv.ADMIN_CMD + "mailmanager";
            lnkError.NavigateUrl = AppEnv.ADMIN_CMD + "errorreport";
            lnkOrder.NavigateUrl = AppEnv.ADMIN_CMD + "classregisterlist";

            cmd = ConvertUtility.ToString(Request.QueryString["cmd"]);
            GetPath();
            if (!CurrentAdminInfo.User_SuperAdmin) GetRoles();
            lblFullName.Text = CurrentAdminInfo.User_FullName;

            mnuCommands.Items.Clear();
            DataTable dtRoot = CmdDB.GetByParentID(0); // test
            foreach (DataRow row in dtRoot.Rows)
            {
                if ((row["Cmd_Value"].ToString() == "maincmdmanager") && (CurrentAdminInfo.User_Email != AppEnv.ADMIN_EMAIL)) continue;
                MenuItem rootItem = new MenuItem();
                rootItem.Text = row["Cmd_Name"].ToString();
                rootItem.ID = row["Cmd_ID"].ToString();
                rootItem.LookId = "TopItemLook";
                if (row["Cmd_Url"].ToString() != string.Empty)
                    rootItem.NavigateUrl = row["Cmd_Url"].ToString();
                else if (row["Cmd_Value"].ToString() != string.Empty)
                    rootItem.NavigateUrl = AppEnv.ADMIN_CMD + row["Cmd_Value"] + row["Cmd_Params"];

                if (path.IndexOf("|" + rootItem.ID + "|") >= 0) rootItem.Look.CssClass = "TopMenuItemHover";

                if ((row["Cmd_Visible"].ToString() == "False") || (row["Cmd_Enable"].ToString() == "False")) continue;
                else if (CurrentAdminInfo.User_SuperAdmin || (arrCmdRoles.IndexOf("|" + rootItem.ID + "|") >= 0)) mnuCommands.Items.Add(rootItem);
                LoadCmdItem(rootItem);
            }
        }

        private void GetRoles()
        {
            arrCmdRoles = "|";
            DataTable dtUserRoles = CmdRoleDB.GetAllRolesForUser(CurrentAdminInfo.User_ID);
            foreach (DataRow row in dtUserRoles.Rows)
                arrCmdRoles += row["Cmd_ID"] + "|";
        }

        private void GetPath()
        {
            path = "|";
            ArrayList titleArr = new ArrayList();

            if (cmd != string.Empty)
            {
                CmdInfo curCmd = CmdDB.GetInfoByCmd(cmd);
                while (curCmd != null)
                {
                    path += curCmd.Cmd_ID + "|";
                    titleArr.Add(curCmd.Cmd_Name);
                    curCmd = CmdDB.GetInfo(curCmd.Cmd_ParentID);
                }
            }

            string pageTitle = AppEnv.WebTitle + " - ";
            titleArr.Reverse();
            foreach (string item in titleArr) pageTitle += item + " - ";
            if (pageTitle.IndexOf(" - ") > 0) pageTitle = pageTitle.Substring(0, pageTitle.Length - 2);

            AdminPage page = (AdminPage)Page;
            page.Title = UnicodeUtility.UnicodeToKoDau(pageTitle);
        }

        private void LoadCmdItem(MenuItem curItem)
        {
            int curID = Convert.ToInt32(curItem.ID);
            DataTable dtChild = CmdDB.GetByParentID(curID);

            foreach (DataRow row in dtChild.Rows)
            {
                if ((row["Cmd_Value"].ToString() == "maincmdmanager") && (CurrentAdminInfo.User_Email != AppEnv.ADMIN_EMAIL)) continue;

                MenuItem childItem = new MenuItem();
                childItem.Text = row["Cmd_Name"].ToString();
                childItem.ID = row["Cmd_ID"].ToString();
                childItem.LookId = "DefaultItemLook";
                childItem.CssClass = "MenuItem";

                if (row["Cmd_Url"].ToString() != string.Empty)
                    childItem.NavigateUrl = row["Cmd_Url"].ToString();
                else if (row["Cmd_Value"].ToString() != string.Empty)
                    childItem.NavigateUrl = AppEnv.ADMIN_CMD + row["Cmd_Value"] + row["Cmd_Params"];
                if (path.IndexOf("|" + childItem.ID + "|") >= 0) childItem.Look.CssClass = "MenuItemHover";

                if ((row["Cmd_Visible"].ToString() == "False") || (row["Cmd_Enable"].ToString() == "False")) continue;
                else if (CurrentAdminInfo.User_SuperAdmin || (arrCmdRoles.IndexOf("|" + childItem.ID + "|") >= 0)) curItem.Items.Add(childItem);
                LoadCmdItem(childItem);

                if ((curItem.Items.Count > 0) && (curItem.ParentItem != null))
                {
                    curItem.Look.RightIconUrl = "/Administrator/images/iDK/arrow_small.gif";
                    curItem.Look.RightIconWidth = 15;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //DataTable sourceorder = DataHelper.GetDataFromTable("SELECT Order_ID FROM Main_Order WHERE Order_Status=0");
            //if (sourceorder.Rows.Count > 0)
            //    imgOrder.Visible = true;
            //else
                imgOrder.Visible = false;

            DataTable sourcemail = DataHelper.GetDataFromTable("SELECT Mail_ID FROM Main_Mail WHERE Mail_Answer=0");
            if (sourcemail.Rows.Count > 0)
                imgMail.Visible = true;
            else
                imgMail.Visible = false;

            DataTable source = ErrorReportDB.GetAll();//DataHelper.GetDataFromTable("Main_ErrorReport", "", "");
            if (source.Rows.Count > 0)
                imgError.Visible = true;
            else
                imgError.Visible = false;
        }

        protected void lnkSignout_Click(object sender, EventArgs e)
        {
            AuthenticateUtility.LogoutUser();
            Response.Redirect(Request.RawUrl);
        }
    }
}