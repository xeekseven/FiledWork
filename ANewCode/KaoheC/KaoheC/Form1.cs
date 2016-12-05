using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huike.Util.Logger;
using System.IO;

namespace KaoheC
{
    public partial class Form1 : Form
    {
        private static object locko = new object();
        private static int inTimer = 0;
        public delegate void delegateAddString(string msg);
        private Huike.Tcp.Client client = null;

        private LogBoardLogger logBoardLogger = null;
        private FileLogger fileLogger = null;
        private CompositeLogger compositeLogger = null;
        private static int startNum = 0, endNum = 0;
        public Form1()
        {
            InitializeComponent();
        }


        #region 函数
        private void client_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            string msg = e.Read();
            // this.AddList(msg);
            MessageBox.Show("OnReceive" + msg);
            //this.log.AddLogQueue("消息", "IP:" + msg + "   消息：" + msg);


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
                connectBtn.Enabled = true;
                disposeBtn.Enabled = false;
                //btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("server断开，处理错误：" + ex.ToString(), "系统提示");
            }
        }
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
        #endregion
        private void connectBtn_Click(object sender, EventArgs e)
        {
            long tt = System.DateTime.Now.Ticks;
            try
            {
                client = new Huike.Tcp.Client(this.IpTxt.Text, Convert.ToInt32(this.PortTxt.Text));
                //client.NeedAddStartEnd = false;
                client.OnReceive += new Huike.Tcp.ReceiveEventHandler(client_OnReceive);
                client.OnServerClosed += new Huike.Tcp.SocketEventHandler(client_OnServerClosed);
                //client.OnServerClosed += new Huike.Tcp.SocketEventHandler(client_OnServerClosed);
                client.Connect();
                connectBtn.Enabled = false;
                this.disposeBtn.Enabled = true;
                LogNotifier.Log(LogType.Info, "连接成功");
                //btnSend.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("连接错误", err.Message);
                //this.listBoxGet.Items.Add(err.Message);
            }
            tt = System.DateTime.Now.Ticks - tt;
            // this.listBoxGet.Items.Add(tt.ToString());
        }

        private void disposeBtn_Click(object sender, EventArgs e)
        {
             client.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = (int.Parse(this.intvTxt.Text)*1000);
            try
            {
                this.SetLogParam();
                string logMsg = string.Format("系统启动");
                LogNotifier.Log(LogType.Alert, "系统信息", logMsg, "");
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, "启动系统时发生错误：" + ex.Message+ "系统提示");
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            timer.Interval = (int.Parse(this.intvTxt.Text) * 1000);
            startNum = int.Parse(this.startTxt.Text);
            endNum = int.Parse(this.endTxt.Text);
            try
            {

                client.Connect();

                //while (startNum <= endNum)
                //{

                timer.Start();

                //}
                LogNotifier.Log(LogType.Info, "开始发送");


            }
            catch (Exception err)
            {
                LogNotifier.Log(LogType.Error,"指令发送错误"+ err.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (inTimer == 0)
            {
                inTimer = 1;
                //    while (startNum <= endNum)
                //    {
                client.Write(startNum.ToString());
                LogNotifier.Log(LogType.Info, "发送数值" + startNum.ToString());

                startNum += 1;
                inTimer = 0;
                //  }
                if (startNum >= endNum)
                {
                    timer.Stop();
                }
                //client.Connect();

            }
        }
    }
}
