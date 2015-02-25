using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace iDKCMS.Library
{
    public class HttpModule : IHttpModule
    {
        private HttpApplication _application;

        public void Init(HttpApplication application)
        {
            _application = application;
            _application.BeginRequest += new EventHandler(_application_BeginRequest);
        }

        public void Dispose()
        {
        }

        private void _application_BeginRequest(object sender, EventArgs e)
        {
            string langCulture = AppEnv.GetLanguage();
            if (_application.Context.Request.QueryString["lang"] == null)
            {

                string newUrl = _application.Context.Request.RawUrl;
                if (newUrl.IndexOf("?") >= 0) newUrl += "&lang=" + langCulture;
                else newUrl += "?lang=" + langCulture;
                _application.Context.Response.Redirect(newUrl);
            }
            else
            {
                string newLang = _application.Context.Request.QueryString["lang"];
                if (newLang != langCulture)
                {
                    if (newLang == "vi-VN" || newLang == "en-US")
                        AppEnv.SetLanguage(newLang);
                    else
                    {
                        newLang = AppEnv.GetDefaultLanguage();
                        AppEnv.SetLanguage(newLang);
                    }
                    langCulture = newLang;
                }
            }

            CultureInfo cur = new CultureInfo(langCulture);
            Thread.CurrentThread.CurrentCulture = cur;
            Thread.CurrentThread.CurrentUICulture = cur;
        }
    }
}