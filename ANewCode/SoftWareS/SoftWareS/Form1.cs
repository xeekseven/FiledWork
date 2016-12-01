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
using System.IO;

namespace SoftWareS
{
    public partial class Form1 : Form
    {
        public delegate void delegateAddString(string msg);
        public Form1()
        {
            InitializeComponent();
        }
        #region//变量
        private LogBoardLogger logBoardLogger = null;
        private FileLogger fileLogger = null;
        private CompositeLogger compositeLogger = null;

        private Huike.Tcp.Server server = new Huike.Tcp.Server();
        private Huike.Tcp.Server server2 = null;
        private Huike.Tcp.Server server3 = null;
        private Huike.Tcp.Client client = new Huike.Tcp.Client();
        private Hashtable hatForSockeTab = new Hashtable();
        //private Huike.Log.SystemLog log;
        private int sendCount = 0, recCount = 0;
        private CheckBox chkReturnOK;
        
        #endregion
        /// <summary>
        /// 日志的初始化
        /// </summary>
        /// <param name="logBoard"></param>
        public void SetLogParam()
        {
            try
            {
                if (logBoardLogger == null) logBoardLogger = new LogBoardLogger(this.logBoard);
                logBoardLogger.MaxCount = 100;
                logBoardLogger.LogLevel = 1;
                string strPath = Application.StartupPath + "\\log\\";
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                if (fileLogger == null) fileLogger = new FileLogger(strPath, "ServerLog", ".log");
                fileLogger.IntervalMode = true;
                fileLogger.LogDay = 7;
                fileLogger.LogLevel = 1;
                fileLogger.ClearLogFile();

                if (compositeLogger == null)
                {
                    compositeLogger = new CompositeLogger(logBoardLogger, fileLogger);
                    compositeLogger.Initialize();
                    LogNotifier.OnLog += new LogEventHandler(LogNotifier_OnLog);
                }
                Application.DoEvents();
                Huike.Util.Logger.LogNotifier.Log(LogType.Info, "初始化", "初始化日志组件完成", "");


            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, "配置信息", "设置[日志参数]错误 [" + ex.Message + "]", "");

            }
        }
        private void LogNotifier_OnLog(object sender, LogEventArgs e)
        {
            if (compositeLogger != null)
            {
                compositeLogger.LogMessage(e);
            }
        }
        private void StartListenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Net.IPHostEntry hostInfo = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName());
                //System.Net.IPAddress[] address = hostInfo.AddressList;
                //string m_IP= address[0].ToString();


                server.OnReceive += new Huike.Tcp.ReceiveEventHandler(server_OnReceive);
                server.OnDisconnect += new Huike.Tcp.SocketEventHandler(server_OnDisconnect);
                server.OnConnect += new Huike.Tcp.SocketEventHandler(server_OnConnect);

                server.NeedAddStartEnd = true;
                server.StartListen(this.IpTxt.Text, Convert.ToInt32(this.PortTxt.Text));
                LogNotifier.Log(LogType.Alert,string.Format("监听成功：{0}:{1}",this.IpTxt.Text,this.PortTxt.Text));
         

            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, string.Format("监听失败：{0}:{1},{2}", this.IpTxt.Text, this.PortTxt.Text,ex.Message));
                
                MessageBox.Show(ex.Message, "错误提示");
            }
        }
        private void server_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            //chkReturnOK.Checked = true;
            try
            {

                string msg = e.Read().ToString();

                this.AddList(msg);
                //this.log.AddLogQueue("", "IP:" + e.RemoteAddress + "   数据:" + msg);
                LogNotifier.Log(LogType.Alert,"IP:" + e.RemoteAddress + "   数据:" + msg);
                this.recCount += 1;
                //this.lblRecCount.Text=this.recCount.ToString();

                string orderID = msg.Split(',')[0];
                orderID = orderID.Remove(0, 7);
                string retMsg = "";
                //if (chkReturnOK.Checked)
                //{
                    retMsg = string.Format("[ORDER];{0},OK;[END]", orderID);
                //}
                //else
                //{
                //    retMsg = string.Format("[ORDER];{0},错误描述[测试错误];[END]", orderID);
                //}
                System.Threading.Thread.Sleep(150);
                e.Write(retMsg);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message + "  " + System.DateTime.Now.ToString());
            }

        }
        private void AddList(string msg)
        {
            if (listBoxGet.InvokeRequired)
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
        private void server_OnDisconnect(object sender, Huike.Tcp.SocketEventArgs e)
		{
           
		}
        private void server_OnConnect(object sender, Huike.Tcp.SocketEventArgs e)
		{
            
			if(hatForSockeTab.Contains(e.RemoteAddress.Substring(0,e.RemoteAddress.Length-5)))
			{
				hatForSockeTab.Remove(e.RemoteAddress.Substring(0,e.RemoteAddress.Length-5));
			}	
			hatForSockeTab.Add(e.RemoteAddress.Substring(0,e.RemoteAddress.Length-5),e.RemoteAddress);
				
					 
		}
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.SetLogParam();
                string logMsg = string.Format("系统启动");
                LogNotifier.Log(LogType.Alert, "系统信息", logMsg, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动系统时发生错误：" + ex.Message, "系统提示");
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                long tt = System.DateTime.Now.Ticks;
                if (server.OnlineCount > 0)
                {
                    for (int i = 0; i < server.OnlineCount; i++)
                    {
                        for (int j = 0; j < Convert.ToInt16(this.sendCountTxt.Text); j++)
                        {
                            ((Huike.Tcp.ClientThread)server.Clients[0]).SendMsg(this.txtSend.Text + "   " + j.ToString());
                        }
                    }
                }
                tt = System.DateTime.Now.Ticks - tt;
                tt = tt / 10000;
                LogNotifier.Log(LogType.Info,"耗时(毫秒)：" + tt.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送错误", ex.Message);
            }
        }
    }
}
