namespace ConnectEveryone
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmAskNickName = new System.Windows.Forms.Timer(this.components);
            this.tmFreshHost = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMyShare = new System.Windows.Forms.ToolStripMenuItem();
            this.libAllFile = new System.Windows.Forms.ListBox();
            this.tmOnce = new System.Windows.Forms.Timer(this.components);
            this.tsmRefhreshFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmAskNickName
            // 
            this.tmAskNickName.Enabled = true;
            this.tmAskNickName.Interval = 1000;
            this.tmAskNickName.Tick += new System.EventHandler(this.tmAskNickName_Tick);
            // 
            // tmFreshHost
            // 
            this.tmFreshHost.Enabled = true;
            this.tmFreshHost.Interval = 700000;
            this.tmFreshHost.Tick += new System.EventHandler(this.tmFreshHost_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMyShare,
            this.tsmRefhreshFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMyShare
            // 
            this.tsmMyShare.Name = "tsmMyShare";
            this.tsmMyShare.Size = new System.Drawing.Size(81, 24);
            this.tsmMyShare.Text = "我的分享";
            this.tsmMyShare.Click += new System.EventHandler(this.tsmMyShare_Click);
            // 
            // libAllFile
            // 
            this.libAllFile.BackColor = System.Drawing.SystemColors.Window;
            this.libAllFile.Font = new System.Drawing.Font("宋体", 12F);
            this.libAllFile.FormattingEnabled = true;
            this.libAllFile.ItemHeight = 20;
            this.libAllFile.Location = new System.Drawing.Point(0, 30);
            this.libAllFile.Name = "libAllFile";
            this.libAllFile.Size = new System.Drawing.Size(1021, 524);
            this.libAllFile.TabIndex = 1;
            this.libAllFile.DoubleClick += new System.EventHandler(this.libAllFile_DoubleClick);
            // 
            // tmOnce
            // 
            this.tmOnce.Enabled = true;
            this.tmOnce.Interval = 5000;
            this.tmOnce.Tick += new System.EventHandler(this.tmFreshLb_Tick);
            // 
            // tsmRefhreshFile
            // 
            this.tsmRefhreshFile.Name = "tsmRefhreshFile";
            this.tsmRefhreshFile.Size = new System.Drawing.Size(141, 24);
            this.tsmRefhreshFile.Text = "立即刷新文件列表";
            this.tsmRefhreshFile.Click += new System.EventHandler(this.tsmRefhreshFile_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 549);
            this.Controls.Add(this.libAllFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "ConnectEveryone";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeBegin += new System.EventHandler(this.frmMain_ResizeBegin);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmAskNickName;
        private System.Windows.Forms.Timer tmFreshHost;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMyShare;
        public System.Windows.Forms.ListBox libAllFile;
        private System.Windows.Forms.Timer tmOnce;
        private System.Windows.Forms.ToolStripMenuItem tsmRefhreshFile;
    }
}