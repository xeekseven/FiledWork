using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huike.Util.Scan;

namespace 扫描器组件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ScanSerialPort scanSeriaPort = null;
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.scanSeriaPort = new ScanSerialPort();
                this.scanSeriaPort.CommPort = Convert.ToInt32(this.textBox1.Text);
                this.scanSeriaPort.CommSettings = this.textBox2.Text;
                this.scanSeriaPort.HeadString = (char)Convert.ToInt32(this.textBox3.Text);
                this.scanSeriaPort.TailString = (char)Convert.ToInt32(this.textBox3.Text);
                this.scanSeriaPort.SplitChar = (char)Convert.ToInt32(this.textBox5.Text);
                this.scanSeriaPort.getReceivedData += new ScanSerialPort.GetReceivedData(scanSerialPort_getReceiveData);
                this.scanSeriaPort.OpenCommPort();
                this.textBox6.Text="扫描串口打开成功";
            }
            catch(Exception ex)
            {
                string msg=string.Format("打开串口错误，检查设置重新启动！\r\n");
                MessageBox.Show(msg+ex.Message);
            }
        }
        void scanSerialPort_getReceiveData(object sender, ReceiveDataEventArgs e)
        {
            try
            {
                string msg = string.Format("收到条码,站号:{0} 条码：{1}、\r\n", e.ScannerNum, e.ProductCode);
                this.textBox6.Text = this.textBox6.Text + msg;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
