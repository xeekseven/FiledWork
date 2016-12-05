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
using System.Collections;
using KaoheS;

namespace KaoheS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 变量
        //日志的
        private LogBoardLogger logBoardLogger = null;
        private FileLogger fileLogger = null;
        private CompositeLogger compositeLogger = null;
        private int recCount = 0;

        //数据库
        DbOprClass db = new DbOprClass();

        //OPC
        private PLCCommunicate.PLCCommunicate plcCommunicate;


        private Huike.Tcp.Server server = new Huike.Tcp.Server();
        private Hashtable hatForSockeTab = new Hashtable();
        #endregion

        #region  日志设置函数

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
        //日志设置函数结束
        #endregion

        #region 数据库操作
        private void getData(string Id)
        {
            try
            {
                DataSet ds = db.GetData(Id);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error,ex.Message);
            }
        }
        private void deleteData(string Id)
        {
            try
            {
                bool isDelete = db.DeleteData(int.Parse(Id));
                DataSet ds = db.GetData(null);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error,ex.Message);
            }
        }
        private void updateData(string Id, string nameOpcItemName, string ItemValue, string State)
        {

            try
            {
                bool isUpdate = db.UpDateData(Id, nameOpcItemName, ItemValue, State);
                DataSet ds = db.GetData(null);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, ex.Message);
            }

        }
        private void insertData(string Id, string nameOpcItemName, string ItemValue, string State)
        {
            try
            {

                db.InsertData(Id, nameOpcItemName, ItemValue, State);
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }
        //private void InsertOrUpdate(string Id, string nameOpcItemName, string ItemValue, string State)
        //{
        //    try
        //    {

        //        bool f = db.InsertOrUpdateData(Id, nameOpcItemName, ItemValue, State);

        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}
        #endregion

        #region OPC连接及系列操作
        private bool Init(string fileName)
        {
            try
            {
                this.plcCommunicate = new PLCCommunicate.PLCCommunicate();
                this.plcCommunicate.EvntItemChange += new PLCCommunicate.ItemChange(plcCommunicate_EventItemChange);
                this.plcCommunicate.OnConnectStateChange += new PLCCommunicate.PLCConnectState(plcCommunicate_OnConnectStateChange);
                bool retPlcInit = false;
                retPlcInit = this.plcCommunicate.Init(fileName);

                if (retPlcInit)
                {
                    if (this.plcCommunicate.Start())
                    {
                        return true;
                    }
                    else
                    {
                        LogNotifier.Log(LogType.Info, "与PLC的连接不成功！原因：" + this.plcCommunicate.LastErrInfo);

                    }
                }
                else
                {
                    LogNotifier.Log(LogType.Info, "PLC连接配置文件有误：" + this.plcCommunicate.LastErrInfo);
                }
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Info, "Plc配置错误," + ex.Message);
                return false;
            }
            return true;
        }
        public void plcCommunicate_EventItemChange(int[] ItemIndex, int[][] ItemData)
        {
            try
            {
                string[] itemNames = new string[ItemIndex.Length];
                for (int j = 0; j < ItemIndex.Length; j++)
                {
                    itemNames[j] = this.plcCommunicate.ItemNames[ItemIndex[j]];
                }
                for (int i = 0; i < itemNames.Length; i++)
                {
                    switch (itemNames[i])
                    {

                        case "Kaohe1":
                            //配置文件里面配置了1个单元，返回的数组长度为1，所以下标只有0.
                            //this.InsertOrUpdate(null, "u", ItemData[i][0].ToString(),(0).ToString());
                            this.insertData(null, "Kaohe1", ItemData[i][0].ToString(), (0).ToString());
                            this.OpcValueTxt.Text = string.Format("{0}", ItemData[i][0]);
                            break;
                        //case "TestItem2":
                        //    //配置文件里面配置了2个单元，返回的数组长度为2，所以下标最大为1.
                        //    this.textBox2.Text = string.Format("{0},{1}", ItemData[i][0], ItemData[i][1]);
                        //    break;
                        //case "TestItem4":
                        //    //配置文件里面配置了4个单元，返回的数组长度为4，所以下标最大为3.
                        //    this.textBox4.Text = string.Format("{0},{1},{2},{3}", ItemData[i][0], ItemData[i][1], ItemData[i][2], ItemData[i][3]);
                        //    break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Info, string.Format("opc事件处理错误:{0}", ex.Message));
            }
        }
        void plcCommunicate_OnConnectStateChange(bool state)
        {
            LogNotifier.Log(LogType.Info, string.Format("plc连接状态变化:{0}", state));
        }
        private void OpcWrite(int value)
        {
            string itemName = "Kaohe1";
            int[] data = new int[1];
            data[0] = value;
            this.WriteItem(itemName, data);
        }
        private void WriteItem(string itemName, int[] itemData)
        {
            try
            {
                if (this.plcCommunicate.setItemDataS(itemName, itemData))
                {
                    LogNotifier.Log(LogType.Info, string.Format("写数据成功,{0}", itemName));

                }
                else
                {
                    LogNotifier.Log(LogType.Error, string.Format("写数据失败,项名{0},错误{1}", itemName, this.plcCommunicate.LastErrInfo));
                }
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, "写数据失败,项名{0} 错误{1}", itemName, ex.Message);
            }
        }
        #endregion


        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                server.OnReceive += new Huike.Tcp.ReceiveEventHandler(server_OnReceive);
                server.OnDisconnect += new Huike.Tcp.SocketEventHandler(server_OnDisconnect);
                server.OnConnect += new Huike.Tcp.SocketEventHandler(server_OnConnect);

                server.NeedAddStartEnd = true;
                server.StartListen(this.IpTxt.Text, Convert.ToInt32(this.PortTxt.Text));
                LogNotifier.Log(LogType.Alert, string.Format("监听成功：{0}:{1}", this.IpTxt.Text, this.PortTxt.Text));


            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, string.Format("监听失败：{0}:{1},{2}", this.IpTxt.Text, this.PortTxt.Text, ex.Message));

                //MessageBox.Show(ex.Message, "错误提示");
            }
        }

        private void server_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            //chkReturnOK.Checked = true;
            try
            {

                string msg = e.Read().ToString();
                this.OpcWrite(int.Parse(msg));
                LogNotifier.Log(LogType.Alert, "IP:" + e.RemoteAddress + "   数据:" + msg);
                this.recCount += 1;              
                string retMsg = "";
                
                retMsg = string.Format("[ORDER],OK;[END]");
          
                System.Threading.Thread.Sleep(150);
                e.Write(retMsg);
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, ex.Message + "  " + System.DateTime.Now.ToString());
                //System.Console.WriteLine(ex.Message + "  " + System.DateTime.Now.ToString());
            }

        }
        private void server_OnDisconnect(object sender, Huike.Tcp.SocketEventArgs e)
        {

        }
        private void server_OnConnect(object sender, Huike.Tcp.SocketEventArgs e)
        {

            if (hatForSockeTab.Contains(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5)))
            {
                hatForSockeTab.Remove(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5));
            }
            hatForSockeTab.Add(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5), e.RemoteAddress);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                this.SetLogParam();
                string logMsg = string.Format("系统启动");
                LogNotifier.Log(LogType.Alert, "系统信息", logMsg, "");
                this.getData(null);
                dataGridView1.Columns[0].HeaderCell.Value = "编号";
                dataGridView1.Columns[1].HeaderCell.Value = "配置文件项名";
                dataGridView1.Columns[2].HeaderCell.Value = "PLC单元值";
                dataGridView1.Columns[3].HeaderCell.Value = "更新标志"; 
                dataGridView1.MouseClick += (s, ex) => 
                {
                    if (ex.Button == MouseButtons.Right)
                    {
                        if (MessageBox.Show("删除此数据?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {

                            string id=dataGridView1.SelectedCells[0].Value.ToString() ;
                            this.deleteData(id);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                LogNotifier.Log(LogType.Error, "启动系统时发生错误：" + ex.Message+ "系统提示");
               // MessageBox.Show("启动系统时发生错误：" + ex.Message, "系统提示");
            }
        }


        private void queryBtn_Click(object sender, EventArgs e)
        {
            string Id = this.queryIdTxt.Text;
            try
            {
                this.getData(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string Id=this.deleteIdTxt.Text;
            this.deleteData(Id);
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
         string   Id = this.changeIdTxt.Text;
         string nameOpcItemName = this.changeNameTxt.Text;
         string ItemValue = this.changeValueTxt.Text;
         string State = (1).ToString();
        this.updateData(Id,nameOpcItemName,ItemValue,State);
        }

        private void OpcStart_Click(object sender, EventArgs e)
        {
            if (this.Init("Kaohe.xml"))
            {
                LogNotifier.Log( LogType.Info, "plc初始化成功");
            }
            else
            {
                 LogNotifier.Log( LogType.Info,"plc初始化失败");
            }
        }
    }
}
