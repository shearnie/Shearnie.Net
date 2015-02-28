using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shearnie.Net.Web
{
    public class ServerInfo
    {
        public static string GetIPAddress
        {
            get
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else if (!string.IsNullOrEmpty(HttpContext.Current.Request.UserHostAddress))
                {
                    return HttpContext.Current.Request.UserHostAddress;
                }

                return "";
            }
        }

        public static string GetDevice { get { return HttpContext.Current.Request.UserAgent; } }

        public static string GetBrowser { get { return HttpContext.Current.Request.Browser.Type; } }
    }
}
