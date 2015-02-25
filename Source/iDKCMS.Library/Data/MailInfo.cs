using System;

namespace iDKCMS.Library.Data
{
    public class MailInfo
    {
        private int _mail_ID;
        public int Mail_ID
        {
            get { return _mail_ID; }
            set { _mail_ID = value; }
        }

        private string _mail_Kind;
        public string Mail_Kind
        {
            get { return _mail_Kind; }
            set { _mail_Kind = value; }
        }

        private string _mail_Name;
        public string Mail_Name
        {
            get { return _mail_Name; }
            set { _mail_Name = value; }
        }

        private string _mail_Email;
        public string Mail_Email
        {
            get { return _mail_Email; }
            set { _mail_Email = value; }
        }

        private string _mail_Phone;
        public string Mail_Phone
        {
            get { return _mail_Phone; }
            set { _mail_Phone = value; }
        }

        private string _mail_Address;
        public string Mail_Address
        {
            get { return _mail_Address; }
            set { _mail_Address = value; }
        }

        private string _mail_Content;
        public string Mail_Content
        {
            get { return _mail_Content; }
            set { _mail_Content = value; }
        }

        private int _pix_ID;
        public int Pix_ID
        {
            get { return _pix_ID; }
            set { _pix_ID = value; }
        }

        private bool _mail_Answer;
        public bool Mail_Answer
        {
            get { return _mail_Answer; }
            set { _mail_Answer = value; }
        }

        private DateTime _mail_Datetime;
        public DateTime Mail_Datetime
        {
            get { return _mail_Datetime; }
            set { _mail_Datetime = value; }
        }
    }
}
