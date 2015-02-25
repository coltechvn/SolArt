using System;

namespace iDKCMS.Library.Data
{
    public class AdvertiseInfo
    {
        private int _advertise_ID;
        public int Advertise_ID
        {
            get { return _advertise_ID; }
            set { _advertise_ID = value; }
        }

        private string _advertise_Name;
        public string Advertise_Name
        {
            get { return _advertise_Name; }
            set { _advertise_Name = value; }
        }

        private string _advertise_Path;
        public string Advertise_Path
        {
            get { return _advertise_Path; }
            set { _advertise_Path = value; }
        }

        private int _advertise_Width;
        public int Advertise_Width
        {
            get { return _advertise_Width; }
            set { _advertise_Width = value; }
        }

        private int _advertise_Height;
        public int Advertise_Height
        {
            get { return _advertise_Height; }
            set { _advertise_Height = value; }
        }

        private DateTime _advertise_StartDate;
        public DateTime Advertise_StartDate
        {
            get { return _advertise_StartDate; }
            set { _advertise_StartDate = value; }
        }

        private DateTime _advertise_EndDate;
        public DateTime Advertise_EndDate
        {
            get { return _advertise_EndDate; }
            set { _advertise_EndDate = value; }
        }

        private string _advertise_Type;
        public string Advertise_Type
        {
            get { return _advertise_Type; }
            set { _advertise_Type = value; }
        }

        private int _advertise_Priority;
        public int Advertise_Priority
        {
            get { return _advertise_Priority; }
            set { _advertise_Priority = value; }
        }

        private int _advertise_Click;
        public int Advertise_Click
        {
            get { return _advertise_Click; }
            set { _advertise_Click = value; }
        }

        private string _advertise_RedirectURL;
        public string Advertise_RedirectURL
        {
            get { return _advertise_RedirectURL; }
            set { _advertise_RedirectURL = value; }
        }
        private int _advertise_PositionID;
        public int Advertise_PositionID
        {
            get { return _advertise_PositionID; }
            set { _advertise_PositionID = value; }
        }

        private bool _advertise_Enable;
        public bool Advertise_Enable
        {
            get { return _advertise_Enable; }
            set { _advertise_Enable = value; }
        }
        private string _advertise_Params;
        public string Advertise_Params
        {
            get { return _advertise_Params; }
            set { _advertise_Params = value; }
        }
        private string _advertise_Lang;
        public string Advertise_Lang
        {
            get { return _advertise_Lang; }
            set { _advertise_Lang = value; }
        }

        private string _advertise_Embed;
        public string Advertise_Embed
        {
            get { return _advertise_Embed; }
            set { _advertise_Embed = value; }
        }
    }
}