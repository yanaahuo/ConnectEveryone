using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ConnectEveryone
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            //启动监听端口
            Thread thListen = new Thread(Listen55233);
            thListen.Start();
            //允许其他线程访问
            CheckForIllegalCrossThreadCalls = false;
        }

        //监听端口55233
        private void Listen55233()
        {
            ClassUdp ClassUdpContral = new ClassUdp();
            ClassUdpContral.ServerListen(55233, this);
        }

        bool IfRequest = true;
        private void tmAskNickName_Tick(object sender, EventArgs e)
        {
            tmAskNickName.Interval = 10000;
            //判断是否启动查询
            if (IfRequest)
            {
                //查询是否存在昵称为空
                if (ClassStaticData.OnlineHost.ContainsValue(""))
                {
                    //开始查找昵称为空的IP
                    List<string> test = new List<string>(ClassStaticData.OnlineHost.Keys);
                    ClassUdp UdpContral = new ClassUdp();
                    for (int i = 0; i < ClassStaticData.OnlineHost.Count; i++)
                    {
                        if (ClassStaticData.OnlineHost[test[i]] == "" && ClassStaticData.OnlineHost[test[i]] != ClassStaticData.UserIP)
                        {
                            //发送昵称请求
                            UdpContral.ClientSend(test[i], 55233, "ConnectEveryoneAskNickName");
                        }
                    }
                }
                IfRequest = false;
            }
            else
            {

                //开始查找昵称为空的IP
                List<string> test = new List<string>(ClassStaticData.OnlineHost.Keys);
                ClassUdp UdpContral = new ClassUdp();
                for (int i = 0; i < ClassStaticData.OnlineHost.Count; i++)
                {
                    if (ClassStaticData.OnlineHost[test[i]] == "" && ClassStaticData.OnlineHost[test[i]] != ClassStaticData.UserIP)
                    {
                        //删除
                        try
                        {
                            ClassStaticData.OnlineHost.Remove(test[i]);
                        }
                        catch { }
                    }
                }
                IfRequest = true;
            }
        }

        private void tmFreshHost_Tick(object sender, EventArgs e)
        {
            #region 读取IP列表
            string[] IPArr = ClassString.SplitStr(ClassWeb.GetHtml(ClassStaticData.HostUrl + "?action=GetIPList&IP=" + ClassStaticData.UserIP));
            //清理在线列表
            ClassStaticData.OnlineHost.Clear();
            //清理全局文件列表
            ClassStaticData.AllFileList.Clear();
            foreach (var item in IPArr)
            {
                try
                {
                    if (ClassIP.IsIP(item))
                    {
                        ClassStaticData.OnlineHost.Add(item, "");
                        ClassShare.SendShareList(item);
                        IfRequest = true;
                        tmAskNickName.Start();
                    }

                }
                catch { }
            }
            #endregion

           
        }

        private void tsmMyShare_Click(object sender, EventArgs e)
        {
            frmMyShare frmMyShareContral = new frmMyShare();
            frmMyShareContral.ShowDialog();

        }

        private void tsmFreshList_Click(object sender, EventArgs e)
        {


        }

        private void frmMain_ResizeBegin(object sender, EventArgs e)
        {
            libAllFile.Width = this.Width - 17;
            libAllFile.Height = this.Height - 53;
        }

        private void tmOnce_Tick(object sender, EventArgs e)
        {

        }

        private void tmFreshLb_Tick(object sender, EventArgs e)
        {
            //请求全网文件
            //直接放在LOAD里导致监听线程未启动
            ClassUdp ClassUdpContral = new ClassUdp();
            foreach (var item in ClassStaticData.OnlineHost)
            {
                ClassUdpContral.ClientSend(item.Key, 55233, "ConnectEveryoneAskShareList");
            }
            tmOnce.Enabled = false;
        }

        private void libAllFile_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(((ListItem)libAllFile.SelectedItem).Text);
            MessageBox.Show(((ListItem)libAllFile.SelectedItem).Value.ToString());
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //杀死自己
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void tsmRefhreshFile_Click(object sender, EventArgs e)
        {
            tsmRefhreshFile.Enabled = false;
            #region 读取IP列表
            string[] IPArr = ClassString.SplitStr(ClassWeb.GetHtml(ClassStaticData.HostUrl + "?action=GetIPList&IP=" + ClassStaticData.UserIP));
            //清理在线列表
            ClassStaticData.OnlineHost.Clear();
            //清理全局文件列表
            ClassStaticData.AllFileList.Clear();
            ClassUdp ClassUdpContral = new ClassUdp();
            foreach (var item in IPArr)
            {
                try
                {
                    if (ClassIP.IsIP(item))
                    {
                        ClassStaticData.OnlineHost.Add(item, "");
                        ClassUdpContral.ClientSend(item, 55233, "ConnectEveryoneAskShareList");
                    }

                }
                catch { }
            }
            #endregion
            tsmRefhreshFile.Enabled = true;
        }
    }
}
