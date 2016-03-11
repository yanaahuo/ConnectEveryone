using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEveryone
{
    class ClassString
    {
        /// <summary>
        /// 特定字符分割字符串
        /// </summary>
        /// <param name="str">待分割字符串</param>
        /// <returns></returns>
        public static string[] SplitStr(string str)
        {
            string[] s= {""};
            try
            {
                s = str.Split(new char[] { '|' });
            }
            catch
            {
            
            }
            
            return s;
        }
    }
}
