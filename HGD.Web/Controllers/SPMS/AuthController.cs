using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HGD.Framework.BLL.SPMS;
using HGD.Framework.Entity.Auth;
using HGD.Framework.Util;
using HGD.Web.Entity;
using HGD.Web.Entity.Auth;
using HGD.Web.Util;
using HGD.Web.ActionFilter;

namespace HGD.Web.Controllers.SPMS
{
    [Route("api/admin/Auth/{action}")]
    public class AuthController : ApiController
    {
        [HttpGet]
        public GetTokenResp Login(string loginId, string passWord)
        {
            GetTokenResp resp = new GetTokenResp
            {
                Code = 30001,
            };
            if (SysUserBLL.Valid(loginId, passWord))
            {
                string userId = SysUserBLL.GetIDByAccount(loginId);

                string tokenStr = AccessToken.GetToken(userId);
                resp.Code = 0;
                resp.Message = "OK";
                resp.Token = tokenStr;
            }
            else
            {
                resp.Message = "账号密码错误";
            }
            return resp;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>JsonResult</returns>
        [HttpGet]
        [RequestAuthorize]
        public JsonResult GetUserInfo(string token)
        {
            JsonResult resp = new JsonResult();
            var t = AccessToken.TokenFromSid(Convert.ToInt64(token));
            if (t == null)
            {
                resp.Success = false;
                resp.Message = "无效token";
                resp.Code = -1;
                return resp;
            }
            resp.Success = true;
            resp.Content = SysUserBLL.Get(t.UserID);
            return resp;
        }
    }
}