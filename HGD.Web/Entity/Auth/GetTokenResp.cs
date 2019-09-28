using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGD.Web.Entity.Auth
{
    public class GetTokenResp:ApiRespBase
    {
        public string Token { set; get; }
    }
}