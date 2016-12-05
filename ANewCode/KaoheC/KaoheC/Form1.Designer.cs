namespace KaoheC
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
            this.components = new System.ComponentModel.Container();
            this.connectBtn = new System.Windows.Forms.Button();
            this.disposeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IpTxt = new System.Windows.Forms.TextBox();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.logBoard = new Huike.Util.Logger.UI.LogBoard();
            this.startTxt = new System.Windows.Forms.TextBox();
            this.endTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.intvTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(250, 23);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "连接";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // disposeBtn
            // 
            this.disposeBtn.Location = new System.Drawing.Point(250, 66);
            this.disposeBtn.Name = "disposeBtn";
            this.disposeBtn.Size = new System.Drawing.Size(75, 23);
            this.disposeBtn.TabIndex = 1;
            this.disposeBtn.Text = "断开";
            this.disposeBtn.UseVisualStyleBackColor = true;
            this.disposeBtn.Click += new System.EventHandler(this.disposeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port：";
            // 
            // IpTxt
            // 
            this.IpTxt.Location = new System.Drawing.Point(117, 25);
            this.IpTxt.Name = "IpTxt";
            this.IpTxt.Size = new System.Drawing.Size(100, 21);
            this.IpTxt.TabIndex = 4;
            this.IpTxt.Text = "127.0.0.1";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(117, 66);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(100, 21);
            this.PortTxt.TabIndex = 5;
            this.PortTxt.Text = "3360";
            // 
            // logBoard
            // 
            this.logBoard.DoubleBufferingEnabled = true;
            this.logBoard.HighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(249)))));
            this.logBoard.IconImageList = null;
            this.logBoard.Location = new System.Drawing.Point(12, 108);
            this.logBoard.Name = "logBoard";
            this.logBoard.SelectedIndex = -1;
            this.logBoard.Size = new System.Drawing.Size(361, 273);
            this.logBoard.TabIndex = 6;
            // 
            // startTxt
            // 
            this.startTxt.Location = new System.Drawing.Point(457, 19);
            this.startTxt.Name = "startTxt";
            this.startTxt.Size = new System.Drawing.Size(37, 21);
            this.startTxt.TabIndex = 7;
            this.startTxt.Text = "1";
            // 
            // endTxt
            // 
            this.endTxt.Location = new System.Drawing.Point(526, 19);
            this.endTxt.Name = "endTxt";
            this.endTxt.Size = new System.Drawing.Size(37, 21);
            this.endTxt.TabIndex = 8;
            this.endTxt.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "值范围";
            // 
            // intvTxt
            // 
            this.intvTxt.Location = new System.Drawing.Point(457, 62);
            this.intvTxt.Name = "intvTxt";
            this.intvTxt.Size = new System.Drawing.Size(106, 21);
            this.intvTxt.TabIndex = 11;
            this.intvTxt.Text = "15";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "时间间隔";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(630, 60);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 13;
            this.sendBtn.Text = "开始发送";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 402);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.intvTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endTxt);
            this.Controls.Add(this.startTxt);
            this.Controls.Add(this.logBoard);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.IpTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disposeBtn);
            this.Controls.Add(this.connectBtn);
            this.Name = "Form1";
            this.Text = "KaoheC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button disposeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IpTxt;
        private System.Windows.Forms.TextBox PortTxt;
        private Huike.Util.Logger.UI.LogBoard logBoard;
        private System.Windows.Forms.TextBox startTxt;
        private System.Windows.Forms.TextBox endTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox intvTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Timer timer;
    }
}

