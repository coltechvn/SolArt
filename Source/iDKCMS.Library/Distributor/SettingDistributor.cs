using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library.Distributor
{
	public class SettingDistributor
	{
		public static string GetValue(string _name)
		{
			DataCaching dataCaching = new DataCaching();
			object _data = dataCaching.GetCache(_name);
			if (_data != null) return (string) _data;
			else
			{
				string _retVal = SettingDB.GetValue(_name);
				dataCaching.InsertCacheNoExpireTime(_name, _retVal);
				return _retVal;
			}
		}
	}
}