using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEveryone
{
    class ClassShare
    {
        /// <summary>
        /// 发送分享列表
        /// </summary>
        /// <param name="IP"></param>
        public static void SendShareList(string IP)
        {
            //待发送字符串
            string str="ConnectEveryoneShareList";
            foreach (var item in ClassStaticData.MyFileList)
            {
                str += item + "|";
            }
            ClassUdp ClassUdpContral = new ClassUdp();
            try
            {
                ClassUdpContral.ClientSend(IP, 55233, str);
            }
            catch { }
        }

        /// <summary>
        /// 遍历分享文件
        /// </summary>
        /// <param name="dir"></param>
        public static void GetAll(string dir,string Who)//搜索文件夹中的文件
        {
            String[] files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                //判断是否重复
                if (Who == "mine")
                {
                    if (!ClassStaticData.MyFileList.Contains(item))
                    {
                        ClassStaticData.MyFileList.Add(item);
                    }
                }else if(Who == "all")
                {
                    if (!ClassStaticData.AllFileList.Contains(item))
                    {
                        ClassStaticData.AllFileList.Add(item);
                    }
                }
            }
        }
        /// <summary>
        /// 将本机分享列表写入配置文件
        /// </summary>
        /// <param name="text"></param>
        public static void  Write(string text)
        {
            FileStream fs = new FileStream(ClassStaticData.UserShareConfig, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }

    }
}
