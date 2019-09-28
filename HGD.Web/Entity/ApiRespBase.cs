using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGD.Web.Entity.Auth
{
    public class ApiRespBase
    {
        public long Code { set; get; }
        public string Message { set; get; }
        public object Conent { get; set; }
    }
}