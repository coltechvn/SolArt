using System;
using System.Drawing;
using System.Drawing.Imaging;
using iDKCMS.Library;

namespace iDKCMS.FrontEnd
{
    public partial class BuildImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string image = Request.QueryString["image"];
            //thumbnail creation starts
            try
            {
                // dinh dang width height mac dinh de scale
                int smallWidth = ConvertUtility.ToInt32(Request.QueryString["width"]);
                int smallHeight = ConvertUtility.ToInt32(Request.QueryString["height"]);
                double scalesmall = 0;

                string imageUrl = Server.MapPath(image); // xac dinh anh chuan bi thumbnail

                Bitmap InputBitmap = new Bitmap(imageUrl); // tao anh bitmap

                // xac dinh % de resize
                if (smallHeight == 0)//InputBitmap.Height < InputBitmap.Width)
                {
                    scalesmall = ((double)smallWidth) / InputBitmap.Width;
                }

                int newSmallWidth;
                int newSmallHeight;
                if (smallHeight == 0)
                {
                    newSmallWidth = (int)(scalesmall * InputBitmap.Width);
                    newSmallHeight = (int)(scalesmall * InputBitmap.Height);
                }
                else
                {
                    newSmallWidth = smallWidth;
                    newSmallHeight = smallHeight;
                }

                Bitmap OutputBitmapSmall = new Bitmap(InputBitmap, newSmallWidth, newSmallHeight); // tao anh bitmap voi size small moi

                // xac dinh mime type
                Response.Clear();
                //Response.ContentType="image/Jpeg";

                //moi
                ImageCodecInfo[] Info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters Params = new EncoderParameters(1);
                Params.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                Response.ContentType = Info[1].MimeType;

                OutputBitmapSmall.Save(Response.OutputStream, Info[1], Params);

                // thuc hien
                OutputBitmapSmall.Dispose();
                InputBitmap.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred - " + ex);
            }
        }
    }
}