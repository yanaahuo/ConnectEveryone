namespace ConnectEveryone
{
    partial class frmMyShare
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
            this.txtSelectFile = new System.Windows.Forms.TextBox();
            this.txtSelectDir = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnDir = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labMyShareList = new System.Windows.Forms.Label();
            this.libMyShareList = new System.Windows.Forms.ListBox();
            this.cmsShareRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsShareRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSelectFile
            // 
            this.txtSelectFile.Location = new System.Drawing.Point(43, 48);
            this.txtSelectFile.Name = "txtSelectFile";
            this.txtSelectFile.Size = new System.Drawing.Size(330, 25);
            this.txtSelectFile.TabIndex = 0;
            // 
            // txtSelectDir
            // 
            this.txtSelectDir.Location = new System.Drawing.Point(41, 105);
            this.txtSelectDir.Name = "txtSelectDir";
            this.txtSelectDir.Size = new System.Drawing.Size(332, 25);
            this.txtSelectDir.TabIndex = 1;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(429, 44);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(109, 29);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "共享文件";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(429, 101);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(109, 30);
            this.btnDir.TabIndex = 3;
            this.btnDir.Text = "共享文件夹";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(573, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 87);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labMyShareList
            // 
            this.labMyShareList.AutoSize = true;
            this.labMyShareList.Font = new System.Drawing.Font("宋体", 16F);
            this.labMyShareList.Location = new System.Drawing.Point(221, 188);
            this.labMyShareList.Name = "labMyShareList";
            this.labMyShareList.Size = new System.Drawing.Size(228, 27);
            this.labMyShareList.TabIndex = 5;
            this.labMyShareList.Text = "我的共享文件列表";
            // 
            // libMyShareList
            // 
            this.libMyShareList.ContextMenuStrip = this.cmsShareRight;
            this.libMyShareList.Font = new System.Drawing.Font("宋体", 12F);
            this.libMyShareList.FormattingEnabled = true;
            this.libMyShareList.HorizontalScrollbar = true;
            this.libMyShareList.ItemHeight = 20;
            this.libMyShareList.Location = new System.Drawing.Point(41, 248);
            this.libMyShareList.Name = "libMyShareList";
            this.libMyShareList.Size = new System.Drawing.Size(631, 304);
            this.libMyShareList.TabIndex = 6;
            this.libMyShareList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.libMyShareList_MouseDoubleClick);
            // 
            // cmsShareRight
            // 
            this.cmsShareRight.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsShareRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRemoveAll});
            this.cmsShareRight.Name = "cmsShareRight";
            this.cmsShareRight.Size = new System.Drawing.Size(115, 30);
            this.cmsShareRight.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmRemoveAll
            // 
            this.tsmRemoveAll.Name = "tsmRemoveAll";
            this.tsmRemoveAll.Size = new System.Drawing.Size(181, 26);
            this.tsmRemoveAll.Text = "清空";
            this.tsmRemoveAll.Click += new System.EventHandler(this.tsmRemoveAll_Click);
            // 
            // frmMyShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 566);
            this.Controls.Add(this.libMyShareList);
            this.Controls.Add(this.labMyShareList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtSelectDir);
            this.Controls.Add(this.txtSelectFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMyShare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分享";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMyShare_FormClosed);
            this.Load += new System.EventHandler(this.frmMyShare_Load);
            this.cmsShareRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSelectFile;
        private System.Windows.Forms.TextBox txtSelectDir;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labMyShareList;
        private System.Windows.Forms.ListBox libMyShareList;
        private System.Windows.Forms.ContextMenuStrip cmsShareRight;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveAll;
    }
}