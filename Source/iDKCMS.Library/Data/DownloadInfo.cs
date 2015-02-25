using System;
namespace iDKCMS.Library.Data
{
    public class DownloadInfo
    {
        public int Download_ID { get; set; }

        public string Download_Name { get; set; }

        public string Download_Description { get; set; }

        public string Download_File { get; set; }

        public string Download_Extension { get; set; }

        public bool Download_Visible { get; set; }

        public DateTime Download_CreateDate { get; set; }

        public double Download_FileSize { get; set; }

        public int Download_View { get; set; }

        public int User_ID { get; set; }

    }
}
