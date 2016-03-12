using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ConnectEveryone
{
    public partial class frmMyShare : Form
    {
        public frmMyShare()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in open.FileNames)
                {
                    txtSelectFile.Text += item + "|";
                }
                
            }
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtSelectDir.Text = open.SelectedPath;
            }
        }

        private void frmMyShare_Load(object sender, EventArgs e)
        {
            libMyShareList.Items.Clear();
            //刷新listbox内容
            try
            {
                foreach (var item in ClassStaticData.UserShareList)
                {
                    libMyShareList.Items.Add(item);
                }
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            //添加分享文件夹
            if(txtSelectDir.Text != "")
            {
                //判断文件夹是否存在
                if (Directory.Exists(txtSelectDir.Text))
                {
                    //判断是否已分享
                    if (libMyShareList.Items.Contains(txtSelectDir.Text))
                    {
                        MessageBox.Show(txtSelectDir.Text + "已存在");
                        return;
                    }
                    MessageBox.Show(txtSelectDir.Text + "添加成功！");
                    //刷新listbox内容
                    libMyShareList.Items.Add(txtSelectDir.Text);
                    //添加全局写入
                    ClassStaticData.UserShareList.Add(txtSelectDir.Text);
                    //清空输入栏
                    txtSelectDir.Text = "";
                }
                else
                {
                    MessageBox.Show("文件夹地址不存在");
                }
            }
            //添加分享文件
            if(txtSelectFile.Text != "")
            {
                //拆分字符串
               string[] str =  ClassString.SplitStr(txtSelectFile.Text);
                foreach (var item in str)
                {
                    if(item != "")
                    {
                        if (File.Exists(item))
                        {
                            //判断是否已分享
                            if (libMyShareList.Items.Contains(item))
                            {
                                MessageBox.Show(item + "已存在");
                            }
                            else
                            {
                                //刷新listbox内容
                                libMyShareList.Items.Add(item);
                                //添加全局写入
                                ClassStaticData.UserShareList.Add(item);
                                //清空输入栏
                                txtSelectFile.Text = "";
                            }
                           

                        }
                        else
                        {
                            MessageBox.Show(item + "文件地址不存在");
                        }
                    }
                }
                
            }
            btnAdd.Enabled = true;
            //写入配置文件
            string text = "";
            foreach (var item in libMyShareList.Items)
            {
                text += item + "\n";
            }
            FileStream fs = new FileStream(ClassStaticData.UserShareConfig, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(text);
            sw.Close();
            fs.Close();

        }

        private void frmMyShare_FormClosed(object sender, FormClosedEventArgs e)
        {


            //遍历所有文件
            foreach (var item in ClassStaticData.UserShareList)
            {
                if (Directory.Exists(Convert.ToString(item)))
                {
                    ClassShare.GetAll(Convert.ToString(item));
                }
                if (File.Exists(Convert.ToString(item)))
                {
                    //判断是否重复
                    if (!ClassStaticData.MyFileList.Contains(Convert.ToString(item)))
                    {
                        ClassStaticData.MyFileList.Add(Convert.ToString(item));
                    }

                }
            }
            //向全网通知更改
            foreach (var item in ClassStaticData.OnlineHost)
            {
                ClassShare.SendShareList(item.Key);
            }
            //写入配置文件
            string TmpShareStr = "";
            foreach (var item in ClassStaticData.UserShareList)
            {
                TmpShareStr += item + "|";
            }
            try
            {
                ClassShare.Write(TmpShareStr);
            }
            catch
            {
                MessageBox.Show("【警告frmMyshare.cs】：用户分享列表写入失败！");
            }
            
           
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsmRemoveAll_Click(object sender, EventArgs e)
        {
            //初始化确认对话框
            DialogResult a = MessageBox.Show("是否取消所有文件共享？双击文件名可逐个取消文件共享","提示",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {

                ClassStaticData.UserShareList.Clear();
                libMyShareList.Items.Clear();
                ClassStaticData.MyFileList.Clear();
                try
                {
                    File.Delete(ClassStaticData.UserShareConfig);
                }
                catch { }
            }
        }

        private void libMyShareList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //防止双击空行
            if ((string)libMyShareList.SelectedItem != null)
            {
                DialogResult a = MessageBox.Show("确定删除" + (string)libMyShareList.SelectedItem + "么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    ClassStaticData.UserShareList.Remove((string)libMyShareList.SelectedItem);
                    ClassStaticData.MyFileList.Remove((string)libMyShareList.SelectedItem);
                    libMyShareList.Items.Remove((string)libMyShareList.SelectedItem);
                }
            }
        }
    }
}
