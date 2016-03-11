using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace ConnectEveryone
{
    public class ClassUdp
    {
        /// <summary>
        /// 服务器端
        /// </summary>
        /// <param name="port">待监听端口</param>
        public void ServerListen(int port)
        {
            UdpClient udpclient = new UdpClient(port);
            while (true)
            {
                try
                {
                    IPEndPoint ipendpoint = null;
                    byte[] bytes = udpclient.Receive(ref ipendpoint); //停在这等待数据
                    string data = Encoding.Default.GetString(bytes, 0, bytes.Length);

                    Console.WriteLine("{0:HH:mm:ss}->接收数据(from {1}:{2})：{3}", DateTime.Now, ipendpoint.Address, ipendpoint.Port, data);
                    Console.WriteLine(data);

                    if (Regex.IsMatch(data, "^ConnectEveryone"))
                    {
                        #region 新用户请求
                        //昵称记录系统
                        if (data == "ConnectEveryoneAskNickName")
                        {
                            //回应NickName
                            ClientSend(Convert.ToString(ipendpoint.Address), 55233, "ConnectEveryoneNickName" + ClassStaticData.UserNickName);
                        }
                        //昵称回应系统
                        if (Regex.IsMatch(data, "ConnectEveryoneNickName"))
                        {
                            string str = Regex.Replace(data, "ConnectEveryoneNickName", "");
                            //若昵称为空，则忽略
                            if (str != "")
                            {
                                //添加到在线列表
                                try
                                {
                                    ClassStaticData.OnlineHost[Convert.ToString(ipendpoint.Address)] = str;
                                }
                                catch { }

                            }

                        }

                        //分享列表识别系统
                        if (Regex.IsMatch(data, "ConnectEveryoneShareList"))
                        {
                            string str = Regex.Replace(data, "ConnectEveryoneShareList", "");
                            str = Convert.ToString(ipendpoint.Address) + "|" + str;
                            ClassStaticData.AllFileList.Add(str);
                        }

                    }
                    #endregion


                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0:HH:mm:ss}->{1}", DateTime.Now, ex.Message);
                }


            }

        }

        /// <summary>
        /// 客户端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="message"></param>
        public void ClientSend(string ip, int port, string message)
        {
            try
            {
                UdpClient udpclient = new UdpClient();
                IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse(ip), port);
                byte[] data = Encoding.Default.GetBytes(message);
                udpclient.Send(data, data.Length, ipendpoint);
                udpclient.Close();

                Console.WriteLine("{0:HH:mm:ss}->发送数据(to {1})：{2}", DateTime.Now, ip, message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0:HH:mm:ss}->{1}", DateTime.Now, ex.Message);
            }

        }





    }

}
