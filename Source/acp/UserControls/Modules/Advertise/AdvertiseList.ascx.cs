using System;
using System.Data;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.Advertise
{
    public partial class AdvertiseList : System.Web.UI.UserControl
    {
        private int PosSelected
        {
            get
            {
                if (Session["PosSelected"] != null)
                    return (int)Session["PosSelected"];
                else return 0;
            }
            set
            {
                Session["PosSelected"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ConvertUtility.ToBoolean(AppEnv.AdvInZone)) { ZoneUtility.LoadZones(lstZones.Items); lstZones.Enabled = true; }
                else lstZones.Enabled = false;
                lstZones.Items.Insert(0, new ListItem("Root 0", "0"));
                lstZones.SelectedIndex = 0;

                lstPositions.DataSource = PositionDB.GetAll();
                lstPositions.DataTextField = "Pos_Name";
                lstPositions.DataValueField = "Pos_ID";
                lstPositions.DataBind();
                lstPositions.SelectedIndex = -1;
                MiscUtility.SetSelected(lstPositions.Items, PosSelected.ToString());
            }
            lblUpdateStatus.Text = string.Empty;
        }

        protected void cmdAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.ADMIN_CMD + "advertiseupdate");
        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            if (lstPositions.SelectedItem == null) return;
            PosSelected = ConvertUtility.ToInt32(lstPositions.SelectedValue);
            string location = string.Empty;
            foreach (ListItem item in lstZones.Items) if (item.Selected) location += item.Value + "|";
            DataTable source = AdvertiseDB.GetByPositionID(PosSelected, chkEnable.Checked, location);
            dtgAdvertises.DataSource = source;
            dtgAdvertises.DataBind();
        }

        protected void dtgAdvertises_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            string locations = "|" + curData["Advertise_Params"];
            //string strLocation = string.Empty;
            //foreach (ListItem item in lstZones.Items)
            //{
            //    if (locations.IndexOf("|" + item.Value + "|") >= 0)
            //        strLocation += item.Text + "<br>";
            //}
            //e.Item.Cells[2].Text = strLocation;

            Literal litUrl = (Literal)e.Item.FindControl("litUrl");
            switch (curData["Advertise_Type"].ToString())
            {
                case "flash":
                    litUrl.Text = MultimediaUtility.strInitFlash(curData["Advertise_Path"].ToString(), Convert.ToInt32(curData["Advertise_Width"]), Convert.ToInt32(curData["Advertise_Height"]));
                    break;
                case "media":
                    litUrl.Text = MultimediaUtility.strInitMultimedia(curData["Advertise_Path"].ToString(), Convert.ToInt32(curData["Advertise_Width"]), Convert.ToInt32(curData["Advertise_Height"]));
                    break;
                case "other":
                    litUrl.Text = curData["Advertise_Path"].ToString();
                    break;
                case "image":
                    if (curData["Advertise_Path"].ToString() != string.Empty)
                        litUrl.Text = "<img src='" + curData["Advertise_Path"] + "' width='120'></img>";
                    break;
            }
            litUrl.Text += "<br><a href='" + curData["Advertise_RedirectURL"] + "'>" + curData["Advertise_Name"] + "</a>";
            Button cmdDel = (Button)e.Item.FindControl("cmdDel");
            cmdDel.Attributes.Add("onclick", MiscUtility.DELETE_CONFIRM);
            DropDownList dropPriority = (DropDownList)e.Item.FindControl("dropPriority");
            MiscUtility.FillIndex(dropPriority, 0, 20, ConvertUtility.ToInt32(curData["Advertise_Priority"]));
        }

        protected void dtgAdvertises_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect(AppEnv.ADMIN_CMD + "advertiseupdate&advertiseid=" + e.Item.Cells[0].Text);
            }
            if (e.CommandName == "del")
            {
                try
                {
                    AdvertiseDB.Delete(ConvertUtility.ToInt32(e.Item.Cells[0].Text));
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                    cmdSearch_Click(null, null);
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "priority")
            {
                try
                {
                    foreach (DataGridItem item in dtgAdvertises.Items)
                    {
                        DropDownList dropPriority = (DropDownList)item.FindControl("dropPriority");
                        AdvertiseDB.SetPriority(ConvertUtility.ToInt32(item.Cells[0].Text), ConvertUtility.ToInt32(dropPriority.SelectedValue));
                    }
                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                    cmdSearch_Click(null, null);
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
        }
    }
}