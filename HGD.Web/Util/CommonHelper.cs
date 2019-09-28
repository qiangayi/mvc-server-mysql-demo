using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGD.Web.Util
{
    public class CommonHelper
    {
        public static string GetDateString(DateTime? dt, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if (dt == null)
            {
                return null;
            }
            else
            {
                var dateTime = Convert.ToDateTime(dt);
                return dateTime.ToString(format);
            }

        }
    }
}