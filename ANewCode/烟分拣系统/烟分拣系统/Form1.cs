using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huike.Util.Logger;
using System.IO;

namespace 烟分拣系统
{
    public partial class Form1 : Form
    {
        private LogBoardLogger logBoardLogger = null;
        private FileLogger fileLogger = null;
        private CompositeLogger compositeLogger = null;
        private Huike.Tag.Controler controler;
        private Huike.Tag.MessageReceiver messageReceiver;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int tagID = int.Parse(this.comboBox1.Text);
                int showInfo = int.Parse(this.textBox1.Text);
                DataTable dt = new DataTable();
                dt.Columns.Add("tagIP", typeof(string));
                dt.Columns.Add("Qty", typeof(string));

                DataRow r = dt.NewRow();
                if (tagID == 0)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        r["tagIP"] = i;
                        r["Qty"] = showInfo;
                        dt.Rows.Add(r.ItemArray);
                    }
                }
                else
                {
                    r["tagIP"] = tagID;
                    r["Qty"] = showInfo;
                    dt.Rows.Add(r.ItemArray);
                }
                this.controler.tagsInfo.Clear();
                this.controler.InitTagChannelsStock(dt);
                this.controler.LightTagsPickInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void SetLogParam()
        {
            try
            {
                if (logBoardLogger == null) logBoardLogger = new LogBoardLogger(this.logBoard1);
                logBoardLogger.MaxCount = 100;
                logBoardLogger.LogLevel = 1;
                string strPath = Application.StartupPath + "\\log\\";
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                if (fileLogger == null) fileLogger = new FileLogger(strPath, "flog", ".log");
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

        private void InitTag()
        {
            try
            {
                this.controler = new Huike.Tag.Controler(1);
                this.controler.LightedTagInfo += new Huike.Tag.Controler.ControlerEventHandler(controler_LightedTagInfo);
                this.controler.LightedStockInfo += new Huike.Tag.Controler.ControlerEventHandler(controler_LightedStockInfo);
                this.controler.ClearTagInfoEvent += new Huike.Tag.Controler.ControlerEventHandler(controler_ClearTagInfoEvent);

                this.messageReceiver = new Huike.Tag.MessageReceiver(1);
                this.messageReceiver.OnCompleteTagConfirmKeyEvent += new Huike.Tag.TagClickEventHandler(messageReceiver_OnCompleteTagConfirmKeyEvent);
                this.messageReceiver.OnConfirmKeyPickInfoConfirmEvent += new Huike.Tag.TagClickEventHandler(messageReceiver_OnConfirmKeyPickInfoConfirmEvent);
                this.messageReceiver.OnConfirmKeyPickInfoRequestEvent += new Huike.Tag.TagClickEventHandler(messageReceiver_OnConfirmKeyPickInfoRequestEvent);
                this.messageReceiver.OnDownKeyStockInfoRequestEvent += new Huike.Tag.TagClickEventHandler(messageReceiver_OnDownKeyStockInfoRequestEvent);
                this.messageReceiver.OtherMessageReturnEvent += new Huike.Tag.TagClickEventHandler(messageReceiver_OtherMessageReturnEvent);
            }
            catch (System.Exception ex)
            {
                LogNotifier.Log(LogType.Error, string.Format("实例化电子标签出错！错误如下:{0}", ex.Message));

            }
        }
        private void InitConnection()
        {
            try
            {
                this.controler.OpenAPIFile();
                this.controler.Connect(1);
                LogNotifier.Log(LogType.Info, "连接标签控制器  成");

            }
            catch (System.Exception ex)
            {
                LogNotifier.Log(LogType.Error, string.Format("标签控制器连接出错！{0}",ex.Message));
            }
        }
        private void InitTagReceiver()
        {
            try
            {
                this.messageReceiver.Start(this.controler);
                LogNotifier.Log(LogType.Info, "启动标签消息接收器...成功");
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, string.Format("标签接收器启动出错！错误如下：{0}", ex.Message));
            }
        }
        private void controler_LightedTagInfo(Huike.Tag.TagPicker tagPicker)
        {
            LogNotifier.Log(LogType.Alert, string.Format("正常点亮标签号:{0}", tagPicker.TagIP));
        }
        private void controler_LightedStockInfo(Huike.Tag.TagPicker tagPicker)
        {
            LogNotifier.Log(LogType.Alert, string.Format("正在盘点的标签号!{0}", tagPicker.TagIP));
        }
        private void controler_ClearTagInfoEvent(Huike.Tag.TagPicker tagPicker)
        {
            LogNotifier.Log(LogType.Alert, string.Format("清除标签号:{0}", tagPicker.TagIP));
        }
        private void messageReceiver_OnCompleteTagConfirmKeyEvent(Huike.Tag.TagClickEventArgs tagClickEventArgs)
        {
            //是否有完成器根据情况处理
        }
        private void messageReceiver_OnConfirmKeyPickInfoConfirmEvent(Huike.Tag.TagClickEventArgs tagClickEventArgs)
        {
            LogNotifier.Log(LogType.Alert, string.Format("标签号：{0} 完成", tagClickEventArgs.TagIP));   
        }
        private void messageReceiver_OnConfirmKeyPickInfoRequestEvent(Huike.Tag.TagClickEventArgs tagClickEventArgs)
        { }
        /// <summary>
        /// 按下下键盘点信息请求事件
        /// </summary>
        /// <param name="tagClickEventArgs"></param>
        private void messageReceiver_OnDownKeyStockInfoRequestEvent(Huike.Tag.TagClickEventArgs tagClickEventArgs)
        {
        }

        /// <summary>
        /// 其他消息返回事件
        /// </summary>
        /// <param name="tagClickEventArgs"></param>
        private void messageReceiver_OtherMessageReturnEvent(Huike.Tag.TagClickEventArgs tagClickEventArgs)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.SetLogParam();
                string logMsg = string.Format("系统启动");
                LogNotifier.Log(LogType.Alert, "系统信息", logMsg, "");
                LogNotifier.Log(LogType.Alert, "开始初始化电子标签", logMsg, "");

                this.InitTag();
                this.InitConnection();
                this.InitTagReceiver();

            }
            catch (Exception ex)
            {
                MessageBox.Show("启动系统时发生错误：" + ex.Message, "系统提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int tagID = int.Parse(this.comboBox1.Text);
                int showInfo = int.Parse(this.textBox1.Text);
                DataTable dt = new DataTable();
                dt.Columns.Add("tagIP", typeof(string));
                dt.Columns.Add("Qty", typeof(string));

                DataRow r = dt.NewRow();

                if (tagID == 0)//如果是选中了0,表示发送所有标签
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        r["tagIP"] = i;
                        r["Qty"] = showInfo;
                        dt.Rows.Add(r.ItemArray);
                    }
                }
                else
                {
                    r["tagIP"] = tagID;
                    r["Qty"] = showInfo;
                    dt.Rows.Add(r.ItemArray);
                }

                this.controler.tagsInfo.Clear();
                this.controler.InitTagChannelsStock(dt);
                this.controler.ClearTags();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
