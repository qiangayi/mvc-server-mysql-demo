using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Util
{
    public class RSAUtil
    {
        private static string publicAndPrivateKey = "<RSAKeyValue><Modulus>zBWZNLmXRV27RaRFecgO/i8+pkAgIkFKPdFXkZRoNANO9aPbGMIgoM/3Q5KwP54sXc4466TH0lO8HC47dEYfLPkbHdsWerxUFswnWosCxjQjBapWEzUrIucyqsZR4liHVKDrZ99oip+r1T5RqAoys2e3nCRUEr+KHeIGtcMwN2E=</Modulus><Exponent>AQAB</Exponent><P>8aYDaGLjxJZlOt+tgpoum2X3Pm/WfZKaglcdduH8oF9//b5Z1V1BCBYenT9bcB3ZEufFyktWgUR2SHUFWc9TOQ==</P><Q>2DR3TAzMIbXa8wq6DrEJmeyTLao7zbzC4AnaAcJguwW2K0ez7GoiRxBUCfD9NXace6oSF1RgTHbA+CqsVGa9aQ==</Q><DP>MjVtRdYuPx2EoQvysE0629z+10FDjsnUQrq5C4d/Bw9wt5dCcRu0NGrsJ34PkKcTAGOZ7CNlMOy5quptlzCFuQ==</DP><DQ>umzTCRJn2hFzD+qJ8C0beEwTxGZrVsWSy5fzEV1IBzuvjrYvIIWLtPcRX9kanMT/vWoyW0d4Gba0QciZ+9TzMQ==</DQ><InverseQ>uq9kG3DbAhoA9pOIgsBCs4gxoX9+2WdWg9sHhO9ZjrukubJ8DfBquLVd8HBYYnBbTrpZlGwn4I9LX90grE0UfA==</InverseQ><D>eMZPZGRwoRxXN19/vhImzUYoTTqlyZ/Zz7uTlxO8lwteLwBJKN25cXGhYtvscbmph9oC1XEuz8m+CO9TP/w/dc8A8YxuKJuBCAGdEC238tBZkJXD7MZ4yOtRLktJ5Onoxx8tG6dtN1bvmOjXTaS+ANwA/aR8F+2CA/qAfGntoAE=</D></RSAKeyValue>";
        public static byte[] Decrypt(byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                rsa.FromXmlString(publicAndPrivateKey);

                return rsa.Decrypt(data, false);
            }
        }

        public static byte[] Encrypt(byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                rsa.FromXmlString(publicAndPrivateKey);

                return rsa.Encrypt(data, false);
            }
        }

        public static byte[] SignData(byte[] data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                rsa.FromXmlString(publicAndPrivateKey);

                return rsa.SignData(data, new SHA1CryptoServiceProvider());
            }
        }

        public static bool VerifyData(byte[] data, byte[] signedData)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                rsa.FromXmlString(publicAndPrivateKey);

                return rsa.VerifyData(data, new SHA1CryptoServiceProvider(), signedData);
            }
        }
    }
    
}
