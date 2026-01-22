using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Common
{
    public class SiteConfig
    {
        public static string fileurl = @"/Data";
        //public static string fileurl = "@"D:\HostRoot\HostWeb\Freemold\Data";

        public static string fileuploadfolder = @"D:\HostRoot\HostWeb\Freemold";
        public static string fileuploadpath = @"D:\HostRoot\HostWeb\Freemold\Data\Temp\";


        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string Generate(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

            char[] result = new char[length];

            // 암호학적으로 안전한 랜덤 (권장)
            for (int i = 0; i < length; i++)
            {
                int idx = RandomNumberGenerator.GetInt32(Alphabet.Length); // 0 ~ 61
                result[i] = Alphabet[idx];
            }

            return new string(result);
        }

    }
}
