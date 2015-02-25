using System;

namespace iDKCMS.Library.Data
{
    public class ErrorReportInfo
    {
        private int _error_ID;
        public int Error_ID
        {
            get { return _error_ID; }
            set { _error_ID = value; }
        }

        private string _error_Url;
        public string Error_Url
        {
            get { return _error_Url; }
            set { _error_Url = value; }
        }

        private string _error_String;
        public string Error_String
        {
            get { return _error_String; }
            set { _error_String = value; }
        }

        private DateTime _error_Datetime;
        public DateTime Error_Datetime
        {
            get { return _error_Datetime; }
            set { _error_Datetime = value; }
        }
    }
}
