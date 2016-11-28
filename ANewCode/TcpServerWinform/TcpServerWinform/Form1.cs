using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Huike.Util.Logger;

namespace TcpServerWinform

{
    public delegate void delegateAddString(string msg);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private  Huike.Tcp.Server server =new Huike.Tcp.Server();
        private  Huike.Tcp.Server server2 = null;
        private  Huike.Tcp.Server server3 = null;
        private  Huike.Tcp.Client client = new Huike.Tcp.Client();
        private  Hashtable hatForSockeTab=new Hashtable();
        private  Huike.Log.SystemLog log;
        private  int sendCount = 0, recCount = 0;
        private void OpenBtn_Click(object sender, System.EventArgs e)
        {
            //try
            //{
                
                server.OnReceive += new Huike.Tcp.ReceiveEventHandler(server_OnReceive);
                server.OnDisconnect += new Huike.Tcp.SocketEventHandler(server_OnDisconnect);
                server.OnConnect += new Huike.Tcp.SocketEventHandler(server_OnConnect);
                server.NeedAddStartEnd = false;
                server.StartListen("127.0.0.1", 8222);
                log.WriteLog("log", "测试日志写入:开始监听22");
                //Huike.Util.Logger.LogNotifier.Log(LogType.Info,"写入测试1");

            //}
            //catch (Exception ex)
            //{
            //    throw(ex);
            //    //Console.WriteLine(ex);
            //}
        }
        public  void server_OnConnect(object sender, Huike.Tcp.SocketEventArgs e)
        {
            if (hatForSockeTab.Contains(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5)))
            {
                hatForSockeTab.Remove(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5));
            }
            hatForSockeTab.Add(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5), e.RemoteAddress);
        }
        public  void server_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            try
            {
                string msg = e.Read().ToString();//接受数据
                //MessageBox.Show(msg);
                this.AddList(msg+"121");
                this.log.AddLogQueue("", "IP:" + e.RemoteAddress + "    数据:" + msg);
                this.recCount += 1;

                string orderID = msg.Split(',')[0];
                orderID = orderID.Remove(0, 7);
                string retMsg = "12写入植入";
                
                System.Threading.Thread.Sleep(Convert.ToInt32("122"));
                e.Write(retMsg);//发送给client信息
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message + "" + System.DateTime.Now.ToShortDateString() + "");
            }
        }
        public static void server_OnDisconnect(object sender, Huike.Tcp.SocketEventArgs e)
        {
        }
        private void AddList(string msg)
        {
            if (this.listBox1.InvokeRequired)
            {
                delegateAddString addstr = new delegateAddString(this.AddList);
                object[] ob = new object[1];
                ob[0] = msg;
               
                this.Invoke(addstr, ob);
                IAsyncResult result = this.BeginInvoke(addstr, ob);
                //this.BeginInvoke(result);
                this.EndInvoke(result); ;
            }
            else
            {
                this.listBox1.Items.Add(msg);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //server = new Huike.Tcp.Server();
            this.log = new Huike.Log.SystemLog();
            this.log.StartThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                long tt = System.DateTime.Now.Ticks;
                if (server.OnlineCount > 0)
                {
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    for (int j = 0; j < 2; j++)
                    //    {
                            ((Huike.Tcp.ClientThread)server.Clients[0]).SendMsg(this.textBox1.Text + "");
                    //    }
                    //}
                }
                tt = System.DateTime.Now.Ticks - tt;
                tt = tt / 10000;
                //MessageBox.Show("aa" + tt.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("发送错误",ex.Message);
            }
        }
    }
}
