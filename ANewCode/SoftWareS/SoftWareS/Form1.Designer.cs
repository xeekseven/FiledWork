namespace SoftWareS
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.StartListenBtn = new System.Windows.Forms.Button();
            this.StopListenBtn = new System.Windows.Forms.Button();
            this.IpTxt = new System.Windows.Forms.TextBox();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPORT = new System.Windows.Forms.Label();
            this.listBoxGet = new System.Windows.Forms.ListBox();
            this.listBoxSend = new System.Windows.Forms.ListBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.logBoard = new Huike.Util.Logger.UI.LogBoard();
            this.sendCountTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartListenBtn
            // 
            this.StartListenBtn.Location = new System.Drawing.Point(331, 24);
            this.StartListenBtn.Name = "StartListenBtn";
            this.StartListenBtn.Size = new System.Drawing.Size(75, 23);
            this.StartListenBtn.TabIndex = 0;
            this.StartListenBtn.Text = "开始监听";
            this.StartListenBtn.UseVisualStyleBackColor = true;
            this.StartListenBtn.Click += new System.EventHandler(this.StartListenBtn_Click);
            // 
            // StopListenBtn
            // 
            this.StopListenBtn.Location = new System.Drawing.Point(331, 93);
            this.StopListenBtn.Name = "StopListenBtn";
            this.StopListenBtn.Size = new System.Drawing.Size(75, 23);
            this.StopListenBtn.TabIndex = 1;
            this.StopListenBtn.Text = "停止监听";
            this.StopListenBtn.UseVisualStyleBackColor = true;
            // 
            // IpTxt
            // 
            this.IpTxt.Location = new System.Drawing.Point(118, 26);
            this.IpTxt.Name = "IpTxt";
            this.IpTxt.Size = new System.Drawing.Size(163, 21);
            this.IpTxt.TabIndex = 2;
            this.IpTxt.Text = "127.0.0.1";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(118, 95);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(163, 21);
            this.PortTxt.TabIndex = 3;
            this.PortTxt.Text = "8806";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(55, 29);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(29, 12);
            this.labelIP.TabIndex = 4;
            this.labelIP.Text = "IP：";
            // 
            // labelPORT
            // 
            this.labelPORT.AutoSize = true;
            this.labelPORT.Location = new System.Drawing.Point(55, 98);
            this.labelPORT.Name = "labelPORT";
            this.labelPORT.Size = new System.Drawing.Size(41, 12);
            this.labelPORT.TabIndex = 5;
            this.labelPORT.Text = "Port：";
            // 
            // listBoxGet
            // 
            this.listBoxGet.FormattingEnabled = true;
            this.listBoxGet.ItemHeight = 12;
            this.listBoxGet.Location = new System.Drawing.Point(57, 147);
            this.listBoxGet.Name = "listBoxGet";
            this.listBoxGet.Size = new System.Drawing.Size(172, 136);
            this.listBoxGet.TabIndex = 6;
            // 
            // listBoxSend
            // 
            this.listBoxSend.FormattingEnabled = true;
            this.listBoxSend.ItemHeight = 12;
            this.listBoxSend.Location = new System.Drawing.Point(331, 147);
            this.listBoxSend.Name = "listBoxSend";
            this.listBoxSend.Size = new System.Drawing.Size(172, 136);
            this.listBoxSend.TabIndex = 7;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(57, 304);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(224, 60);
            this.txtSend.TabIndex = 8;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(331, 304);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(100, 30);
            this.sendBtn.TabIndex = 9;
            this.sendBtn.Text = "发送数据";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // logBoard
            // 
            this.logBoard.DoubleBufferingEnabled = true;
            this.logBoard.HighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(249)))));
            this.logBoard.IconImageList = null;
            this.logBoard.Location = new System.Drawing.Point(534, 12);
            this.logBoard.Name = "logBoard";
            this.logBoard.SelectedIndex = -1;
            this.logBoard.Size = new System.Drawing.Size(424, 352);
            this.logBoard.TabIndex = 10;
            // 
            // sendCountTxt
            // 
            this.sendCountTxt.Location = new System.Drawing.Point(389, 347);
            this.sendCountTxt.Name = "sendCountTxt";
            this.sendCountTxt.Size = new System.Drawing.Size(41, 21);
            this.sendCountTxt.TabIndex = 11;
            this.sendCountTxt.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "发送次数";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendCountTxt);
            this.Controls.Add(this.logBoard);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.listBoxSend);
            this.Controls.Add(this.listBoxGet);
            this.Controls.Add(this.labelPORT);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.IpTxt);
            this.Controls.Add(this.StopListenBtn);
            this.Controls.Add(this.StartListenBtn);
            this.Name = "Form1";
            this.Text = "SoftWareS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartListenBtn;
        private System.Windows.Forms.Button StopListenBtn;
        private System.Windows.Forms.TextBox IpTxt;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPORT;
        private System.Windows.Forms.ListBox listBoxGet;
        private System.Windows.Forms.ListBox listBoxSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button sendBtn;
        private Huike.Util.Logger.UI.LogBoard logBoard;
        private System.Windows.Forms.TextBox sendCountTxt;
        private System.Windows.Forms.Label label1;
    }
}

