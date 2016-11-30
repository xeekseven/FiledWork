using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore.Encod
{
    /// <summary>
    /// 文本编码
    /// </summary>
    internal static class TextEncod
    {
        /// <summary>
        /// UNICODE编码处理
        /// </summary>
        /// <param name="sMsg">信息</param>
        /// <param name="bytes">返回字节</param>
        /// <returns>消息长度</returns>
        public static int CopyWchar(string sMsg, ref byte[] bytes)
        {
            int iLen = 0;
            char ch;
            int kk = 0;

            for (int i = 0; i < sMsg.Length; i++)
            {
                ch = Convert.ToChar(sMsg[i]);
                if (ch >= 0x80)
                {
                    if (ch <= 0xFF)
                    {
                        ch = Convert.ToChar(Convert.ToInt32(ch) - 128);
                    }
                    else if (ch >= 0x2000 && ch <= 0x266F)
                    {
                        ch = Convert.ToChar(Convert.ToInt32(ch) - 8192 + 128);
                    }
                    else if (ch >= 0x3000 && ch <= 0x33FF)
                    {
                        ch = Convert.ToChar(Convert.ToInt32(ch) - 12288 + 1648 + 128);
                    }
                    else if (ch >= 0x4E00 && ch <= 0x9FA5)
                    {
                        ch = Convert.ToChar(Convert.ToInt32(ch) - 19968 + 1648 + 1024 + 128);
                    }
                    //else if(ch >= 0xF900 && ch <= 0xFFFF)
                    else if (ch >= 0xF900)
                    {
                        ch = Convert.ToChar(Convert.ToInt32(ch) - 63744 + 1648 + 1024 + 20902 + 128);
                    }
                    ch = Convert.ToChar(Convert.ToInt32(ch) + 128);
                }
                bytes[kk] = Convert.ToByte(ch & 0xff);
                kk++;
                bytes[kk] = Convert.ToByte((ch >> 8) & 0xff);
                kk++;

                iLen += 2;
            }
            return iLen;
        }

        /// <summary>
        /// 国标码(GB2312)编码处理
        /// </summary>
        /// <param name="sMsg">信息</param>
        /// <param name="bytes">返回字节</param>
        /// <returns>消息长度</returns>
        public static int CopyChar(string sMsg, ref byte[] bytes)
        {
            int iLen = 0;
            Encoding dd = Encoding.GetEncoding("GB2312");
            byte[] gbbyte = dd.GetBytes(sMsg);
            char ch;
            int kk = 0;

            for (int i = 0; i < gbbyte.Length; i++)
            {
                ch = Convert.ToChar(gbbyte[i]);
                bytes[kk] = Convert.ToByte(ch & 0xff);
                kk++;
                iLen++;
            }

            return iLen;
        }

    }
}
