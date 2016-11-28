using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TcpServer
{
    class Program
    {
        private static Huike.Tcp.Server server = null;
        private static Huike.Tcp.Server server2 = null;
        private static Huike.Tcp.Server server3 = null;
        private static Huike.Tcp.Client client = new Huike.Tcp.Client();
        private static Hashtable hatForSockeTab;
        private static Huike.Log.SystemLog log;
        private static int sendCount = 0, recCount = 0;
        static void Main(string[] args)
        {
            
            try
            {
                   
                server.OnReceive += new Huike.Tcp.ReceiveEventHandler(server_OnReceive);
                server.OnDisconnect += new Huike.Tcp.SocketEventHandler(server_OnDisconnect);
                server.OnConnect += new Huike.Tcp.SocketEventHandler(server_OnConnect);
                
            }
            catch(Exception ex){
                //throw(ex);
                Console.WriteLine(ex);
            }
            Console.ReadLine();
          
        }
        public static void server_OnConnect(object sender, Huike.Tcp.SocketEventArgs e)
        {
            if (hatForSockeTab.Contains(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5)))
            {
                hatForSockeTab.Remove(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5));
            }
            hatForSockeTab.Add(e.RemoteAddress.Substring(0, e.RemoteAddress.Length - 5), e.RemoteAddress);
        }
        public static void server_OnReceive(object sender, Huike.Tcp.ReceiveEventArgs e)
        {
            try
            {
                string msg = e.Read().ToString();
                Console.WriteLine(msg);
                log.AddLogQueue("", "IP:" + e.RemoteAddress + "    数据:" + msg);
                recCount += 1;

                string orderID = msg.Split(',')[0];
                orderID = orderID.Remove(0, 7);
                string retMsg = "12写入植入";
                System.Threading.Thread.Sleep(Convert.ToInt32("122"));
                e.Write(retMsg);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message + "" + System.DateTime.Now.ToShortDateString() + "");
            }
        }
        public static void server_OnDisconnect(object sender, Huike.Tcp.SocketEventArgs e)
        {
        }
    }
}
