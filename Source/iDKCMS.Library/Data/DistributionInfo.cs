using System;

namespace iDKCMS.Library.Data
{
    public class DistributionInfo
    {
        public int Distribution_ID { get; set; }

        public int Distribution_ContentID { get; set; }

        public int Distribution_ZoneID { get; set; }

        public DateTime Distribution_CreateDate { get; set; }

        public int Distribution_Rank { get; set; }

        public int Distribution_View { get; set; }

        public int Distribution_Priority { get; set; }

        public string Distribution_Layout { get; set; }

        public bool Distribution_DisableTeaser { get; set; }

        public bool Distribution_DisableAvatar { get; set; }

    }
}
