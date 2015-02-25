namespace iDKCMS.Library.Data
{
    public class PositionInfo
    {
        private int _pos_ID;
        public int Pos_ID
        {
            get { return _pos_ID; }
            set { _pos_ID = value; }
        }
        private string _pos_Position;
        public string Pos_Position
        {
            get { return _pos_Position; }
            set { _pos_Position = value; }
        }

        private string _pos_Name;
        public string Pos_Name
        {
            get { return _pos_Name; }
            set { _pos_Name = value; }
        }

        private int _pos_Width;
        public int Pos_Width
        {
            get { return _pos_Width; }
            set { _pos_Width = value; }
        }

        private int _pos_Height;
        public int Pos_Height
        {
            get { return _pos_Height; }
            set { _pos_Height = value; }
        }

        private string _pos_Type;
        public string Pos_Type
        {
            get { return _pos_Type; }
            set { _pos_Type = value; }
        }
        private string _pos_SeparateCode;
        public string Pos_SeparateCode
        {
            get { return _pos_SeparateCode; }
            set { _pos_SeparateCode = value; }
        }
    }
}