using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Orm;
using HGD.Framework.Orm.SPMS.Model;
using HGD.Framework.Util;

namespace HGD.Framework.BLL.SPMS
{
    public class SysUserBLL
    {

        public static bool Valid(string loginId, string password)
        {
            using (var db = new HGDContext())
            {
                string pwd = (
                    from u in db.Sys_User
                    where u.Account == loginId
                    select u.Password
                ).FirstOrDefault();

                if (password == null)
                    return false;

                string hasdPwd = MD5Util.getHashStr(password);

                if (pwd == null)
                    return false;

                return hasdPwd.ToLower() == pwd.ToLower();
            }
        }

        public static Sys_User Get(string id)
        {
            using (var db = new HGDContext())
            {
                var user = (
                    from u in db.Sys_User
                    where u.Id == id
                    select u
                ).FirstOrDefault();
                return user;
            }
        }

        public static string GetIDByAccount(string loginId)
        {
            using (var db = new HGDContext())
            {
                return (
                    from u in db.Sys_User
                    where u.Account == loginId
                    select u.Id
                ).FirstOrDefault();
            }
        }
    }
}
