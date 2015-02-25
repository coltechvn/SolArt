using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using CommonLibrary.CartShopping;
using iDKCMS.Library;
using iDKCMS.Library.Data;
using iDKCMS.Library.DataAccess;
//using iDKCMS.Library.Mydeal;

namespace iDKCMS.FrontEnd.UserControls
{
    public partial class Cart : System.Web.UI.UserControl
    {
        protected int totalProducts = 0;
        protected float totalPrice = 0;

        private int contentid;

        protected void Page_Load(object sender, EventArgs e)
        {
            contentid = ConvertUtility.ToInt32(Request.QueryString["productid"]);

            string returnurl = ConvertUtility.ToString(Request.QueryString["returnurl"]);

            if (!string.IsNullOrEmpty(returnurl))
                lnkReturn.NavigateUrl = returnurl;
            else
                lnkReturn.NavigateUrl = "/";

            CommonLibrary.CartShopping.Cart cart = null;

            object obj = Session["cart"];
            if (obj == null)
            {
                cart = new CommonLibrary.CartShopping.Cart();
                Session["cart"] = cart;
            }
            else
            {
                cart = (CommonLibrary.CartShopping.Cart)obj;
            }
            var justLogged = ConvertUtility.ToInt32(Request.QueryString["jl"]);
            if(justLogged == 0)
            {
                if (!Page.IsPostBack)
                {
                    //ViewState["urlreference"] = Request.UrlReferrer.AbsoluteUri;
                    if (contentid > 0)
                    {
                        var name = ConvertUtility.ToString(ContentDB.GetName(contentid));
                        /****************** project
                        var mdInfo = MydealItemDB.GetInfo(contentid);

                        if (mdInfo != null)
                        {
                            var item = new CartItem();
                            item.Name = name;
                            item.Price = Convert.ToSingle(mdInfo.Mydeal_Price);
                            item.ID = contentid;
                            item.Quantity = 1;
                            cart.Items.Add(item);
                        }

                         */
                    }
                }
            }
            pnPayment.Visible = false;
            notice.Visible = true;

            if (CookieUtility.GetCookie("Member_Email") != null)
            {
                if (MemberDB.GetIDByEmail(CookieUtility.GetCookie("Member_Email")) != 0)
                {
                    MemberInfo info = MemberDB.GetInfoByEmail(CookieUtility.GetCookie("Member_Email"));
                    if (info != null)
                    {
                        pnPayment.Visible = true;
                        notice.Visible = false;

                        txtFullName.Text = info.Member_Fullname;
                        txtTel.Text = info.Member_Tel;
                        txtAddress.Text = info.Member_Address;
                        txtDistrict.Text = info.Member_District;
                        txtCity.Text = info.Member_City;
                    }
                }
            }

            
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            CommonLibrary.CartShopping.Cart cart = (CommonLibrary.CartShopping.Cart)Session["cart"];
            if (cart != null)
            {
                rptCart.DataSource = cart.DataView;
                rptCart.DataBind();

                dtgProduct.DataSource = cart.DataView;
                dtgProduct.DataBind();

                //totalProducts = cart.Items.Count;
                litTotalPrice.Text = string.Format("{0:0,0}", cart.TotalPrice) + " VNĐ";
            }
        }

        protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView curData = (DataRowView)e.Item.DataItem;

                Literal litName = (Literal)e.Item.FindControl("litName");
                //Literal litIndex = (Literal)e.Item.FindControl("litIndex");
                Literal litRetailPrice = (Literal)e.Item.FindControl("litRetailPrice");
                Literal litPrice = (Literal)e.Item.FindControl("litPrice");
                //Literal litQuantity = (Literal)e.Item.FindControl("litQuantity");
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                LinkButton lnkUpdate = (LinkButton)e.Item.FindControl("lnkUpdate");
                LinkButton lnkRemove = (LinkButton)e.Item.FindControl("lnkRemove");


                double price = ConvertUtility.ToDouble(curData["Price"]);
                int quantity = ConvertUtility.ToInt32(curData["Quantity"]);
                double pricesum = ConvertUtility.ToDouble(price * quantity);

                //litIndex.Text = ConvertUtility.ToString(e.Item.ItemIndex + 1);
                litName.Text = curData["Name"].ToString();
                txtQuantity.Text = quantity.ToString();
                txtQuantity.Attributes.Add("style", "text-align: center;");

                litRetailPrice.Text = string.Format("{0:0,0}", price) + " VND";
                litPrice.Text = string.Format("{0:0,0}", pricesum) + " VND";


