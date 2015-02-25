using System;

namespace iDKCMS.Library.Data
{
    public class ContentInfo
    {
        public int Content_ID { get; set; }

        public string Content_Name { get; set; }

        public string Content_Teaser { get; set; }

        public string Content_Body { get; set; }

        public DateTime Content_CreateDate { get; set; }

        public DateTime Content_ModifiedDate { get; set; }

        public int Content_Status { get; set; }

        public int Content_OriginalZoneID { get; set; }

        public int Content_UserID { get; set; }

        public int Content_ModifiedUserID { get; set; }

        public string Content_Author { get; set; }

        public DateTime Content_EventDate { get; set; }

        public string Content_FriendlyUrl { get; set; }

        public string Content_Comment { get; set; }

        public bool Content_ExcludeFromSearch { get; set; }

        public bool Content_IsPhoto { get; set; }

        public bool Content_IsDownload { get; set; }

        public bool Content_IsVideo { get; set; }

        public bool Content_IsPoll { get; set; }

        public bool Content_IsProduct { get; set; }

        public bool Content_Visible { get; set; }

        public bool Content_IsTemp { get; set; }

    }
}
