namespace iDKCMS.Library.Data
{
    public class UserInfo
    {
        private int _user_ID;
        public int User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        private string _user_Email;
        public string User_Email
        {
            get { return _user_Email; }
            set { _user_Email = value; }
        }

        private string _user_FullName;
        public string User_FullName
        {
            get { return _user_FullName; }
            set { _user_FullName = value; }
        }

        private string _user_Password;
        public string User_Password
        {
            get { return _user_Password; }
            set { _user_Password = value; }
        }

        private bool _user_Gender;
        public bool User_Gender
        {
            get { return _user_Gender; }
            set { _user_Gender = value; }
        }

        private string _user_Birthday;
        public string User_Birthday
        {
            get { return _user_Birthday; }
            set { _user_Birthday = value; }
        }

        private string _user_Address;
        public string User_Address
        {
            get { return _user_Address; }
            set { _user_Address = value; }
        }

        private string _user_Phone;
        public string User_Phone
        {
            get { return _user_Phone; }
            set { _user_Phone = value; }
        }

        private bool _user_SuperAdmin;
        public bool User_SuperAdmin
        {
            get { return _user_SuperAdmin; }
            set { _user_SuperAdmin = value; }
        }
    }
}