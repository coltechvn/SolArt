using System.Data;

namespace iDKCMS.Library
{
    public class ExecuteUtility
    {
        private const IsolationLevel m_isoLevel = IsolationLevel.ReadUncommitted;

        private ExecuteUtility()
        {
        }
        #region DB Access Functions
        static public IsolationLevel IsolationLevel
        {
            get
            {
                return m_isoLevel;
            }
        }

        #endregion
    }
}