using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.IO;


namespace Huike.Log
{
    public class SystemLog
    {
        
        public SystemLog()
		{
			logQueue			=new Queue();
		}

#region "变量"
        private Thread logThread=null;
        private Queue logQueue=null;
        private bool quitLogThread=false;
#endregion
#region "方法"
        public void StartThread()
        {
            logThread=new Thread(new ThreadStart(HandleLogQueueThread));
        }

        public void StopThread()
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

        private void HandleLogQueueThread()
        {
            while(!quitLogThread)
            {
                try{
                    bool logFlag=false;
                    string log="";
                    lock(logQueue)
                    {
                        logFlag=logQueue.Count>0;
                        if(logQueue.Count>0)
                        {
                            log=logQueue.Dequeue().ToString();
                        }
                    }
                    if(logFlag)
                    {
                        string[] msg=log.Split(new char[]{'|'});
                        this.WriteLog(msg[0],msg[1]);
                    }
                    else if(!quitLogThread)
                        System.Threading.Thread.Sleep(50);
                }
                catch(Exception ex)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        private void WriteLog(string addr,string msg)
        {
            string fileName="";
            switch(addr)
            {
                case "BarCode":
                    fileName =".\\Log\\BarCodeLog";
                    break;
                case "BarCodeLog":
                    fileName=".\\Log\\BarCodeLog";
                    break;
                default :
                    fileName=".\\Log\\MainLog";
                    break;

            }
            FileStream fs;
            StreamWriter writer;
            try{
                fileName=fileName+DateTime.Now.ToString("yyyyMMdd")+".log";
                fs=new FileStream(fileName,FileMode.Append,FileAccess.Write);
                writer=new StreamWriter(fs);
                writer.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").PadRight(20)+msg);
                writer.Flush();
                writer.Close();

            }catch(Exception ex)
            {
                string strErr=ex.Message;
            }
            finally
            {
                writer=null;
                fs=null;
            }
        }
#endregion
        
    }
}
