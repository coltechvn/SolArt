namespace iDKCMS.Library.Data
{
    public class ZoneInfo
    {
        public int Zone_ID { get; set; }

        public int Zone_ParentID { get; set; }

        public string Zone_Name { get; set; }

        public string Zone_Description { get; set; }

        public string Zone_FriendlyUrl { get; set; }

        public string Zone_RealUrl { get; set; }

        public string Zone_Avatar { get; set; }

        public int Zone_Priority { get; set; }

        public string Zone_MetaDescription { get; set; }

        public string Zone_MetaKeywords { get; set; }

        public string Zone_Layout { get; set; }

        public string Zone_SubcategoryDisplay { get; set; }

        public string Zone_ContentListingDisplay { get; set; }

        public bool Zone_VisibleInMainNav { get; set; }

        public bool Zone_VisibleInLeftNav { get; set; }

        public bool Zone_VisibleInTopNav { get; set; }

        public bool Zone_VisibleInFooterNav { get; set; }

        public bool Zone_ExcludeFromNav { get; set; }

        public bool Zone_Visible { get; set; }

        public bool Zone_Disable { get; set; }

        public string Zone_Lang { get; set; }

        public bool Zone_IsStandAloneBox { get; set; }

    }
}
