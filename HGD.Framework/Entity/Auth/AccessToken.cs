using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.BLL.Auth;
using HGD.Framework.Util;

namespace HGD.Framework.Entity.Auth
{
    public class AccessToken
    {
        public static string GetTokenStr(Token token)
        {
            //
            using (MemoryStream ms = new MemoryStream())
            {

                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    //
                    bw.Write(token.UserID);
                    bw.Write(token.ExpireTime.Ticks);

                    byte[] data = ms.ToArray();
                    byte[] signData = RSAUtil.SignData(data);

                    bw.Write(signData);

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        private static Dictionary<long, Token> dictToken = new Dictionary<long, Token>();
        private static Dictionary<string, long> dictIdSecretWithSid = new Dictionary<string, long>();
        private static object lockObject = new object();

        private static void cleanExpired()
        {
            lock (lockObject)
            {
                List<long> list = new List<long>();
                foreach (var kvp in dictToken)
                {
                    if (kvp.Value.ExpireTime < DateTime.Now)
                        list.Add(kvp.Key);
                }

                foreach (long k in list)
                    dictToken.Remove(k);

                List<string> listKey = new List<string>();
                foreach (var kvp in dictIdSecretWithSid)
                {
                    if (!dictToken.ContainsKey(kvp.Value))
                        listKey.Add(kvp.Key);
                }

                foreach (string k in listKey)
                    dictIdSecretWithSid.Remove(k);
            }
        }

        public static string GetToken(string userId)
        {
            cleanExpired();

            string key = userId;

            lock (lockObject)
            {
                if (dictIdSecretWithSid.ContainsKey(key))
                    return dictIdSecretWithSid[key].ToString();
            }
                long sid = LeafSnowflake.getID();
                Token token = new Token();
                token.UserID = userId;
                token.ExpireTime = DateTime.Now.AddHours(2);

                AppSessionBLL.SaveToken(sid, token);

                lock (lockObject)
                {
                    dictToken.Add(sid, token);
                    dictIdSecretWithSid.Add(key, sid);
                }
                return sid.ToString();
           
        }
        /// <summary>
        /// 检测token是否有效
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static Token TokenFromSid(long sid)
        {
            lock (lockObject)
            {
                //Logger.DebugFormat("dictToken:{0}", JsonConvert.SerializeObject(dictToken));
                //Logger.DebugFormat("dictIdSecretWithSid:{0}", JsonConvert.SerializeObject(dictIdSecretWithSid));
                if (dictToken.ContainsKey(sid))
                {
                    Token token = dictToken[sid];
                    if (token.ExpireTime > DateTime.Now)
                        return token;
                    else
                    {
                        dictToken.Remove(sid);
                        return null;
                    }
                }
                else
                    return AppSessionBLL.LoadToken(sid);
            }
        }
    }
}
