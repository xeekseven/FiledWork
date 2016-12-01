using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftWareC
{
    public partial class Form1 : Form
    {
        public delegate void delegateAddString(string msg);
        private Huike.Tcp.Client client = null;
        private Huike.Log.SystemLog log;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            long tt = System.DateTime.Now.Ticks;
            try
            {
                client = new Huike.Tcp.Client(txtIP.Text, Convert.ToInt32(this.txtPORT.Text));
                //client.NeedAddStartEnd = false;
                client.OnReceive += new Huike.Tcp.ReceiveEventHandler(client_OnReceive);
                client.OnServerClosed += new Huike.Tcp.SocketEventHandler(client_OnServerClosed);
                //client.OnServerClosed += new Huike.Tcp.SocketEventHandler(client_OnServerClosed);
                client.Connect();
                ConnectBtn.Enabled = false;
                this.DisposeBtn.Enabled = true;
                //btnSend.Enabled = true;
            }
            catch (Exception err)
            {
                //MessageBox.Show("连接错误",err.Message);
                this.listBoxGet.Items.Add(err.Message);
            }
            tt = System.DateTime.Now.Ticks - tt;
            this.listBoxGet.Items.Add(tt.ToString());
        }
        private void client_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            string msg = e.Read();
            this.AddList(msg);
            MessageBox.Show("OnReceive" + msg);
            this.log.AddLogQueue("消息", "IP:" + msg + "   消息：" + msg);
            

        }
        private void AddList(string msg)
        {
            if (this.listBoxGet.InvokeRequired)
            {
                delegateAddString addstr = new delegateAddString(this.AddList);
                object[] ob = new object[1];
                ob[0] = msg;
                this.Invoke(addstr, ob);
            }
            else
            {
                this.listBoxGet.Items.Add(msg);
            }

        }
        private void client_OnServerClosed(object sender, Huike.Tcp.SocketEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.SetClosedProcess));
            }
            else
            {
                this.SetClosedProcess();
            }
        }
        private void SetClosedProcess()
        {
            try
            {
               ConnectBtn.Enabled = true;
               DisposeBtn.Enabled = false;
                //btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("server断开，处理错误：" + ex.ToString(), "系统提示");
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                long tt = System.DateTime.Now.Ticks;
                client.Connect();
                int sendCount = 0;
                for (int i = 0; i < Convert.ToInt16(this.txtSendCount.Text); i++)
                {

                    client.Write(this.txtSendMsg.Text);
                    this.listBoxGet.Items.Add("发送字节数:" + sendCount.ToString());
                }
                this.listBoxGet.Items.Add(client.Read());
                //client.Close();
                tt = System.DateTime.Now.Ticks - tt;
                tt = tt / 10000;
                this.listBoxGet.Items.Add("耗时(毫秒)：" + tt.ToString());
                this.listBoxGet.Items.Add(listBoxGet.Text);

            }
            catch (Exception err)
            {
                MessageBox.Show("指令发送错误", err.Message);
            } 
        }
    }
}
