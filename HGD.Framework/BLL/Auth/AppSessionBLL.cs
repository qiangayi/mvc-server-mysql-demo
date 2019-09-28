using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HGD.Framework.Entity.Auth;
using HGD.Framework.Orm;
using HGD.Framework.Orm.Auth.Model;

namespace HGD.Framework.BLL.Auth
{
    public class AppSessionBLL
    {
        public static int Add(long id, string value)
        {
            using (var db = new HGDContext())
            {
                //
                AppSession sess = new AppSession();

                sess.Id = id;
                sess.Value = value;

                db.AppSession.Add(sess);

                return db.SaveChanges();
            }
        }

        public static AppSession Get(long id)
        {
            using (var db = new HGDContext())
            {
                return db.AppSession.Find(id);
            }
        }

        public static int SaveToken(long id, Token token)
        {
            using (var db = new HGDContext())
            {
                //
                var sess = db.AppSession.Find(id);
                if (sess == null)
                {
                    sess = new AppSession();
                    sess.Id = id;

                    db.AppSession.Add(sess);
                }

                sess.Value = JsonConvert.SerializeObject(token);

                return db.SaveChanges();
            }
        }

        public static Token LoadToken(long id)
        {
            using (var db = new HGDContext())
            {
                //
                var sess = db.AppSession.Find(id);
                if (sess == null)
                    return null;

                Token token = JsonConvert.DeserializeObject<Token>(sess.Value);
                if (token.ExpireTime < DateTime.Now)
                {
                    db.AppSession.Remove(sess);
                    db.SaveChanges();

                    return null;
                }

                return token;
            }
        }

        public static int Clean()
        {
            using (var db = new HGDContext())
            {
                List<AppSession> listRemove = new List<AppSession>();
                //
                foreach (var sess in db.AppSession)
                {
                    Token token = JsonConvert.DeserializeObject<Token>(sess.Value);
                    if (token != null && token.ExpireTime < DateTime.Now)
                        listRemove.Add(sess);
                }

                if (listRemove.Count > 0)
                {
                    db.AppSession.RemoveRange(listRemove);

                    return db.SaveChanges();
                }

                return 0;
            }
        }
    }
}
