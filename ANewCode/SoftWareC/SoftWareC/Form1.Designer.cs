namespace SoftWareC
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPORT = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.DisposeBtn = new System.Windows.Forms.Button();
            this.listBoxGet = new System.Windows.Forms.ListBox();
            this.queryBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.txtSendCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxGetTest = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(82, 21);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(87, 21);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "127.0.0.1";
            // 
            // txtPORT
            // 
            this.txtPORT.Location = new System.Drawing.Point(82, 59);
            this.txtPORT.Name = "txtPORT";
            this.txtPORT.Size = new System.Drawing.Size(87, 21);
            this.txtPORT.TabIndex = 3;
            this.txtPORT.Text = "8806";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(197, 19);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "连接";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // DisposeBtn
            // 
            this.DisposeBtn.Location = new System.Drawing.Point(197, 57);
            this.DisposeBtn.Name = "DisposeBtn";
            this.DisposeBtn.Size = new System.Drawing.Size(75, 23);
            this.DisposeBtn.TabIndex = 5;
            this.DisposeBtn.Text = "断开";
            this.DisposeBtn.UseVisualStyleBackColor = true;
            // 
            // listBoxGet
            // 
            this.listBoxGet.FormattingEnabled = true;
            this.listBoxGet.ItemHeight = 12;
            this.listBoxGet.Location = new System.Drawing.Point(38, 110);
            this.listBoxGet.Name = "listBoxGet";
            this.listBoxGet.Size = new System.Drawing.Size(242, 76);
            this.listBoxGet.TabIndex = 6;
            // 
            // queryBtn
            // 
            this.queryBtn.Location = new System.Drawing.Point(389, 18);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(75, 23);
            this.queryBtn.TabIndex = 7;
            this.queryBtn.Text = "查询";
            this.queryBtn.UseVisualStyleBackColor = true;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(389, 57);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 8;
            this.updateBtn.Text = "更新";
            this.updateBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(508, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "增加";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(508, 57);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "删除";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(338, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(273, 217);
            this.dataGridView1.TabIndex = 11;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(38, 207);
            this.txtSendMsg.Multiline = true;
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(161, 60);
            this.txtSendMsg.TabIndex = 12;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(205, 207);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 13;
            this.sendBtn.Text = "发送";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // txtSendCount
            // 
            this.txtSendCount.Location = new System.Drawing.Point(246, 246);
            this.txtSendCount.Name = "txtSendCount";
            this.txtSendCount.Size = new System.Drawing.Size(34, 21);
            this.txtSendCount.TabIndex = 14;
            this.txtSendCount.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "次数";
            // 
            // listBoxGetTest
            // 
            this.listBoxGetTest.FormattingEnabled = true;
            this.listBoxGetTest.ItemHeight = 12;
            this.listBoxGetTest.Location = new System.Drawing.Point(38, 279);
            this.listBoxGetTest.Name = "listBoxGetTest";
            this.listBoxGetTest.Size = new System.Drawing.Size(242, 88);
            this.listBoxGetTest.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 379);
            this.Controls.Add(this.listBoxGetTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSendCount);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.queryBtn);
            this.Controls.Add(this.listBoxGet);
            this.Controls.Add(this.DisposeBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.txtPORT);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SoftWareC";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPORT;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button DisposeBtn;
        private System.Windows.Forms.ListBox listBoxGet;
        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox txtSendCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxGetTest;
    }
}

