using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore
{
    /// <summary>
    /// 基础指令
    /// </summary>
    internal class BaseComm
    {
        private byte[] completeByte = null;
        private Command.Head head = new Command.Head();
        private Command.Argument argument = new Command.Argument();
        private Command.Expand expand = new Command.Expand();
        private Command.End end = new Command.End();
       
        /// <summary>
        /// 关屏指令
        /// </summary>
        public static byte[] ClosePing = new byte[52]{
            0xA0, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x19, 0x19, 0x18,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x1e, 0x01, 0x00, 0x50};
        /// <summary>
        /// 开屏指令
        /// </summary>
        public static byte[] OpenPing = new byte[52]{ 
            0xA0, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x19, 0x19, 0x18,
            0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x1f, 0x01, 0x00, 0x50
            };
        /// <summary>
        /// 清屏指令
        /// </summary>
        public static byte[] ClearPing = new byte[52]{ 
            0xA0, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x06, 0x05,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0xe5, 0x00, 0x00, 0x50
            };

        /// <summary>
        /// 发送关屏信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>协议编码</returns>
        public byte[] SendClosePing(int iPingHao)
        {
            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm19);

            argument.IPingIndex = 0;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);

            int iCheckSum = 0;
            for (int i = 0; i < iBagLen - 4; i++)
            {
                iCheckSum += completeByte[i];
            }

            end.SetEndBytes(iCheckSum);

            end.EndBytes.CopyTo(completeByte, iBagLen - 4);

            return completeByte;
        }
        /// <summary>
        /// 发送开屏信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>协议编码</returns>
        public byte[] SendOpenPing(int iPingHao)
        {
            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm19);

            argument.IPingIndex = 1;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);

            int iCheckSum = 0;
            for (int i = 0; i < iBagLen - 4; i++)
            {
                iCheckSum += completeByte[i];
            }

            end.SetEndBytes(iCheckSum);

            end.EndBytes.CopyTo(completeByte, iBagLen - 4);

            return completeByte;
        }
        /// <summary>
        /// 发送清屏信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>协议编码</returns>
        public byte[] SendClearPing(int iPingHao)
        {
            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm06);

            argument.IPingIndex = 0;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);

            int iCheckSum = 0;
            for (int i = 0; i < iBagLen - 4; i++)
            {
                iCheckSum += completeByte[i];
            }

            end.SetEndBytes(iCheckSum);

            end.EndBytes.CopyTo(completeByte, iBagLen - 4);

            return completeByte;
        }
    }
}
