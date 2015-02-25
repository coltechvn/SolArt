using System.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library.Distributor
{
	public class LanguageDistributor
	{
		public static DataTable GetAll()
		{
			DataTable retVal;
			DataCaching dataCaching = new DataCaching();
			string cacheKey = "Main.Languages_GetAll";
			retVal = (DataTable) dataCaching.GetCache(cacheKey);
			if (retVal == null)
			{
				retVal = LanguageDB.GetAll();
				dataCaching.InsertCacheNoExpireTime(cacheKey, retVal);
			}
			return retVal;
		}
	}
}