namespace iDKCMS.Library.Data
{
	public class CmdInfo
	{
		private int _cmd_ID;
		public int Cmd_ID
		{
			get { return _cmd_ID; }
			set { _cmd_ID = value; }
		}

		private string _cmd_Name;
		public string Cmd_Name
		{
			get { return _cmd_Name; }
			set { _cmd_Name = value; }
		}

		private string _cmd_Value;
		public string Cmd_Value
		{
			get { return _cmd_Value; }
			set { _cmd_Value = value; }
		}

		private string _cmd_Params;
        public string Cmd_Params
		{
			get { return _cmd_Params;}
			set { _cmd_Params = value;}
		}

		private int _cmd_ParentID;
		public int Cmd_ParentID
		{
			get { return _cmd_ParentID; }
			set { _cmd_ParentID = value; }
		}

		private int _cmd_Index;
		public int Cmd_Index
		{
			get { return _cmd_Index; }
			set { _cmd_Index = value; }
		}

		private string _cmd_Url;
		public string Cmd_Url
		{
			get { return _cmd_Url; }
			set { _cmd_Url = value; }
		}

		private string _cmd_Path;
		public string Cmd_Path
		{
			get { return _cmd_Path; }
			set { _cmd_Path = value; }
		}

		private bool _cmd_Enable;
		public bool Cmd_Enable
		{
			get { return _cmd_Enable; }
			set { _cmd_Enable = value; }
		}

		private bool _cmd_Visible;
		public bool Cmd_Visible
		{
			get { return _cmd_Visible; }
			set { _cmd_Visible = value; }
		}

	}
}