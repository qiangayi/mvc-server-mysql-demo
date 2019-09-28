using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HGD.Web.Util
{
    public class Config
    {
        public static string CookieDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["cookieDomain"];
            }
        }
        public static string Debug
        {
            get
            {
                return ConfigurationManager.AppSettings["Debug"];
            }
        }
    }
}