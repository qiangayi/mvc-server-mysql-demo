using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using HGD.Framework.Entity.Auth;
using HGD.Web.Entity;

namespace HGD.Web.ActionFilter
{
    /// <summary>
    /// token验证登陆
    /// </summary>
    public class RequestAuthorizeAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext context)
        {
            var request = HttpContext.Current.Request;
            var token = request.Headers["X-Token"];
            if (string.IsNullOrEmpty(token))
            {
                JsonResult apiResult = new JsonResult
                {
                    Code = 50008,
                    Message =  "无Token"
                };
                HttpContext.Current.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(apiResult));
                HttpContext.Current.Response.End();
                HandleUnauthorizedRequest(context);
                return;
            }

            var t = AccessToken.TokenFromSid(Convert.ToInt64(token));
            if (t == null)
            {
                JsonResult apiResult = new JsonResult
                {
                    Code = 50008,
                    Message = "无效Token"
                };
                HttpContext.Current.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(apiResult));
                HttpContext.Current.Response.End();
                HandleUnauthorizedRequest(context);
            }

        }
    }
}