using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HarlemErpBusiness
{
    public static class Crypto
    {
        public static string GenerateMD5Hash(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, input);
            }
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            return 0 == (StringComparer.OrdinalIgnoreCase).Compare(GetMd5Hash(md5Hash, input), hash);
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
