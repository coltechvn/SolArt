namespace iDKCMS.Library.Data
{
    public class OrderProductInfo
    {
        private int _order_ID;
        public int Order_ID
        {
            get { return _order_ID; }
            set { _order_ID = value; }
        }

        private int _content_ID;
        public int Content_ID
        {
            get { return _content_ID; }
            set { _content_ID = value; }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private double _priceSum;
        public double PriceSum
        {
            get { return _priceSum; }
            set { _priceSum = value; }
        }
    }
}