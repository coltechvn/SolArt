using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using iDKCMS.Library.DataAccess;

namespace iDKCMS.Library
{
    public class ZoneUtility
    {
        public static void LoadZones(ListItemCollection lstZones, int userID)
        {
            LoadZones(lstZones);
            string cmsRoles = "|" + RoleDB.GetUserCMSRoles(userID, AppEnv.GetLanguage());

            int i = 0;
            while (i < lstZones.Count)
            {
                if (cmsRoles.IndexOf("|" + lstZones[i].Value + "|") < 0)
                    lstZones.RemoveAt(i);
                else i += 1;
            }
        }

        public static void LoadZones(ListItemCollection lstZones)
        {
            lstZones.Clear();
            DataTable dtItems = ZoneDB.GetByParentID(0);
            foreach (DataRow row in dtItems.Rows)
            {
                ListItem item = new ListItem();
                item.Value = row["Zone_ID"].ToString();
                item.Text = row["Zone_Name"].ToString();
                item.Attributes.Add("Level", "0");
                lstZones.Add(item);
                LoadZoneItems(lstZones, item);
            }
        }


        public static void LoadZonesByParentID(ListItemCollection lstZones, int _zoneParentID)
        {
            lstZones.Clear();
            DataTable dtItems = ZoneDB.GetByParentID(_zoneParentID);
            foreach (DataRow row in dtItems.Rows)
            {
                ListItem item = new ListItem();
                item.Value = row["Zone_ID"].ToString();
                item.Text = row["Zone_Name"].ToString();
                item.Attributes.Add("Level", "0");
                lstZones.Add(item);
                LoadZoneItems(lstZones, item);
            }
        }

        private static void LoadZoneItems(ListItemCollection lstZones, ListItem curItem)
        {
            int level = Convert.ToInt32(curItem.Attributes["Level"]);
            level += 1;
            int curZoneID = ConvertUtility.ToInt32(curItem.Value);
            DataTable dtChildItems = ZoneDB.GetByParentID(curZoneID);
            foreach (DataRow row in dtChildItems.Rows)
            {
                ListItem childItem = new ListItem();
                childItem.Text = MiscUtility.StringIndent(level) + row["Zone_Name"];
                childItem.Value = row["Zone_ID"].ToString();
                childItem.Attributes.Add("Level", level.ToString());
                lstZones.Add(childItem);
                LoadZoneItems(lstZones, childItem);
            }
        }

        public static void LoadZonesOrderByName(ListItemCollection lstZones)
        {
            lstZones.Clear();
            DataTable dtItems = ZoneDB.GetByParentIDOrderByName(0);
            foreach (DataRow row in dtItems.Rows)
            {
                ListItem item = new ListItem();
                item.Value = row["Zone_ID"].ToString();
                item.Text = row["Zone_Name"].ToString();
                item.Attributes.Add("Level", "0");
                lstZones.Add(item);
                LoadZoneItemsOrderByName(lstZones, item);
            }
        }

        private static void LoadZoneItemsOrderByName(ListItemCollection lstZones, ListItem curItem)
        {
            int level = Convert.ToInt32(curItem.Attributes["Level"]);
            level += 1;
            int curZoneID = ConvertUtility.ToInt32(curItem.Value);
            DataTable dtChildItems = ZoneDB.GetByParentIDOrderByName(curZoneID);
            foreach (DataRow row in dtChildItems.Rows)
            {
                ListItem childItem = new ListItem();
                childItem.Text = MiscUtility.StringIndent(level) + row["Zone_Name"];
                childItem.Value = row["Zone_ID"].ToString();
                childItem.Attributes.Add("Level", level.ToString());
                lstZones.Add(childItem);
                LoadZoneItems(lstZones, childItem);
            }
        }

        public static int GetZoneCurrent()
        {
            var zonecurrent = 0;

            var itemId = ConvertUtility.ToInt32(HttpContext.Current.Request.QueryString["itemid"]);

            if(itemId > 0)
            {
                zonecurrent = DistributionDB.GetZoneID(itemId);
            }
            else
            {
                zonecurrent = ConvertUtility.ToInt32(HttpContext.Current.Request.QueryString["zoneid"]);
            }
            
            return zonecurrent;
        }
    }
}