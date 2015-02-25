namespace iDKCMS.Library.Data
{
	public class GroupInfo
	{
		private int _group_ID;
		public int Group_ID
		{
			get { return _group_ID; }
			set { _group_ID = value; }
		}

		private string _group_Name;
		public string Group_Name
		{
			get { return _group_Name; }
			set { _group_Name = value; }
		}

		private string _group_Description;
		public string Group_Description
		{
			get { return _group_Description; }
			set { _group_Description = value; }
		}

	}
}