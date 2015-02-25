using System.IO;
using System.Net;

namespace iDKCMS.Library
{
	public class RemoteDataUtility
	{
		public static string GetDataFromUrl(string requestURL, int timeOut)
		{
			var retVal = "";
			var request = WebRequest.Create(requestURL);
			request.Timeout = timeOut;
			var response = request.GetResponse();
			var reader = new StreamReader(response.GetResponseStream());
			retVal = reader.ReadToEnd();
			return retVal;
		}
	}
}