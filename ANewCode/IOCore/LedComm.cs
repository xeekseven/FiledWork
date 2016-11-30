using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Threading;

namespace IOCore
{
    /// <summary>
    /// LED发送串口操作类
    /// </summary>
    public class LedComm : IOCommSend
    {
        private SerialPort port;
        private bool isPortOpen = false;
        private string errorMsg = "";
        private int pingNum = 0;
        private int delayTime = 100;
        private DateTime startTime = DateTime.Now;
        private DateTime endTime = DateTime.Now;
        private CompleteComm completeComm = new CompleteComm();

        /// <summary>
        /// 建立串口对象
        /// </summary>
        /// <param name="portName">PortName,例如"COM1","COM2"等</param>
        /// <param name="baudRate">波特率,例如57600等</param>
        /// <returns>true:成功/false:失败</returns>
        public bool CreateCom(string portName, int baudRate)
        {
            try
            {
                port = new SerialPort(portName);
                port.BaudRate = baudRate;//波特率
                port.Parity = Parity.None;//无奇偶校验位
                port.StopBits = StopBits.One;//两个停止位
                port.Handshake = Handshake.None;//控制协议
                port.ReceivedBytesThreshold = 8;//设置 DataReceived 事件发生前内部输入缓冲区中的字节数
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);   //DataReceived事件委托
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        public bool Open()
        {
            try
            {
                if (!isPortOpen && !port.IsOpen)
                    port.Open();
                System.Threading.Thread.Sleep(20);
                isPortOpen = port.IsOpen;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        public bool Close()
        {
            try
            {
                if(null == port)
                    return false;
                port.Close();
                isPortOpen = port.IsOpen;
                port = null;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                isPortOpen = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置LED参数
        /// </summary>       
        /// <param name="ledArg">LED参数</param>
        public bool SetLedArg(Params.LedArg ledArg)
        {
            try
            {
                if (null == ledArg)
                {
                    errorMsg = "Params LedArg is not null !";
                    return false;
                }

                completeComm.SetLedArg(ledArg);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 开屏
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        public bool OpenPing()
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = BaseComm.OpenPing;
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 开屏
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        public bool OpenPing(int iPingHao)
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = (new BaseComm()).SendOpenPing(iPingHao);
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关屏
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        public bool ClosePing()
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = BaseComm.ClosePing;
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 关屏
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        public bool ClosePing(int iPingHao)
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = (new BaseComm()).SendClosePing(iPingHao);
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        public bool ClearPing()
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = BaseComm.ClearPing;
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        public bool ClearPing(int iPingHao)
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = (new BaseComm()).SendClearPing(iPingHao);
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        
        public bool SendMsg(int ledNo, string msg, Color fontColor)
        {
            try
            {
                if (!isPortOpen)
                    //return false;
                 
                startTime = DateTime.Now;
                byte[] sendBytes = completeComm.SendMsg(ledNo, msg, fontColor);
 
                port.Write(sendBytes, 0, sendBytes.Length);
                endTime = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }

            return true;
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">信息序号</param>
        /// <param name="sMsg">信息</param>
        /// <param name="iCount">一屏显示的字数</param>
        /// <param name="eCharType">字符类型</param>
        /// <param name="eDisplayType">显示方式</param>
        /// <returns>true:成功/false:失败</returns>
        public bool SendPing(int iPingHao, int iPingIndex, string sMsg, int iCount, CharType eCharType, DisplayType eDisplayType)
        {
            try
            {
                if (!isPortOpen)
                    return false;
                string[] strs = new string[0];
                int iIndex = iPingIndex.Equals(0) ? 1 : iPingIndex;//0号区域（五字屏和数字区域）起始ID是1，1号区域（即汉字区域）起始ID是3
                switch (eDisplayType)
                {
                    case DisplayType.SBCHorizontal:
                    case DisplayType.SBCVertical:
                        strs = Params.ResolveChar.GetChars(sMsg, iCount);
                        break;
                    case DisplayType.Vertical:
                    case DisplayType.Horizontal:
                    case DisplayType.None:
                    default:
                        strs = Params.ResolveChar.GetUChars(sMsg, iCount);
                        break;
                }
                startTime = DateTime.Now;
                pingNum = strs.Length;
                for (int i = 0; i < pingNum; i++)
                {
                    byte[] sendBytes = completeComm.SendPing(iPingHao, i + iIndex, strs[i], eCharType, eDisplayType);
                    if (pingNum != 1)
                        Thread.Sleep(this.delayTime);
                    port.Write(sendBytes, 0, sendBytes.Length);
                }
                endTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">信息序号</param>
        /// <param name="sMsg">信息</param>
        /// <param name="iCount">一屏显示的字数</param>
        /// <param name="eDisplayType">显示方式</param>
        /// <returns>true:成功/false:失败</returns>
        public bool SendPing(int iPingHao, int iPingIndex, string sMsg, int iCount, DisplayType eDisplayType)
        {
            return SendPing(iPingHao, iPingIndex, sMsg, iCount, 0, eDisplayType);
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">信息序号</param>
        /// <param name="sMsg">信息</param>
        /// <param name="iCount">一屏显示的字数</param>
        /// <returns>true:成功/false:失败</returns>
        public bool SendPing(int iPingHao, int iPingIndex, string sMsg, int iCount)
        {
            return SendPing(iPingHao, iPingIndex, sMsg, iCount, 0, 0);
        }
        /// <summary>
        /// 宁波条屏发送
        /// 开始3个字显示品牌名，接下来3个字显示规格，最后显示数量，品牌与规格显示颜色不一样。        /// 
        /// </summary>
        /// <param name="iPingHao">屏号</param>
        /// <param name="productNameFirst">名称第一部分，品牌</param>
        /// <param name="productNameSecond">名称第二部分，规格</param>
        /// <param name="Qty">数量</param>
        /// <returns></returns>
        public bool SendPingNB(int iPingHao, string productNameFirst, string productNameSecond, string Qty)
        {
            try
            {
                if (!isPortOpen)
                    return false; 
                startTime = DateTime.Now;
                byte[] sendBytes = completeComm.SendPingNB(iPingHao, productNameFirst,productNameSecond,Qty);
                port.Write(sendBytes, 0, sendBytes.Length);
                endTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 设置控制卡（显示屏）ID
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iNewPingHao">新条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        public bool SetPingHao(int iPingHao, int iNewPingHao)
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = completeComm.SetPingHao(iPingHao, iNewPingHao);
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 设置LED分区信息
        /// </summary>
        /// <param name="iPingHao"></param>
        /// <param name="ledAreaInfo"></param>
        /// <returns></returns>
        public bool SetLedArea(int iPingHao, LedAreaInfo ledAreaInfo)
        {
            try
            {
                if (!isPortOpen)
                    return false;
                byte[] sendBytes = completeComm.SetLedArea(iPingHao, ledAreaInfo);
                port.Write(sendBytes, 0, sendBytes.Length);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorInfo
        {
            get { return this.errorMsg; }
        }

        /// <summary>
        /// 屏幕数
        /// </summary>
        public int PingNum
        {
            get { return this.pingNum; }
        }

        /// <summary>
        /// 发屏用时（毫秒）
        /// </summary>
        public int UsedTime
        {
            get
            {
                TimeSpan ND = endTime - startTime;
                return ND.Seconds * 1000 + ND.Milliseconds;
            }
        }

        /// <summary>
        /// 设置发屏时差（毫秒）
        /// </summary>
        public int SetDelayTime
        {
            set
            {
                this.delayTime = value;
            }
        }
        /// <summary>
        /// Led返回信息事件
        /// </summary>
        public event LedDataReceived EventLedData;

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                StringBuilder curline = new StringBuilder();
                //循环接收数据
                while (port.BytesToRead > 0)
                {
                    char ch = (char)port.ReadByte();
                    curline.Append(ch);
                }
                byte[] bt = Encoding.Default.GetBytes(curline.ToString());
                if (null != EventLedData)
                    EventLedData(sender, bt);
            }
            catch (Exception ex)
            {
                this.errorMsg = ex.Message;
            }
        }
    }
}
