using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
    public class TextHasher
    {
        public static string GetSHA256Hash(string plainText)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(plainText);
            string hashString = string.Empty;

            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(buffer);
            foreach (byte _byte in hashBytes)
            {
                hashString += string.Format("{0:x2}", _byte);
            }

            return hashString;
        }
    }
}