                if (AppEnv.GetLanguage() == "en-US")
                {
                    lnkRemove.Text = "Delete";
                    lnkUpdate.Text = "Update";
                }
            }
        }

        protected void rptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
            int id = int.Parse((string)e.CommandArgument);
            CommonLibrary.CartShopping.Cart cart = (CommonLibrary.CartShopping.Cart)Session["cart"];
            int count = cart.Items.Count;

            if (e.CommandName == "update")
            {
                for (int i = 0; i < count; i++)
                {
                    if ((cart.Items[i] as CartItem).ID == id)
                    {
                        (cart.Items[i] as CartItem).Quantity = int.Parse(txtQuantity.Text);
                        break;
                    }
                }
            }
            else if (e.CommandName == "delete")
            {
                for (int i = 0; i < count; i++)
                {
                    if ((cart.Items[i] as CartItem).ID == id)
                    {
                        cart.Items.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public string GetHtmlPage(string strURL)
        {
            // the html retrieved from the page
            //String strResult;
            //WebResponse objResponse;
            //WebRequest objRequest = HttpWebRequest.Create(strURL);




            //objResponse = objRequest.GetResponse();
            //// the using keyword will automatically dispose the object 
            //// once complete
            //using (StreamReader sr =
            //           new StreamReader(objResponse.GetResponseStream()))
            //{
            //    strResult = sr.ReadToEnd();
            //    // Close and clean up the StreamReader
            //    sr.Close();
            //}
            //return strResult;

            String strResult;

            //WebClient objWebClient = new WebClient();
            //objWebClient.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

            //strResult = objWebClient.DownloadString(strURL);

            var filename = Server.MapPath(strURL);

            var objStreamReader = File.OpenText(filename);

            strResult = objStreamReader.ReadToEnd();


            return strResult;

        }

        protected void butSubmit_Click(object sender, EventArgs e)
        {
            if(chkAgree.Checked)
            {
                var fullname = HTMLUtility.SecureHTML(txtFullName.Text.Trim());
                var tel = HTMLUtility.SecureHTML(txtTel.Text.Trim());
                var address = HTMLUtility.SecureHTML(txtAddress.Text.Trim());
                var district = HTMLUtility.SecureHTML(txtDistrict.Text.Trim());
                var city = HTMLUtility.SecureHTML(txtCity.Text.Trim());
                var note = HTMLUtility.SecureHTML(txtNote.Text.Trim());
                var orderdate = DateTime.Now;


                if (fullname.Length == 0 || tel.Length == 0 || address.Length == 0 || district.Length == 0 || city.Length == 0)
                {
                    MessageBox.Show("Bạn phải điền đủ các trường (*)");
                    return;
                }

                

                var cart = (CommonLibrary.CartShopping.Cart)Session["cart"];

                string email = CookieUtility.GetCookie("Member_Email");

                var totalprice = cart.TotalPrice;

                var memberInfo = MemberDB.GetInfoByEmail(email);
                if (memberInfo.Member_Fullname.Length == 0) memberInfo.Member_Fullname = fullname;
                if (memberInfo.Member_Tel.Length == 0) memberInfo.Member_Tel= tel;
                if (memberInfo.Member_Address.Length == 0) memberInfo.Member_Address= address;
                if (memberInfo.Member_District.Length == 0) memberInfo.Member_District= district;
                if (memberInfo.Member_City.Length == 0) memberInfo.Member_City= city;

                MemberDB.Update(memberInfo);

                var info = new OrderInfo();

                info.Member_ID = MemberDB.GetIDByEmail(email);
                info.Order_Fullname = fullname;
                info.Order_Email = email;
                info.Order_Tel = tel;
                info.Order_Address = address;
                info.Order_District = district;
                info.Order_City = city;
                info.Order_Note = note;
                info.Order_CreateDate = orderdate;
                info.Order_Status = 0;
                info.Order_Price = ConvertUtility.ToDouble(totalprice);
                info.Order_Quantity = ConvertUtility.ToInt32(cart.Items.Count);

                var orderid = OrderDB.Insert(info);

                var sbProducts = new StringBuilder();

                sbProducts.Append("<tr>");

                foreach (DataGridItem item in dtgProduct.Items)
                {
                    var id = ConvertUtility.ToInt32(item.Cells[0].Text);
                    var quantity = ConvertUtility.ToInt32(item.Cells[1].Text);
                    var price = ConvertUtility.ToInt32(item.Cells[2].Text);
                    var sum = price * quantity;
                    var oinfo = new OrderProductInfo();


                    oinfo.Order_ID = orderid;
                    oinfo.Content_ID = id;
                    oinfo.Quantity = quantity;
                    oinfo.Price = price;
                    oinfo.PriceSum = sum;

                    OrderProductDB.Insert(oinfo);

                    sbProducts.Append("<td style=\"padding: 4px; border: 1px #b1d1e6 solid; text-align: center;\">" + item.ItemIndex + 1 + "</td>");
                    sbProducts.Append("<td style=\"padding: 4px; border: 1px #b1d1e6 solid;\">" + ContentDB.GetName(id) + "</td>");
                    sbProducts.Append("<td style=\"padding: 4px; border: 1px #b1d1e6 solid; text-align: center;\">" + quantity + "</td>");
                    sbProducts.Append("<td style=\"padding: 4px; border: 1px #b1d1e6 solid; text-align: center;\">" + string.Format("{0:0,0}", price) + "</td>");
                    sbProducts.Append("<td style=\"padding: 4px; border: 1px #b1d1e6 solid; text-align: center;\">" + string.Format("{0:0,0}", sum) + "</td>");
                }

                sbProducts.Append("</tr>");

                string emailadd = AppEnv.ContactEmail;

                var sb = new StringBuilder();
                sb.Append("Ban co don dat hang #" + orderid + " tu My-Deal.vn:");
                sb.Append("<br><br><b>Ten</b>: ");
                sb.Append(fullname);
                sb.Append("<br><b>Email</b>: ");
                sb.Append(email);
                sb.Append("<br><b>Dien thoai</b>: ");
                sb.Append(tel);
                sb.Append("<br><b>Dia chi</b>: ");
                sb.Append(txtAddress.Text);
                sb.Append("<br><b>Noi dung</b>:<br>");
                sb.Append(txtNote.Text);
                sb.Append("<br><br>-----------------------------<br>De biet thong tin chi tiet don hang, hay dang nhang vao website<br>");

                // new email solution start

                MailMessage emailmess = new MailMessage(email, emailadd);
                emailmess.Subject = "Don dat hang cua khach hang tu website";
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

                // gui cho khach hang thong tin deal

                var emailForCusContent = "";

                //try
                //{
                    const string templateUrl = "/templates/deal_confirm.htm";
                    var htmlpage = GetHtmlPage(templateUrl);
                    if (htmlpage != "NULL")
                    {
                        emailForCusContent = htmlpage;
                    }
                //}
                //catch
                //{
                //    ErrorReportDB.NewReport(Request.RawUrl, "Thong tin CK HOSE:" + DateTime.Now);
                //}

                emailForCusContent = emailForCusContent.Replace("[[order_id]]", orderid.ToString()).Replace("[[order_datetime]]", orderdate.ToString("dd/MM/yyyy HH:mm")).Replace("[[order_note]]", note).Replace("[[order_products]]", sbProducts.ToString()).Replace("[[order_pricesum]]", string.Format("{0:0,0}", totalprice) + " VNĐ").Replace("[[order_fullname]]", fullname).Replace("[[order_address]]", address).Replace("[[order_tel]]", tel);

                // new email solution start
                var emailmess2 = new MailMessage(emailadd, email);
                emailmess2.Subject = "[My-deal.vn] Thong tin dat hang #" + orderid;
                emailmess2.IsBodyHtml = true;
                emailmess2.Body = emailForCusContent;

                var smtp2 = new SmtpClient();

                if (AppEnv.MailServer.Length == 0)
                    smtp2.Host = "localhost";
                else
                    smtp2.Host = AppEnv.MailServer;

                if (AppEnv.MailServerPort.Length == 0)
                    smtp2.Port = 25;
                else
                    smtp2.Port = ConvertUtility.ToInt32(AppEnv.MailServerPort);

                // if authentication
                if (AppEnv.MailUsername.Length > 0 && AppEnv.MailPassword.Length > 0)
                {
                    smtp2.Credentials = new NetworkCredential(AppEnv.MailUsername, AppEnv.MailPassword);
                    smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                }
                // if authentication end

                try
                {
                    smtp.Send(emailmess);

                    smtp2.Send(emailmess2);
                    notice.InnerHtml = "<br><br><br><font color=black><b>Đơn đặt hàng của bạn đã được gửi tới " + emailadd + ".Chúng tôi sẽ liên hệ với bạn trong thời gian ngắn nhất<br /><br />Xin chân thành cảm ơn!</b></font>";
                }
                catch (Exception z)
                {
                    notice.InnerHtml =
                        "<br><br><br><font color=black><b>Đơn đặt hàng của bạn đã được gửi đi..Chúng tôi sẽ liên hệ với bạn trong thời gian ngắn nhất<br /><br />Xin chân thành cảm ơn!</b></font><br>";
                }
                finally
                {
                    pnPayment.Visible = false;
                    notice.Visible = true;
                    SessionUtility.Remove("cart");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần phải đồng ý với điều khoản của My-Deal.vn");
            }
        }
    }
}