using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace DrawBoard.EncryptionDecryption
{
    public class EncryptDecrypt
    {
        //암호화
        public static string Protect(string str)
        {
            byte[] entropy = Encoding.UTF8.GetBytes(Assembly.GetExecutingAssembly().FullName);
            byte[] data = Encoding.UTF8.GetBytes(str);
            string protectedData = Convert.ToBase64String(ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser));
            return protectedData;
        }

        //복호화
        public static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.UTF8.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.UTF8.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }
    }
}
