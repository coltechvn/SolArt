using System;
namespace iDKCMS.Library
{
    public class OrderInfo
    {
        public int Order_ID { get; set; }

        public int Member_ID { get; set; }

        public string Order_Fullname { get; set; }

        public string Order_Email { get; set; }

        public string Order_Tel { get; set; }

        public string Order_Address { get; set; }

        public string Order_District { get; set; }

        public string Order_City { get; set; }

        public string Order_Note { get; set; }

        public DateTime Order_CreateDate { get; set; }

        public int Order_Status { get; set; }

        public double Order_Price { get; set; }

        public int Order_Quantity { get; set; }

    }
}
