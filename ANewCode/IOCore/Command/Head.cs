using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
    字节0：	 信息头，固定 0xA0
    字节1-2：整个信息包长度，低字节在前，高字节在后。
    字节3-4： 16bit屏ID，低字节在前，高字节在后，0x0000代表广播信息
    字节5-8： 流水号低32位，作为指令的临时唯一标识，服务器端可以以此ID作为指令的唯一标识。
	字节9-12：流水号高32位，低字节在前，高字节在后。（该字段暂时保留）
	字节13：具体指令代码。详见第三部分具体描述。(在终端回馈包中，该字段用于表示错误代码)
    字节14-15：保留，填充为0.
 */
namespace IOCore.Command
{
    /// <summary>
    /// 16字节信息头部
    /// </summary>
    internal class Head
    {
        private byte[] headByte = new byte[16]{
            0xA0, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00,
            0x00, 0x03, 0x03, 0x02
        };

        /// <summary>
        /// 设置信息长度
        /// </summary>
        public int IDataLeigth
        {
            set
            {
                headByte[1] = Convert.ToByte(value & 0x00ff);
                headByte[2] = Convert.ToByte(value >> 8 & 0x00ff);
            }
        }

        /// <summary>
        /// 设置屏号
        /// </summary>
        public int IPingHao
        {
            set
            {
                headByte[3] = Convert.ToByte(value & 0x00ff);
                headByte[4] = Convert.ToByte(value >> 8 & 0x00ff);
            }
        }

        /// <summary>
        /// 设置指令方式
        /// </summary>
        public CommAction ECommAction
        {
            set
            {
                headByte[13] = Convert.ToByte(value);
                headByte[14] = Convert.ToByte(value);
                headByte[15] = Convert.ToByte(Convert.ToInt32(value) - 1);
            }
        }

        /// <summary>
        /// 16字节信息头部编码
        /// </summary>
        public byte[] HeadBytes
        {
            get
            {
                return headByte;
            }
        }

        /// <summary>
        /// 设置16字节信息头部编码
        /// </summary>
        /// <param name="iPingHao">屏号</param>
        /// <param name="iDataLeigth">信息长度</param>
        /// <param name="ECommAction">指令方式</param>
        /// <returns>头部编码</returns>
        public void SetHeadBytes(int iPingHao, int iDataLeigth, CommAction eCommAction)
        {
            headByte[1] = Convert.ToByte(iDataLeigth & 0x00ff);
            headByte[2] = Convert.ToByte(iDataLeigth >> 8 & 0x00ff);
            headByte[3] = Convert.ToByte(iPingHao & 0x00ff);
            headByte[4] = Convert.ToByte(iPingHao >> 8 & 0x00ff);
            headByte[13] = Convert.ToByte(eCommAction);
            headByte[14] = Convert.ToByte(eCommAction);
            headByte[15] = Convert.ToByte(Convert.ToInt32(eCommAction) - 1);
        }

        /// <summary>
        /// Int型的数据中的高位字节和低位字节换个位置
        /// </summary>
        /// <param name="iNum"></param>
        /// <returns></returns>
        private Int32 HL(Int32 iNum)
        {
            Int32 b = 0;
            Int32 h = iNum & 0x00ff;
            Int32 l = iNum & 0xff00;
            b = (h << 8) | (l >> 8);
            return b;
        }
    }
}
