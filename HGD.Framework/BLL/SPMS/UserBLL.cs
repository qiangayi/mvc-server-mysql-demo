using HGD.Framework.Orm.SPMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Orm;
using HGD.Framework.Util;

namespace HGD.Framework.BLL.SPMS
{
    public class UserBLL
    {
        public static List<User> GetAll()
        {
            //
            using (var db = new HGDContext())
            {
                return db.User.ToList();
            }

        }

        public static Dictionary<string, User> GetAllDict()
        {
            //
            using (var db = new HGDContext())
            {
                Dictionary<string, User> dict = new Dictionary<string, User>();

                foreach (var u in db.User)
                    dict.Add(u.IdStr, u);

                return dict;
            }

        }
        public static int Add(User user)
        {
            //
            using (var db = new HGDContext())
            {
                //
                db.User.Add(user);
                return db.SaveChanges();
            }

        }

        public static int Update(User user)
        {
            //
            using (var db = new HGDContext())
            {
                User u = db.User.Find(user.Id);

                if (u == null)
                    return 0;
                else
                {
                    u.Name = user.Name;
                }

                return db.SaveChanges();
            }

        }

        public static int Delete(string userId)
        {
            //
            using (var db = new HGDContext())
            {
                User u = db.User.Find(userId);

                if (u == null)
                    return 0;
                else
                    db.User.Remove(u);

                return db.SaveChanges();
            }

        }
        public static string GetNameByID(string id)
        {
            using (var db = new HGDContext())
            {
                return (
                    from u in db.User
                    where u.IdStr == id
                    select u.Name
                    ).FirstOrDefault();
            }
        }
        public static string GetIDByAccount(string loginId)
        {
            using (var db = new HGDContext())
            {
                return (
                    from u in db.User
                    where u.Account == loginId
                    select u.IdStr
                    ).FirstOrDefault();
            }
        }

        public static User Get(string id)
        {
            using (var db = new HGDContext())
            {
                var user = (
                    from u in db.User
                    where u.IdStr == id
                    select u
                    ).FirstOrDefault();
                return user;
            }
        }

        public static User GetByName(string name)
        {
            using (var db = new HGDContext())
            {
                return (
                    from u in db.User
                    where u.Name == name
                    select u
                    ).FirstOrDefault();
            }
        }

        public static bool Valid(string loginId, string password)
        {
            using (var db = new HGDContext())
            {
                string pwd = (
                    from u in db.User
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
    }
}
