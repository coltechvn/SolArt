using System;
namespace iDKCMS.Library.Data
{
    public class VideoInfo
    {
        public int Video_ID { get; set; }

        public string Video_Name { get; set; }

        public string Video_Description { get; set; }

        public string Video_Type { get; set; }

        public string Video_File { get; set; }

        public string Video_YouTube { get; set; }

        public int Video_Width { get; set; }

        public int Video_Height { get; set; }

        public DateTime Video_CreateDate { get; set; }

        public int Video_View { get; set; }

        public int User_ID { get; set; }

        public bool Video_Visible { get; set; }

    }
}
