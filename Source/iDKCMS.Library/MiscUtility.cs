using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iDKCMS.Library
{
	public class MiscUtility
	{
		public const string UPDATE_SUCCESS = "<font color='blue'> Cập nhật thành công !</font>";
		public const string UPDATE_ERROR = "<font color='red'> Có lỗi trong quá trình cập nhật !</font>";
		public const string DELETE_CONFIRM = "return confirm(' Bạn đã chắc chắn ? ');";

        public static string DayOfWeekInVN(string _day)
        {
            string retVal = _day;

            if (AppEnv.GetLanguage() == "vi-VN")
            {
                switch (_day)
                {
                    case "Monday":
                        retVal = "Thứ hai";
                        break;
                    case "Tuesday":
                        retVal = "Thứ ba";
                        break;
                    case "Wednesday":
                        retVal = "Thứ tư";
                        break;
                    case "Thursday":
                        retVal = "Thứ năm";
                        break;
                    case "Friday":
                        retVal = "Thứ sáu";
                        break;
                    case "Saturday":
                        retVal = "Thứ bảy";
                        break;
                    case "Sunday":
                        retVal = "Chủ nhật";
                        break;
                }
            }

            return retVal;
        }

		public static string UpdateQueryStringItem(HttpRequest httpRequest, string queryStringKey, string newQueryStringValue)
		{
			var NewURL = new StringBuilder();

			NewURL.Append(httpRequest.RawUrl);

			if (httpRequest.QueryString[queryStringKey] != null)
			{
				var orignalSet = String.Format("{0}={1}", queryStringKey, httpRequest.QueryString[queryStringKey]);
				var newSet = String.Format("{0}={1}", queryStringKey, newQueryStringValue);
				NewURL.Replace(orignalSet, newSet);
			}
			else if (httpRequest.QueryString.Count == 0)
			{
				NewURL.AppendFormat("?{0}={1}", queryStringKey, newQueryStringValue);
			}
			else
			{
				NewURL.AppendFormat("&{0}={1}", queryStringKey, newQueryStringValue);
			}

			return NewURL.ToString();
		}

		public static string UpdateQueryStringItem(HttpRequest httpRequest, string[] queryStringKeys, string[] newQueryStringValues)
		{
			var NewURL = new StringBuilder();

			NewURL.Append(httpRequest.RawUrl.Replace("%20", " "));
			bool check = true;
			for (int i = 0; i < queryStringKeys.GetLength(0); i ++)
			{
				string queryStringKey = queryStringKeys[i];
				string newQueryStringValue = newQueryStringValues[i];
				if (httpRequest.QueryString[queryStringKey] != null)
				{
					string OrignalSet = String.Format("{0}={1}", queryStringKey, httpRequest.QueryString[queryStringKey]);
					string NewSet = String.Format("{0}={1}", queryStringKey, newQueryStringValue);
					NewURL.Replace(OrignalSet, NewSet);
				}
				else if (httpRequest.QueryString.Count == 0)
				{
					if (newQueryStringValue != "" && newQueryStringValue != null)
					{
						if (check)
						{
							NewURL.AppendFormat("?{0}={1}", queryStringKey, newQueryStringValue);
							check = false;
						}
						else NewURL.AppendFormat("&{0}={1}", queryStringKey, newQueryStringValue);
					}
				}
				else if (newQueryStringValue != "" && newQueryStringValue != null) NewURL.AppendFormat("&{0}={1}", queryStringKey, newQueryStringValue);
			}

			return NewURL.ToString();
		}

		public static void FillTreeData(ListItemCollection lst, DataTable dtCommands, string fieldKey, string fieldName, string fieldParentID, string sortBy)
		{
			lst.Clear();
			DataRow[] drRoots = dtCommands.Select(fieldParentID + "  = " + 0, sortBy);
			foreach (DataRow row in drRoots)
			{
				ListItem item = new ListItem();
				item.Value = row[fieldKey].ToString();
				item.Text = row[fieldName].ToString();
				item.Attributes.Add("Level", "0");
				lst.Add(item);
				LoadCmdItem(lst, item, dtCommands, fieldKey, fieldName, fieldParentID, sortBy);
			}
		}

		private static void LoadCmdItem(ListItemCollection lst, ListItem curItem, DataTable dtCommands, string fieldKey, string fieldName, string fieldParentID, string sortBy)
		{
			int level = Convert.ToInt32(curItem.Attributes["Level"]);
			level += 1;
			int curID = Convert.ToInt32(curItem.Value);
			DataRow[] drChilds = dtCommands.Select(fieldParentID + " = " + curID);
			foreach (DataRow row in drChilds)
			{
				ListItem childItem = new ListItem();
				childItem.Text = MiscUtility.StringIndent(level) + row[fieldName].ToString();
				childItem.Value = row[fieldKey].ToString();
				childItem.Attributes.Add("Level", level.ToString());
				lst.Add(childItem);
				LoadCmdItem(lst, childItem, dtCommands, fieldKey, fieldName, fieldParentID, sortBy);
			}
		}

		public static void FillIndex(DropDownList dropIndex, int min, int max, int selected)
		{
			dropIndex.Items.Clear();
			for (int i = min; i <= max; i++)
			{
				ListItem item = new ListItem(i.ToString(), i.ToString());
				if (i == selected) item.Selected = true;
				else item.Selected = false;
				dropIndex.Items.Add(item);
			}
		}

		public static void FillIndex(DropDownList dropIndex, int max, int selected)
		{
			dropIndex.Items.Clear();
			for (int i = 0; i <= max; i++)
			{
				ListItem item = new ListItem(i.ToString(), i.ToString());
				if (i == selected) item.Selected = true;
				else item.Selected = false;
				dropIndex.Items.Add(item);
			}
		}

		
		public static void SetSelected(ListItemCollection lstItems, string selectedValue)
		{
			ListItem item = lstItems.FindByValue(selectedValue);
			if (item != null) item.Selected = true;
		}

		public static void SetSelected(DropDownList dropList, string selectedValue)
		{
			dropList.SelectedIndex = -1;
			SetSelected(dropList.Items, selectedValue);
		}

		public static void SetSelected(ListBox list, string selectedValue)
		{
			list.SelectedIndex = -1;
			SetSelected(list.Items, selectedValue);
		}

		public static void SetSelected(RadioButtonList rdoList, string selectedValue)
		{
			rdoList.SelectedIndex = -1;
			SetSelected(rdoList.Items, selectedValue);
		}

		public static string StringIndent(int level)
		{
			string retVal = string.Empty;
			for (int i = 0; i < level; i ++)
				retVal += ".....";
			return retVal;
		}

        public static void SetDefaultButton(Page page, DropDownList dropControl, Button defaultButton)
        {
            string theScript = @"
			<SCRIPT language=""javascript"">
				<!--
					function fnTrapKD(btn, event){
					if (document.all){
					if (event.keyCode == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					else if (document.getElementById){
					if (event.which == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					else if(document.layers){
					if(event.which == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					}
				// -->
				</SCRIPT>";

            page.RegisterStartupScript("ForceDefaultToScript", theScript);
            dropControl.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)");


        }

        public static void SetDefaultButton(Page page, TextBox textControl, ImageButton defaultButton)
        {
            string theScript = @"
			<SCRIPT language=""javascript"">
				<!--
					function fnTrapKD(btn, event){
					if (document.all){
					if (event.keyCode == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					else if (document.getElementById){
					if (event.which == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					else if(document.layers){
					if(event.which == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					}
				// -->
				</SCRIPT>";

            page.RegisterStartupScript("ForceDefaultToScript", theScript);
            textControl.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)");


        }

        public static void SetDefaultButton(Page page, TextBox textControl, Button defaultButton)
        {
            string theScript = @"
			<SCRIPT language=""javascript"">
				<!--
					function fnTrapKD(btn, event){
					if (document.all){
					if (event.keyCode == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					else if (document.getElementById){
					if (event.which == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					else if(document.layers){
					if(event.which == 13){
					event.returnValue=false;
					event.cancel = true;
					btn.click();
					}
					}
					}
				// -->
				</SCRIPT>";

            page.RegisterStartupScript("ForceDefaultToScript", theScript);
            textControl.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)");


        }

        public static bool CheckEmail(string mEmail)
        {
            if (mEmail.Length == 0)
                return false;
            else
            {
                // Use a regular expression to match an email address.

                var emailReg =
                    new Regex(
                    @"^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$",
                    RegexOptions.CultureInvariant);
                var results =
                    emailReg.Matches(mEmail, 0);

                // If we didn't get a mtach, fail the validation

                if (results.Count == 0)
                    return false;
            }
            return true;
        }
	}
}