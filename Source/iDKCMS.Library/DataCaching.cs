using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace iDKCMS.Library
{
    public class DataCaching
    {
        private HttpContext context;

        public DataCaching()
        {
            context = HttpContext.Current;
        }

        public object GetCache(string key)
        {
            return context.Cache.Get(key);
        }

        public void InsertCache(string key, object data, double expireTime)
        {
            if (expireTime == 0) InsertCacheNoExpireTime(key, data);
            else context.Cache.Insert(key, data, null, DateTime.Now.AddHours(expireTime), Cache.NoSlidingExpiration);
        }

        public void InsertCacheNoExpireTime(string key, object data)
        {
            if (data != null) context.Cache.Insert(key, data);
        }

        public bool RemoveCache(string key)
        {
            if (context.Cache[key] != null)
            {
                context.Cache.Remove(key);
                return true;
            }
            else return false;
        }

        public object GetHashCache(string hashKey, object param)
        {
            Hashtable retVal = (Hashtable)GetCache(hashKey);
            if (retVal == null) return null;
            if (retVal[param] == null) return null;
            return retVal[param];
        }

        public void SetHashCache(string hashKey, object param, double expireTime, object data)
        {
            Hashtable retVal = (Hashtable)GetCache(hashKey);
            if (retVal == null)
            {
                retVal = new Hashtable();
                retVal.Add(param, data);
                InsertCache(hashKey, retVal, expireTime);
            }
            else
            {
                if (retVal.ContainsKey(param)) retVal[param] = data;
                else retVal.Add(param, data);
            }
        }
    }
}