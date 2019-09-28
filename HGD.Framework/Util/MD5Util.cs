using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Util
{
    public class MD5Util
    {
        /// <summary>
        /// 字符串转md5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string getHashStr(string text)
        {
            //
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static byte[] getHash(byte[] data)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                return md5.ComputeHash(data);
            }
        }

        public static string getHashWithCheckSum(string text)
        {
            //
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

                byte checkSum = 0;

                foreach (var b in hash)
                    checkSum += b;

                byte[] hashWithCheckSum = new byte[hash.Length + 1];
                Array.Copy(hash, hashWithCheckSum, hash.Length);
                hashWithCheckSum[hashWithCheckSum.Length - 1] = checkSum;

                return BitConverter.ToString(hashWithCheckSum).Replace("-", "").ToLower();
            }
        }

        public static bool checkHashWithCheckSum(string hashStrWithCheckSum)
        {
            if (hashStrWithCheckSum.Length != 34)
                return false;

            byte[] hashWithCheckSum = new byte[17];
            for (int i = 0; i < 34; i += 2)
            {
                //
                string ch = hashStrWithCheckSum.Substring(i, 2);
                byte b = 0;
                if (!byte.TryParse(ch, System.Globalization.NumberStyles.HexNumber, null, out b))
                    return false;

                hashWithCheckSum[i / 2] = b;
            }

            byte checkSum = 0;
            for (int j = 0; j < 16; j++)
                checkSum += hashWithCheckSum[j];

            return checkSum == hashWithCheckSum[16];

        }
    }
}
