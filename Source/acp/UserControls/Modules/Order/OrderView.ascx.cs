using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.BackEnd.UserControls.Modules.Order
{
    public partial class OrderView : System.Web.UI.UserControl
    {
        private int _orderid;
        protected void Page_Load(object sender, EventArgs e)
        {
            _orderid = ConvertUtility.ToInt32(Request.QueryString["orderid"]);
            if (_orderid == 0) return;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            OrderInfo info = OrderDB.GetInfo(_orderid);
            if (info == null) return;

            lblID.Text = info.Order_ID.ToString();
            lblDateTime.Text = ConvertUtility.ToDateTime(info.Order_CreateDate).ToString("dd/MM/yyyy HH:mm");
            lnkFullname.Text = info.Order_Fullname;
            lnkFullname.NavigateUrl = AppEnv.ADMIN_CMD + "memberupdate&memberid=" + info.Member_ID;
            lblEmail.Text = info.Order_Email;
            lblPhone.Text = info.Order_Tel;
            lblAddress.Text = info.Order_Address.Replace("\n", "<br>");
            lblDistrict.Text = info.Order_District;
            lblCity.Text = info.Order_City;
            lblContent.Text = info.Order_Note.Replace("\n", "<br>");
            MiscUtility.SetSelected(dropStatus.Items, info.Order_Status.ToString());
            lblQuantity.Text = ConvertUtility.ToInt32(info.Order_Quantity).ToString();
            lblPrice.Text = String.Format("{0:0,0}", info.Order_Price) + " VNÐ";

            dtlProduct.DataSource = OrderDB.GetProductByOrderID(_orderid);
            dtlProduct.DataBind();
        }

        protected void dtlProduct_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView curData = (DataRowView)e.Item.DataItem;

                HyperLink lnkName = (HyperLink)e.Item.FindControl("lnkName");
                var imgAvatar = (Image)e.Item.FindControl("imgAvatar");
                Label lblProductPrice = (Label)e.Item.FindControl("lblProductPrice");
                var txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                Label lblPriceSum = (Label)e.Item.FindControl("lblPriceSum");
                var butRowUpdate = (Button)e.Item.FindControl("butRowUpdate");
                var butRowDelete = (Button)e.Item.FindControl("butRowDelete");

                lnkName.Text = curData["Content_Name"].ToString();
                lblProductPrice.Text = String.Format("{0:0,0}", curData["Price"]) + " VNÐ";
                txtQuantity.Text = curData["Quantity"].ToString();
                lblPriceSum.Text = String.Format("{0:0,0}", curData["PriceSum"]) + " VNÐ";

                butRowDelete.CommandArgument =
                    butRowUpdate.CommandArgument = ConvertUtility.ToString(curData["Content_ID"]);

                var coverInfo = ImageDB.GetCover(ConvertUtility.ToInt32(curData["Content_ID"]));
                if (coverInfo != null)
                {
                    string avatar = coverInfo.Image_File;
                    if (avatar.Length > 0)
                    {
                        imgAvatar.ImageUrl = avatar;
                    }
                    else
                    {
                        imgAvatar.Visible = false;
                    }
                }
                else
                {
                    imgAvatar.Visible = false;
                }
            }
        }

        protected void butCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.ADMIN_CMD + "orderlist");
        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            int orderid = ConvertUtility.ToInt32(Request.QueryString["orderid"]);
            try
            {
                OrderDB.Delete(orderid);
                Response.Redirect(AppEnv.ADMIN_CMD + "orderlist");
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void butUpdate_Click(object sender, EventArgs e)
        {
            int orderid = ConvertUtility.ToInt32(Request.QueryString["orderid"]);
            OrderInfo info = OrderDB.GetInfo(orderid);
            info.Order_Status = ConvertUtility.ToInt32(dropStatus.SelectedValue);
            try
            {
                OrderDB.Update(info);
                lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
            }
            catch
            {
                lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
            }
        }

        protected void dtlProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                var contentid = ConvertUtility.ToInt32(e.CommandArgument);
                try
                {
                    var orderProductInfo = OrderProductDB.GetInfo(_orderid, contentid);
                    var deletePriceSum = orderProductInfo.PriceSum;


                    OrderProductDB.Delete(_orderid, contentid);

                    var orderInfo = OrderDB.GetInfo(_orderid);

                    orderInfo.Order_Quantity = orderInfo.Order_Quantity - 1;
                    orderInfo.Order_Price = orderInfo.Order_Price - deletePriceSum;

                    OrderDB.Update(orderInfo);

                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                }
                catch
                {
                    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR;
                }
            }
            if (e.CommandName == "updaterow")
            {
                //try
                //{
                    var contentid = ConvertUtility.ToInt32(e.CommandArgument);

                    var txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");

                    var orderProductInfo = OrderProductDB.GetInfo(_orderid, contentid);

                    var newQuantity = ConvertUtility.ToInt32(txtQuantity.Text);
                    var newPriceSum = orderProductInfo.Price*newQuantity;
                    var balancePrice = orderProductInfo.PriceSum - newPriceSum;

                    orderProductInfo.Quantity = newQuantity;
                    orderProductInfo.PriceSum = newPriceSum;

                    OrderProductDB.Update(orderProductInfo);

                    var orderInfo = OrderDB.GetInfo(_orderid);

                    orderInfo.Order_Price = orderInfo.Order_Price - balancePrice;

                    OrderDB.Update(orderInfo);

                    lblUpdateStatus.Text = MiscUtility.UPDATE_SUCCESS;
                //}
                //catch
                //{
                //    lblUpdateStatus.Text = MiscUtility.UPDATE_ERROR; //ex.ToString();
                //}
            }
        }
    }
}