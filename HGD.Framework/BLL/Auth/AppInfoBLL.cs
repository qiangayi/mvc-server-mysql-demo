using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Orm;
using HGD.Framework.Orm.Auth;
using HGD.Framework.Util;

namespace HGD.Framework.BLL.Auth
{
    public class AppInfoBLL
    {
        public static bool Valid(long appId, string appSecret)
        {
            using (var db = new HGDContext())
            {
                //
                AppInfo e = (from ai in db.AppInfo
                        where ai.Id == appId
                        select ai)
                    .FirstOrDefault();

                string hashAppSecret = MD5Util.getHashStr(appSecret);

                return e != null && e.Secret.ToLower() == hashAppSecret;
            }
        }

        public static long Add(string appSecret, string name)
        {
            using (var db = new HGDContext())
            {
                //
                AppInfo e = new AppInfo();

                e.Id = LeafSnowflake.getID();
                e.Secret = MD5Util.getHashStr(appSecret);
                e.Name = name;

                db.AppInfo.Add(e);

                db.SaveChanges();

                return e.Id;
            }
        }

        public static AppInfo Get(long appID)
        {
            using (var db = new HGDContext())
            {
                return db.AppInfo.Find(appID);
            }
        }

        public static Dictionary<long, string> GetIDWithName()
        {
            using (var db = new HGDContext())
            {
                //
                Dictionary<long, string> dict = new Dictionary<long, string>();

                var query = from d in db.AppInfo
                    select new
                    {
                        ID = d.Id,
                        Name = d.Name
                    };

                foreach (var item in query)
                    dict.Add(item.ID, item.Name);

                return dict;
            }
        }
    }
}
