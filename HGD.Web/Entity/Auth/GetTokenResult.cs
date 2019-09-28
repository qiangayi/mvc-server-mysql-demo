using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGD.Web.Entity.Auth
{
    public class GetTokenResult
    {
        public string Token { set; get; }
        public string UserID { set; get; }
        public string UserName { set; get; }
        public string CorpID { set; get; }
        public bool IsCity { set; get; }
    }
}