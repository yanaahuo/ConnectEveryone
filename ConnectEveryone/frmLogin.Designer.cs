namespace ConnectEveryone
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labNickName = new System.Windows.Forms.Label();
            this.labIP = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.labConnectEveryone = new System.Windows.Forms.Label();
            this.labDes = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labNickName
            // 
            this.labNickName.AutoSize = true;
            this.labNickName.Font = new System.Drawing.Font("宋体", 14F);
            this.labNickName.Location = new System.Drawing.Point(66, 172);
            this.labNickName.Name = "labNickName";
            this.labNickName.Size = new System.Drawing.Size(82, 24);
            this.labNickName.TabIndex = 0;
            this.labNickName.Text = "昵称：";
            // 
            // labIP
            // 
            this.labIP.AutoSize = true;
            this.labIP.Font = new System.Drawing.Font("宋体", 14F);
            this.labIP.Location = new System.Drawing.Point(66, 233);
            this.labIP.Name = "labIP";
            this.labIP.Size = new System.Drawing.Size(58, 24);
            this.labIP.TabIndex = 1;
            this.labIP.Text = "IP：";
            // 
            // txtNickName
            // 
            this.txtNickName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNickName.Location = new System.Drawing.Point(185, 166);
            this.txtNickName.MaxLength = 16;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(222, 30);
            this.txtNickName.TabIndex = 2;
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("宋体", 12F);
            this.txtIP.Location = new System.Drawing.Point(185, 227);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(222, 30);
            this.txtIP.TabIndex = 3;
            // 
            // labConnectEveryone
            // 
            this.labConnectEveryone.AutoSize = true;
            this.labConnectEveryone.Font = new System.Drawing.Font("宋体", 20F);
            this.labConnectEveryone.Location = new System.Drawing.Point(73, 31);
            this.labConnectEveryone.Name = "labConnectEveryone";
            this.labConnectEveryone.Size = new System.Drawing.Size(270, 34);
            this.labConnectEveryone.TabIndex = 4;
            this.labConnectEveryone.Text = "ConnectEveryone";
            // 
            // labDes
            // 
            this.labDes.AutoSize = true;
            this.labDes.Font = new System.Drawing.Font("宋体", 16F);
            this.labDes.Location = new System.Drawing.Point(206, 105);
            this.labDes.Name = "labDes";
            this.labDes.Size = new System.Drawing.Size(201, 27);
            this.labDes.TabIndex = 5;
            this.labDes.Text = "局域网文件分享";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 14F);
            this.btnOK.Location = new System.Drawing.Point(79, 304);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(150, 50);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("宋体", 14F);
            this.btnAbout.Location = new System.Drawing.Point(272, 304);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(135, 49);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 379);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labDes);
            this.Controls.Add(this.labConnectEveryone);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.labIP);
            this.Controls.Add(this.labNickName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectEveryone";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNickName;
        private System.Windows.Forms.Label labIP;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label labConnectEveryone;
        private System.Windows.Forms.Label labDes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbout;
    }
}

