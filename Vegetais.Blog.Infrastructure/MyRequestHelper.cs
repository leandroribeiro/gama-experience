using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Vegetais.Blog.Infrastructure
{
    public static class MyRequestHelper
    {
        public static string GetIPAdress(HttpRequestBase request)
        {
            var ipAdress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdress))
                ipAdress = request.ServerVariables["REMOTE_ADDR"];

            return ipAdress;
        }
    }
}
