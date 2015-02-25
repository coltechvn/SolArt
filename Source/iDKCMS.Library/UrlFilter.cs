using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library
{
    public class UrlFilter
    {
        public static string BuildUrlByZoneID(int _zoneid)
        {
            return AppEnv.WEB_CMD + "zone" + "&zoneid=" + _zoneid;
        }

        public static string BuildUrlByItemID(int _itemid)
        {
            return AppEnv.WEB_CMD + "content" + "&itemid=" + _itemid;
        }

        public static string BuildImageUrl(string _image, int _width, int _height)
        {
            return "/BuildImage.aspx?image=" + _image + "&width=" + _width + "&height=" + _height;
        }
        public static string BuildImageDoc(string _image, int _width, int _width2)
        {
            return "/ImageDoc.aspx?image=" + _image + "&width=" + _width + " &width2=" + _width2;
        }
        public static string BuildImageScaleHeight(string _image, int _width, int _height)
        {
            return "/ImageScaleHeight.aspx?image=" + _image + "&width=" + _width + " &height=" + _height;
        }

        public static string PrintUrlByZoneID(int _itemid)
        {
            return "/PrintPage.aspx?itemid=" + _itemid;
        }
    }
}