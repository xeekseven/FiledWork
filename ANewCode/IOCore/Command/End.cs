using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore.Command
{
    /// <summary>
    /// 4字节信息尾部
    /// </summary>
    public class End
    {
        private byte[] endByte = new byte[4]{
             0x00, 0x00, 0x00, 0x50
        };

        /// <summary>
        /// 16bit校验和，将本字节之前所有字节相加，取低16位
        /// </summary>
        public int CheckSum
        {
            set
            {
                endByte[0] = Convert.ToByte(value & 0x00ff);
                endByte[1] = Convert.ToByte(value >> 8 & 0x00ff);
            }
        }

        /// <summary>
        /// 4字节信息尾部编码
        /// </summary>
        public byte[] EndBytes
        {
            get
            {
                return endByte;
            }
        }

        /// <summary>
        /// 设置4字节信息尾部编码
        /// </summary>
        /// <param name="iCheckSum">16bit校验和</param>
        public void SetEndBytes(int iCheckSum)
        {
            endByte[0] = Convert.ToByte(iCheckSum & 0x00ff);
            endByte[1] = Convert.ToByte(iCheckSum >> 8 & 0x00ff);
        }
    }
}
