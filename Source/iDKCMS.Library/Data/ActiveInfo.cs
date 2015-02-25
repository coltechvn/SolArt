using System;

namespace iDKCMS.Library.Data
{
    public class ActiveInfo
    {
        private string _sessionID;
        public string SessionID
        {
            get { return _sessionID; }
            set { _sessionID = value; }
        }

        private string _iP;
        public string IP
        {
            get { return _iP; }
            set { _iP = value; }
        }

        private int _user_ID;
        public int User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        private DateTime _loginTime;
        public DateTime LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }

        private DateTime _lastActiveTime;
        public DateTime LastActiveTime
        {
            get { return _lastActiveTime; }
            set { _lastActiveTime = value; }
        }
    }
}
