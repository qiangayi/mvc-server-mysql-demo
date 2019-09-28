using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGD.Web.Entity
{
    public class JsonResult
    {
        public bool Success { set; get; }
        public object Content { set; get; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}