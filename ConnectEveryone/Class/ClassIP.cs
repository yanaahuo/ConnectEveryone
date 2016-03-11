using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEveryone
{
    public static class ClassIP
    {
        /// <summary>
        /// 获取本机在局域网的IP地址
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GetLocalIP()
        {
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        /// <summary>
        /// 判断IP地址是否正确
        /// </summary>
        /// <param name="ipStr"></param>
        /// <returns></returns>
        public static bool IsIP(string ipStr)
        {
            IPAddress ip;
            if (IPAddress.TryParse(ipStr, out ip))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存IP到在线列表
        /// </summary>
        /// <param name="IP"></param>
        public static void SaveIP(string IP)
        {
            ClassStaticData.OnlineHost.Add(IP, "");
        }
        /// <summary>
        /// 保存IP到在线列表
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="NickName"></param>
        public static void SaveIP(string IP,string NickName)
        {
            //判断IP地址是否已存在，判断IP是否合法
            if (!ClassStaticData.OnlineHost.ContainsKey(IP)&&IsIP(IP))
            {
                ClassStaticData.OnlineHost.Add(IP, NickName);
            }
            
        }
    }
}
