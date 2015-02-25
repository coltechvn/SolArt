using System.Web;

namespace iDKCMS.Library
{
	public class SessionUtility
	{
		public static void SetValue(string name, string value)
		{
			var context = HttpContext.Current;
			if (context.Session[name] == null)
			{
				context.Session.Add(name, value);
			}
			else
			{
				context.Session[name] = value;
			}
		}

		public static string GetValue(string name)
		{
			var context = HttpContext.Current;
			if (context.Session[name] != null)
			{
				return context.Session[name].ToString();
			}
			else
			{
				return string.Empty;
			}
		}

		public static void Remove(string name)
		{
			var context = HttpContext.Current;
			context.Session.Remove(name);
		}
	}
}