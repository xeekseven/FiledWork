using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpServer
{
    class Program
    {
        private static Huike.Tcp.Server server = null;
        private static Huike.Tcp.Server server2 = null;
        private static Huike.Tcp.Server server3 = null;
        private static Huike.Tcp.Client client = new Huike.Tcp.Client();
      
        static void Main(string[] args)
        {
            
            try
            {
               
                server.OnConnect += new Huike.Tcp.SocketEventHandler(server_OnConnect);
                
            }
            catch{

            }
          
        }
        public static void server_OnConnect(object sender, Huike.Tcp.SocketEventArgs e)
        {
        }
        public static void server_OnReceive(object sender, Huike.Tcp.SocketEventArgs e)
        {

        }
    }
}
