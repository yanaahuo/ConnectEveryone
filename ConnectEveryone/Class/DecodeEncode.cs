using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEveryone
{
    class DecodeEncode
    {
        /// <summary>
        /// String转换为BASE64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string String2Base64(string str)
        {


            System.Text.Encoding encode = System.Text.Encoding.UTF8;
            byte[] bytedata = encode.GetBytes(str);
            return Convert.ToBase64String(bytedata, 0, bytedata.Length);
           
        }


        /// <summary>
        /// BASE64转换为STRING
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base642String(string str)
        {
            byte[] bpath = Convert.FromBase64String(str);
            return System.Text.ASCIIEncoding.UTF8.GetString(bpath);
        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="str_sha1_in"></param>
        /// <returns></returns>
        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "");
            return str_sha1_out;
        }
    }
}
