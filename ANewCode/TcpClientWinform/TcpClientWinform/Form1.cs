using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace TcpClientWinform
{
    public partial class Form1 : Form
    {
        private Huike.Tcp.Client client=new Huike.Tcp.Client();
        private int counter = 0;
        private Huike.Log.SystemLog log;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // this.GetTxtInput();
            this.log = new Huike.Log.SystemLog();
            this.log.StartThead();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            long tt = System.DateTime.Now.Ticks;
            try
            {
                client = new Huike.Tcp.Client(textBox1.Text, Convert.ToInt32(textBox2.Text));

                client.OnReceive += new Huike.Tcp.ReceiveEventHandler(client_OnReceive);
                //client.OnServerClosed += new Huike.Tcp.SocketEventHandler();
                client.Connect();
               
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            tt = System.DateTime.Now.Ticks - tt;
            
        }
        private void client_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            string msg = e.Read();//接受消息
            MessageBox.Show("OnReceive"+msg);
            this.log.AddLogQueue("消息","IP:"+msg+"  消息："+msg);//为出错做写入日志的准备
        }
        private void client_OnServerClosed(object sender, Huike.Tcp.SocketEventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(this.set))
            //}
        }
        public delegate string cReadHandler();
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                long tt = System.DateTime.Now.Ticks;
                client.Connect();
                for (int i = 0; i < 2; i++)
                {

                    client.Write(textBox3.Text);
                    //this.lstMsg.Items.Add("发送字节数:" + sendCount.ToString());
                }
                
                cReadHandler cRead = new cReadHandler(client.Read);
                
                cRead.BeginInvoke(new AsyncCallback(CallBackRead), "AsycState:OK");
               
                //MessageBox.Show(client.Read());//接受的消息（——）
                //client.Close();//异步未完成前不可关闭
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void CallBackRead(IAsyncResult e)
        {
            cReadHandler handler = (cReadHandler)((AsyncResult)e).AsyncDelegate;
            string msg = string.Empty;
            if (e != null)
            {
                msg = handler.EndInvoke(e);
            }


            //client.Close();
            MessageBox.Show(msg);
        }
        
    }
}
