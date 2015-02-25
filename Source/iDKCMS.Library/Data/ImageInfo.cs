using System;

namespace iDKCMS.Library.Data
{
    public class ImageInfo
    {
        public int Image_ID { get; set; }

        public string Image_Name { get; set; }

        public string Image_Description { get; set; }

        public string Image_File { get; set; }

        public DateTime Image_CreateDate { get; set; }

        public double Image_FileSize { get; set; }

        public int Image_Width { get; set; }

        public int Image_Height { get; set; }

        public int Image_View { get; set; }

        public int User_ID { get; set; }

        public bool Image_Visible { get; set; }

    }
}
