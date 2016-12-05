namespace KaoheS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IpTxt = new System.Windows.Forms.TextBox();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.logBoard = new Huike.Util.Logger.UI.LogBoard();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.queryIdTxt = new System.Windows.Forms.TextBox();
            this.queryBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteIdTxt = new System.Windows.Forms.TextBox();
            this.changeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.changeIdTxt = new System.Windows.Forms.TextBox();
            this.changeNameTxt = new System.Windows.Forms.TextBox();
            this.changeValueTxt = new System.Windows.Forms.TextBox();
            this.changeFlogTxt = new System.Windows.Forms.TextBox();
            this.OpcStart = new System.Windows.Forms.Button();
            this.OpcValueTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORT:\r\n";
            // 
            // IpTxt
            // 
            this.IpTxt.Location = new System.Drawing.Point(64, 10);
            this.IpTxt.Name = "IpTxt";
            this.IpTxt.Size = new System.Drawing.Size(100, 21);
            this.IpTxt.TabIndex = 2;
            this.IpTxt.Text = "127.0.0.1";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(64, 42);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(100, 21);
            this.PortTxt.TabIndex = 3;
            this.PortTxt.Text = "3360\r\n";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(211, 8);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "开始监听\r\n";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(211, 42);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 5;
            this.StopBtn.Text = "停止监听";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // logBoard
            // 
            this.logBoard.DoubleBufferingEnabled = true;
            this.logBoard.HighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(249)))));
            this.logBoard.IconImageList = null;
            this.logBoard.Location = new System.Drawing.Point(24, 136);
            this.logBoard.Name = "logBoard";
            this.logBoard.SelectedIndex = -1;
            this.logBoard.Size = new System.Drawing.Size(449, 283);
            this.logBoard.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(491, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(456, 283);
            this.dataGridView1.TabIndex = 7;
            // 
            // queryIdTxt
            // 
            this.queryIdTxt.Location = new System.Drawing.Point(682, 4);
            this.queryIdTxt.Name = "queryIdTxt";
            this.queryIdTxt.Size = new System.Drawing.Size(100, 21);
            this.queryIdTxt.TabIndex = 8;
            // 
            // queryBtn
            // 
            this.queryBtn.Location = new System.Drawing.Point(491, 8);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(75, 23);
            this.queryBtn.TabIndex = 9;
            this.queryBtn.Text = "查询";
            this.queryBtn.UseVisualStyleBackColor = true;
            this.queryBtn.Click += new System.EventHandler(this.queryBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "ID：\r\n";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(491, 37);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 11;
            this.deleteBtn.Text = "删除\r\n";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(587, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "删除的项的ID：\r\n";
            // 
            // deleteIdTxt
            // 
            this.deleteIdTxt.Location = new System.Drawing.Point(682, 37);
            this.deleteIdTxt.Name = "deleteIdTxt";
            this.deleteIdTxt.Size = new System.Drawing.Size(100, 21);
            this.deleteIdTxt.TabIndex = 13;
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(491, 66);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 14;
            this.changeBtn.Text = "修改\r\n";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(589, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "修改的ID：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(741, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "项名称\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(589, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "PLC单元值";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(741, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "更新标志\r\n";
            // 
            // changeIdTxt
            // 
            this.changeIdTxt.Location = new System.Drawing.Point(660, 68);
            this.changeIdTxt.Name = "changeIdTxt";
            this.changeIdTxt.Size = new System.Drawing.Size(62, 21);
            this.changeIdTxt.TabIndex = 19;
            // 
            // changeNameTxt
            // 
            this.changeNameTxt.Location = new System.Drawing.Point(797, 68);
            this.changeNameTxt.Name = "changeNameTxt";
            this.changeNameTxt.Size = new System.Drawing.Size(63, 21);
            this.changeNameTxt.TabIndex = 20;
            // 
            // changeValueTxt
            // 
            this.changeValueTxt.Location = new System.Drawing.Point(660, 102);
            this.changeValueTxt.Name = "changeValueTxt";
            this.changeValueTxt.Size = new System.Drawing.Size(62, 21);
            this.changeValueTxt.TabIndex = 21;
            // 
            // changeFlogTxt
            // 
            this.changeFlogTxt.Location = new System.Drawing.Point(797, 102);
            this.changeFlogTxt.Name = "changeFlogTxt";
            this.changeFlogTxt.Size = new System.Drawing.Size(63, 21);
            this.changeFlogTxt.TabIndex = 22;
            // 
            // OpcStart
            // 
            this.OpcStart.Location = new System.Drawing.Point(24, 77);
            this.OpcStart.Name = "OpcStart";
            this.OpcStart.Size = new System.Drawing.Size(113, 40);
            this.OpcStart.TabIndex = 23;
            this.OpcStart.Text = "启动OPC";
            this.OpcStart.UseVisualStyleBackColor = true;
            this.OpcStart.Click += new System.EventHandler(this.OpcStart_Click);
            // 
            // OpcValueTxt
            // 
            this.OpcValueTxt.Location = new System.Drawing.Point(211, 88);
            this.OpcValueTxt.Name = "OpcValueTxt";
            this.OpcValueTxt.Size = new System.Drawing.Size(87, 21);
            this.OpcValueTxt.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(795, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "也可先选中行，鼠标右键删除";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(795, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "为空的时候查询为全部";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "实时的值：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 421);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.OpcValueTxt);
            this.Controls.Add(this.OpcStart);
            this.Controls.Add(this.changeFlogTxt);
            this.Controls.Add(this.changeValueTxt);
            this.Controls.Add(this.changeNameTxt);
            this.Controls.Add(this.changeIdTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.changeBtn);
            this.Controls.Add(this.deleteIdTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.queryBtn);
            this.Controls.Add(this.queryIdTxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.logBoard);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.IpTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "KaoheS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IpTxt;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private Huike.Util.Logger.UI.LogBoard logBoard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox queryIdTxt;
        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox deleteIdTxt;
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox changeIdTxt;
        private System.Windows.Forms.TextBox changeNameTxt;
        private System.Windows.Forms.TextBox changeValueTxt;
        private System.Windows.Forms.TextBox changeFlogTxt;
        private System.Windows.Forms.Button OpcStart;
        private System.Windows.Forms.TextBox OpcValueTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

