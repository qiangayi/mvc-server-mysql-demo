using HGD.Framework.BLL.SPMS;
using HGD.Web.Entity.Auth;

namespace HGD.Web.Util
{
    public class AuthUtil
    {
        public static GetTokenResult getTokenResult(string userId)
        {
            var gtr = new GetTokenResult {UserID = userId};
            var u = SysUserBLL.Get(userId);
            gtr.UserName = u.Name;
            return gtr;
        }
    }
}