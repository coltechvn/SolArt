using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace iDKCMS.Library
{
	public class MultimediaUtility
	{
		private static bool ThumbnailCallback()
		{
			return false;
		}

		public static bool SetThumbnail(string filePath, string newPath, int iThumbWidth, int iThumbHeight)
		{
			var fileInfo = new FileInfo(filePath);
			if (!fileInfo.Exists) return false;
			try
			{
				if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

				var myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
				var myBitmap = new Bitmap(fileInfo.FullName);

				if ((iThumbHeight == 0) && (iThumbWidth == 0)) return false;
				else if ((iThumbHeight != 0) && (iThumbWidth == 0))
					iThumbWidth = (int) (iThumbHeight*myBitmap.Width)/myBitmap.Height;
				else if ((iThumbHeight == 0) && (iThumbWidth != 0))
					iThumbHeight = (int) (iThumbWidth*myBitmap.Height)/myBitmap.Width;

                //Bitmap newImage = new Bitmap(newWidth, newHeight);
                //using (Graphics gr = Graphics.FromImage(newImage))
                //{
                //    gr.SmoothingMode = SmoothingMode.AntiAlias;
                //    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //    gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                //}


				var myThumbnail = myBitmap.GetThumbnailImage(iThumbWidth, iThumbHeight, myCallback, IntPtr.Zero);
                
				myThumbnail.Save(newPath + fileInfo.Name, ImageFormat.Png);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public static bool SetAvatarThumbnail(string filePath, int iThumbWidth, int iThumbHeight)
		{
			var fileInfo = new FileInfo(filePath);
			if (!fileInfo.Exists) return false;
			return SetThumbnail(filePath, fileInfo.Directory + "\\Avatar\\", iThumbWidth, iThumbHeight);
		}
		public static string GetAvatar(string avatar)
		{
			var splitIndex = avatar.LastIndexOf("/");
			if (splitIndex != 0)
				return avatar.Substring(0, splitIndex) + "/Avatar" + avatar.Substring(splitIndex, avatar.Length - splitIndex);
			else return string.Empty;

		}

        public static string strInitImage(string imgURL, int width, int height, string targetUrl, string target)
        {
            string retVal = "<a href=\"" + targetUrl + "\" ";
            //if (target.Length > 0) retVal += " target=\"" + target + "\"";
            retVal += "><img src=\"" + imgURL + "\" width=\"" + width + "\" alt=\"\" /></a>";

            return retVal;
        }

        public static string strInitImage(string imgURL, int width, int height, int advID, string target)
        {
            string retVal = "<a href=\"/ClickCounter.aspx?id=" + advID + "\" ";
            if (target.Length > 0) retVal += " target=\"" + target + "\"";
            retVal += ">";
            retVal += "<img src=\"" + imgURL + "\" alt=\"\" ";
            if (width > 0 && height > 0)
            {
                retVal += " width=\"" + width + "\" height=\"" + height + "\" ";
            }
            else if (width > 0 && height == 0)
            {
                retVal += " width=\"" + width + "\" ";
            }
            else if (width == 0 && height > 0)
            {
                retVal += " height=\"" + height + "\" ";
            }
            retVal += " /></a>";

            return retVal;
        }

        public static string strInitImage(string imgURL, int width, int height)
        {
            string retVal = "<img src=\"" + imgURL + "\" width=\"" + width + "\" alt=\"\" />";
            return retVal;
        }

        public static string strInitFlash(string flashURL, int width, int height)
        {
            string retVal = "<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" id=\"obj1\" ";
            retVal += " codebase =\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" " + " border=\"0\" ";
            if (width != 0) retVal += " width=" + width;
            if (height != 0) retVal += " height=" + height;
            retVal += ">";
            retVal += " <param name=\"movie\" value=\"" + flashURL + "\"> ";
            retVal += " <param name=\"quality\" value=\"High\"> ";
            retVal += "<embed src=\"" + flashURL + "\" ";
            retVal += " pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" name=\"obj1\" ";
            if (width != 0) retVal += " width=" + width;
            if (height != 0) retVal += " height=" + height;
            retVal += ">";
            retVal += "</object> ";
            return retVal;
        }

        public static string strInitMultimedia(string mediaPath, int width, int height)
        {
            string retVal = "<embed type='application/x-mplayer2' pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/Products/MediaPlayer/' ";
            retVal += " src='" + mediaPath + "' name='MediaPlayer2' showcontrols='1' showdisplay='0' showstatusbar='1' ";
            retVal += " autosize='True' enableContextMenu='true' animationatstart='0' transparentatstart='0' autostart='0' ";
            retVal += " loop='1' width='" + width + "' height='" + height + "'></embed> ";

            return retVal;
        }

        public static string ShowFlashAdv(string videoid, string mediaPath, int width, int height)
        {
            string retVal = "<p id=\"player" + videoid + "\"></p>";
            retVal += " <script type=\"text/javascript\"> ";
            retVal += " var s1 = new SWFObject(\"flvplayer.swf\",\"single\",\"" + width + "\",\"" + height + "\",\"7\"); ";
            retVal += " s1.addParam(\"allowfullscreen\",\"true\"); ";
            retVal += " s1.addVariable(\"file\",\"" + mediaPath + "\"); ";
            //retVal += " s1.addVariable(\"image\",\"" + avatar + "\"); ";
            retVal += " s1.addVariable(\"backcolor\",\"0xFFFFFF\"); ";
            retVal += " s1.addVariable(\"frontcolor\",\"0x000000\"); ";
            retVal += " s1.addVariable(\"lightcolor\",\"0x557722\"); ";
            retVal += " s1.addVariable(\"width\",\"" + width + "\"); ";
            retVal += " s1.addVariable(\"height\",\"" + height + "\"); ";
            retVal += " s1.write(\"player" + videoid + "\"); ";
            retVal += " </script> ";

            return retVal;
        }

        public static string ShowYouTuBeAdv(string youtubeEmbed, int width, int height)
        {
            string temp = Regex.Replace(youtubeEmbed, "width=\"([^\"]*?)\"", "width=\"" + width + "\"");
            string result = Regex.Replace(temp, "height=\"([^\"]*?)\"", "height=\"" + height + "\"");

            string retVal = result;

            return retVal;
        }

        public static string GetOriginalImage(string _image)
        {
            string newpath = _image.Replace("/Thumb/", "/Original/");

            return newpath;
        }

        public static string GetNormalImage(string _image)
        {
            string newpath = _image.Replace("/Thumb/", "/Normal/");

            return newpath;
        }
	}
}