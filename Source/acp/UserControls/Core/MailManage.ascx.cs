using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
using iDKCMS.Library.WebBase;
namespace iDKCMS.BackEnd.UserControls.Core
{
    public partial class MailManage : AdminControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cklevel = CookieUtility.GetCookie("UserLevel");
            //if (ConvertUtility.ToInt32(cklevel) == 1)
            //{
            //    butDelAll.Enabled = false;
            //    butDellChecked.Enabled = false;
            //}
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string strSQL = "SELECT Main_Mail.* FROM Main_Mail ";

            if (dtgMail.SortBy == "") dtgMail.SortBy = "Mail_Datetime";
            strSQL += " ORDER BY " + dtgMail.SortBy + " " + dtgMail.OrderBy;

            DataTable source = DataHelper.GetDataFromTable(strSQL);

            int curPage = dtgMail.GetCurrentPageIndex() + 1;
            if (curPage > source.Rows.Count / dtgMail.PageSize + ConvertUtility.ToInt32(source.Rows.Count % dtgMail.PageSize > 0) && curPage > 1)
                dtgMail.CurrentPageIndex = 0;

            dtgMail.DataSource = source;
            dtgMail.DataBind();
            lblTotal.Text = "Total: " + source.Rows.Count;
        }

        protected void dtgMail_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "editrow")
            {
                try
                {
                    int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);

                    MailInfo info = MailDB.GetInfo(id);
                    CheckBox chkAnswer = (CheckBox)e.Item.FindControl("chkAnswer");

                    info.Mail_Answer = ConvertUtility.ToBoolean(chkAnswer.Checked);

                    MailDB.Update(info);
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch (Exception ex)
                {
                    lblUpdateStatus.Text = ex.ToString();
                }
            }
            if (e.CommandName == "delete")
            {
                int id = ConvertUtility.ToInt32(e.Item.Cells[0].Text);
                try
                {
                    MailDB.Delete(id);
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }

        protected void dtgMail_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView curData = (DataRowView)e.Item.DataItem;
                e.Item.Cells[2].Text = ConvertUtility.ToString(e.Item.DataSetIndex + 1);

                HyperLink lnkName = (HyperLink)e.Item.FindControl("lnkName");
                Literal litContent = (Literal)e.Item.FindControl("litContent");
                Label lblDatetime = (Label)e.Item.FindControl("lblDatetime");
                //				Image imgPix = (Image)e.Item.FindControl("imgPix");
                //				HyperLink lnkPix = (HyperLink)e.Item.FindControl("lnkPix");

                lnkName.NavigateUrl = "mailto:" + curData["Mail_Email"];
                lnkName.Text = curData["Mail_Name"].ToString();
                litContent.Text = HTMLUtility.ReplaceTag(curData["Mail_Content"].ToString());
                lblDatetime.Text = ConvertUtility.ToDateTime(curData["Mail_Datetime"]).ToString();

                //				int pixid = ConvertUtility.ToInt32(curData["Pix_ID"]);
                //				if(pixid == 0)
                //				{
                //					lnkPix.Visible = imgPix.Visible = false;
                //				}
                //				else
                //				{
                //					lnkPix.NavigateUrl = AppEnv.WEB_CMD + "pix" + "&pixid=" + pixid.ToString();
                //					lnkPix.Target = "_blank";
                //					string imgurl = DataHelper.GetFieldByID("Gallery_Pix", "Pix_Avatar", "Pix_ID", pixid).ToString();
                //					imgPix.ImageUrl = imgurl;
                //				}

                ImageButton btn_delete = (ImageButton)e.Item.FindControl("btn_delete");
                //ImageButton btn_updaterow = (ImageButton)e.Item.FindControl("btn_updaterow");
                btn_delete.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);

                //if (ConvertUtility.ToInt32(cklevel) == 1)
                //{
                //    btn_delete.Enabled = false;
                //    btn_updaterow.Enabled = false;
                //}

                e.Item.Attributes.Add("onmouseover", "this.className='Hoverrow';");
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                    e.Item.Attributes.Add("onmouseout", "this.className='DarkRow';");
                else
                    e.Item.Attributes.Add("onmouseout", "this.className='LightRow';");
            }
        }

        protected void butDellChecked_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dtgMail.Items)
                {
                    CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        int id = ConvertUtility.ToInt32(item.Cells[0].Text);
                        MailDB.Delete(id);
                    }
                }
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
            }
        }

        protected void butDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem item in dtgMail.Items)
                {
                    //					CheckBox chkSelect = (CheckBox)item.FindControl("chkSelect");
                    //					if(chkSelect.Checked)
                    //					{
                    int id = ConvertUtility.ToInt32(item.Cells[0].Text);
                    MailInfo info = MailDB.GetInfo(id);
                    CheckBox chkAnswer = (CheckBox)item.FindControl("chkAnswer");
                    info.Mail_Answer = ConvertUtility.ToBoolean(chkAnswer.Checked);
                    MailDB.Update(info);
                    //					}
                }
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
            }
        }
    }
}