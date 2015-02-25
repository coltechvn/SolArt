using System.Data;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library.Distributor
{
	public class CmdDistributor
	{
		public static DataTable GetByParentID(int _parentID)
		{
			DataCaching dataCaching = new DataCaching();
			string _cacheKey = "Main.Cmds_GetByParentID";

			DataTable _retVal = (DataTable) dataCaching.GetHashCache(_cacheKey, _parentID);
			if (_retVal == null)
			{
				_retVal = CmdDB.GetByParentID(_parentID);
				dataCaching.SetHashCache(_cacheKey, _parentID, 0, _retVal);
			}
			return _retVal;
		}
	}
}