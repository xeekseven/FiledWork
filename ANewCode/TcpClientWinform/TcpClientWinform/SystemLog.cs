using System;
using System.IO;
using System.Collections;
using System.Threading;

namespace Huike.Log
{
    /// <summary>
    /// SystemLog 记录日志。
    /// </summary>
    public class SystemLog
    {
        public SystemLog()
        {
            logQueue = new Queue();
        }

        #region "变量"
        private Thread logThread = null;										//日志处理线程序对象
        private Queue logQueue = null;										//日志队列对象

        private bool quitLogThread = false;										//退出线程标志
        #endregion

        #region "方法"
        /// <summary>
        /// 启动线程
        /// </summary>
        public void StartThead()
        {
            logThread = new Thread(new ThreadStart(HandleLogQueueThread));
            logThread.Name = "logThread";
            logThread.Start();
        }
        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopThead()
        {
            try
            {
                if (logThread != null)
                {
                    quitLogThread = true;
                    logThread.Resume();
                }
            }
            catch
            {
                try
                {
                    logThread.Abort();
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 添加日志队列
        /// </summary>
        /// <param name="addr">报警信息</param>
        public void AddLogQueue(string logType, string logInfo)
        {
            lock (logQueue)
            {
                logQueue.Enqueue(logType + "|" + logInfo);
            }
            if (this.logThread == null)
            {

            }
            if (logThread.ThreadState == ThreadState.Suspended)
            {
                logThread.Resume();

            }
        }
        /// <summary>
        /// 处理日志队列线程
        /// logType+"|"+logInfo;
        /// </summary>
        private void HandleLogQueueThread()
        {
            //测试线程在调用数据库未完成时，主线程是否还可以进行调用，测试结果：可以在两个线程同时调用。
            //			Huike.DataLogic.Manager.Tsysparam_ipManager  manager=new Huike.DataLogic.Manager.Tsysparam_ipManager();
            //			if(manager.UpdateTest("update tsysparam_ip set port=1000 where pcname='SWJ6'"))
            //			{
            //				System.Windows.Forms.MessageBox.Show("过程执行完毕，成功","线程提示");
            //			}
            //			else
            //			{
            //				System.Windows.Forms.MessageBox.Show("过程执行完毕，失败","线程提示");
            //			}
            while (!quitLogThread)
            {
                try
                {
                    bool logFlag = false;
                    string log = "";
                    lock (logQueue)
                    {
                        logFlag = logQueue.Count > 0;
                        if (logQueue.Count > 0)
                        {
                            log = logQueue.Dequeue().ToString();
                        }
                    }

                    if (logFlag)
                    {
                        string[] msg = log.Split(new char[] { '|' });
                        //报警信息处理
                        this.WriteLog(msg[0], msg[1]);
                    }
                    else if (!quitLogThread)
                        //logThread.Suspend();
                        System.Threading.Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="addr">故障发生地点</param>
        /// <param name="msg">日志</param>
        private void WriteLog(string addr, string msg)
        {
            string fileName = "";
            switch (addr)
            {
                case "BarCode":
                    fileName = ".\\Log\\BarCode";
                    break;
                case "BarCodeLog":
                    fileName = ".\\Log\\BarCodeLog";
                    break;
                default:
                    fileName = ".\\Log\\MainLog";
                    break;
            }

            System.IO.FileStream fs;
            System.IO.StreamWriter writer;
            try
            {
                fileName = fileName + DateTime.Now.ToString("yyyyMMdd") + ".log";
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(fs);
                writer.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").PadRight(20) + msg);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }
            finally
            {
                writer = null;
                fs = null;
            }
        }
        #endregion
    }
}
