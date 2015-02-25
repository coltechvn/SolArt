using System;

namespace iDKCMS.Library
{
    public class MemberInfo
    {
        public int Member_ID { get; set; }

        public string Member_Email { get; set; }

        public string Member_Password { get; set; }

        public string Member_Fullname { get; set; }

        public int Member_Gender { get; set; }

        public string Member_Avatar { get; set; }

        public string Member_Tel { get; set; }

        public string Member_Address { get; set; }

        public string Member_District { get; set; }

        public string Member_City { get; set; }

        public int Member_Rank { get; set; }

        public DateTime Member_Birthday { get; set; }

        public bool Member_Active { get; set; }

        public string Member_ActiveCode { get; set; }

        public bool Member_IsForgotPassword { get; set; }

    }
}
