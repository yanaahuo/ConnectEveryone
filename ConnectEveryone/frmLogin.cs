using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectEveryone
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //判断是否已有程序运行
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("ConnectEveryone");//获取指定的进程名  
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！ConnectEveryone.exe");
                Application.Exit();              //关闭系统
            }
            //初始化全局变量
            ClassStaticData.PathConfigDir = "./config/";
            ClassStaticData.PathConfigXml = ClassStaticData.PathConfigDir + "config.data";
            ClassStaticData.PathHisListDir = "./Host/";
            ClassStaticData.HostUrl = "http://yanaahuo.16mb.com/ConnectEveryone/IpList.php";
            ClassStaticData.UserShareConfig = ClassStaticData.PathConfigDir + "Share.data";
            //初始化版本信息
            ClassStaticData.VisionBranch = "dev";
            ClassStaticData.VisionNum = "0.0.1";
            //尝试读取配置文件
            try
            {
                //加载XML文件
                ClassXml xc2 = new ClassXml(ClassStaticData.PathConfigXml, false, "UserConfig");
                ClassStaticData.UserIP = xc2.FindData("UserIP");
                ClassStaticData.UserNickName = xc2.FindData("UserNickName");
            }
            catch { }
            //窗体实现：
            //识别用户IP地址
            if (ClassStaticData.UserIP == null || ClassStaticData.UserIP == "")
            {
                txtIP.Text = ClassIP.GetLocalIP();
            }
            else
            {
                txtIP.Text = ClassStaticData.UserIP;
            }
            //加载用户昵称
            try
            {
                txtNickName.Text = DecodeEncode.Base642String(ClassStaticData.UserNickName);
            }
            catch { }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //防止多次点击
            btnOK.Enabled = false;

            #region 判断输入是否合法
            //判断用户昵称是否为空
            if (txtNickName.Text == "")
            {
                MessageBox.Show("用户昵称不得为空！");
                btnOK.Enabled = true;
                return;
            }
            //判断用户昵称是否过长
            if (txtNickName.Text.Length > 16)
            {
                MessageBox.Show("昵称不得超过16字符");
                btnOK.Enabled = true;
                return;
            }
            //判断用户名是否合法
            if (!Regex.IsMatch(txtNickName.Text, "^[a-zA-Z0-9_\u4e00-\u9fa5]+$"))
            {
                MessageBox.Show("用户名只允许包含数字0-9字母a-zA-Z汉字下划线_");
                btnOK.Enabled = true;
                return;
            }

            //判断IP地址是否正确
            if (!ClassIP.IsIP(txtIP.Text))
            {
                MessageBox.Show("IP地址错误！");
                btnOK.Enabled = true;
                return;
            }
            #endregion

            #region 创建配置文件
            //配置文件夹不存在
            if (!Directory.Exists(ClassStaticData.PathConfigDir))
            {
                //创建配置文件夹
                try
                {
                    Directory.CreateDirectory(ClassStaticData.PathConfigDir);
                }
                catch (Exception Err)
                {
                    MessageBox.Show("【login.cs致命错误】配置文件夹创建失败" + Err.Message);
                    btnOK.Enabled = true;
                    return;
                }
            }
            //创建配置文件
            //将信息写入全局静态字段
            try
            {
                ClassStaticData.UserNickName = DecodeEncode.String2Base64(txtNickName.Text);
            }
            catch (Exception Err)
            {
                MessageBox.Show("【login.cs致命错误】无法创建静态字段：+" + Err.Message);
                btnOK.Enabled = true;
                return;
            }

            ClassStaticData.UserIP = txtIP.Text;
            //config文件写入
            string NowTime = DateTime.Now.ToFileTimeUtc().ToString();
            ClassXml xc = new ClassXml(ClassStaticData.PathConfigXml, true, "UserConfig");
            xc.InsertNode("//UserConfig", "Info");
            xc.InsertNode("//UserConfig", "ImpInfo");
            xc.AddChildNode("/UserConfig/Info", "UserNickName", ClassStaticData.UserNickName);
            xc.AddChildNode("/UserConfig/ImpInfo", "UserIP", ClassStaticData.UserIP);//用户IP
            xc.AddChildNode("/UserConfig/ImpInfo", "Host", ClassStaticData.HostUrl);
            xc.Save();
            xc = null;          //释放连接
            //判断历史在线主机目录是否存在
            if (!Directory.Exists(ClassStaticData.PathHisListDir))
            {
                try
                {
                    Directory.CreateDirectory(ClassStaticData.PathHisListDir);
                }
                catch (Exception ErrMess)
                {
                    MessageBox.Show("【frmint】致命错误：历史在线主机目录创建失败" + ErrMess.Message);
                    btnOK.Enabled = true;
                    return;
                }
            }
            #endregion

            #region 读取配置文件
            try
            {
                //加载XML文件
                ClassXml xc2 = new ClassXml(ClassStaticData.PathConfigXml, false, "UserConfig");
                ClassStaticData.UserIP = xc2.FindData("UserIP");
                ClassStaticData.UserNickName = xc2.FindData("UserNickName");
                //ClassStaticData.HostUrl = xc2.FindData("Host");
            }
            catch (Exception ErrMess)
            {
                MessageBox.Show("【Login.cs致命错误：】配置文件读取失败" + ErrMess.Message);
                btnOK.Enabled = true;
                try
                {
                    File.Delete(ClassStaticData.PathConfigXml);
                }
                catch (Exception ErrMess2)
                {
                    MessageBox.Show("【frmInitClass】致命错误：配置文件删除失败，请手动删除config文件夹并重启程序" + ErrMess2.Message);
                    btnOK.Enabled = true;
                }
                Application.Exit();//结束程序
            }
            #endregion

            #region 读取IP列表
            try
            {
                string[] IPArr = ClassString.SplitStr(ClassWeb.GetHtml(ClassStaticData.HostUrl + "?action=GetIPList&IP=" + ClassStaticData.UserIP));

                foreach (var item in IPArr)
                {
                    try
                    {
                        if (ClassIP.IsIP(item))
                            ClassStaticData.OnlineHost.Add(item, "");
                    }
                    catch { }
                }

                //向全网通知更改
                foreach (var item in ClassStaticData.OnlineHost)
                {
                    ClassShare.SendShareList(item.Key);
                }
            }
            catch
            {
                MessageBox.Show("与服务器通讯失败");
                this.Close();
                return;
            }
            #endregion

            #region 读取我的分享文件
            //配置文件不存在
            if (!File.Exists(ClassStaticData.UserShareConfig))
            {
                //尝试创建配置文件
                try
                {
                    File.Create(ClassStaticData.UserShareConfig);
                }
                catch(Exception ErrMess)
                {
                    MessageBox.Show("【Login.cs致命错误：】分享列表文件创建失败" + ErrMess.Message);
                    Application.Exit();
                }
            }
            //读取列表到字段
            StreamReader sr = new StreamReader(ClassStaticData.UserShareConfig, Encoding.UTF8);
            foreach (var item in ClassString.SplitStr(sr.ReadLine()))
            {
                if(File.Exists(item) || Directory.Exists(item))
                    ClassStaticData.UserShareList.Add(item);
            }
            sr.Close();
            //读取文件夹内容
            foreach (var item in ClassStaticData.UserShareList)
            {
                if (Directory.Exists(Convert.ToString(item)))
                {
                    ClassShare.GetAll(Convert.ToString(item),"mine");
                }
                if (File.Exists(Convert.ToString(item)))
                {
                    ClassStaticData.AllFileList.Add(item);
                }
               
            }

            #endregion
            //显示主窗体
            frmMain frmMainContral = new frmMain();
            frmMainContral.Show();
            //隐藏自己
            this.Visible = false;
        }
    }
}