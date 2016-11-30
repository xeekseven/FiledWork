using System;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IOCore
{
    /// <summary>
    /// 完整指令
    /// </summary>
    internal class CompleteComm
    {
        private byte[] completeByte = null;
        private Color fontColor = Color.FromArgb(10, 60, 255);
        private Font font = new Font("宋体", 10.5F);
        private Params.BitmapArg bmpArg = null;
        private Command.Head head = new Command.Head();
        private Command.Argument argument = new Command.Argument();
        private Command.Expand expand = new Command.Expand();
        private Command.End end = new Command.End();

        /// <summary>
        /// 设置LED参数
        /// </summary>
        /// <param name="ledArg">LED参数</param>
        public void SetLedArg(Params.LedArg ledArg)
        {
            //argument.SetArgumentBytes(0, ledArg);
            argument.SetArgumentBytes(1, ledArg);//neil改
            font = ledArg.FontArg;
            bmpArg = ledArg.BitmapArg;
            switch (ledArg.FontColorArg)
            {
                case FontColor.Red:
                    fontColor = Color.FromArgb(0, 255, 255);
                    break;
                case FontColor.Green:
                    fontColor = Color.FromArgb(255, 0, 255);
                    break;
                case FontColor.Blue:
                    fontColor = Color.FromArgb(255, 255, 0);
                    break;
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">屏幕显示顺序</param>
        /// <param name="sMsg">信息</param>
        /// <param name="eCharType">字符类型</param>
        /// <param name="eDisplayType">显示方式</param>
        /// <returns>协议编码</returns>
        public byte[] SendPing(int iPingHao, int iPingIndex, string sMsg, CharType eCharType, DisplayType eDisplayType)
        {
            expand.SetExpandBytes(Params.ResolveChar.GetChar(sMsg, eCharType), bmpArg, font, fontColor, eDisplayType);

            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm03);

            argument.IPingIndex = iPingIndex;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);
            expand.ExpandBytes.CopyTo(completeByte, 48);

            int iCheckSum = 0;
            for (int i = 0; i < iBagLen - 4; i++)
            {
                iCheckSum += completeByte[i];
            }

            end.SetEndBytes(iCheckSum);

            end.EndBytes.CopyTo(completeByte, iBagLen - 4);

            return completeByte;
        }
        public byte[] SendMsg(int ledNo, string msg, Color fornColor)
        {
            expand.SetExpandBytesSendMsg(ledNo, msg, fontColor);

            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(ledNo, iBagLen, CommAction.Comm03);

            argument.IPingIndex = 1;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);
            expand.ExpandBytes.CopyTo(completeByte, 48);

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
        /// 宁波条屏发送
        /// 开始3个字显示品牌名，接下来3个字显示规格，最后显示数量，品牌与规格显示颜色不一样。        /// 
        /// </summary>
        /// <param name="iPingHao">屏号</param>
        /// <param name="productNameFirst">名称第一部分，品牌</param>
        /// <param name="productNameSecond">名称第二部分，规格</param>
        /// <param name="Qty"></param>
        /// <returns></returns>
        public byte[] SendPingNB(int iPingHao, string productNameFirst, string productNameSecond, string Qty)
        {
            expand.SetExpandBytesNB(productNameFirst,productNameSecond ,Qty, fontColor);

            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm03);

            argument.IPingIndex = 1;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);
            expand.ExpandBytes.CopyTo(completeByte, 48);

            int iCheckSum = 0;
            for (int i = 0; i < iBagLen - 4; i++)
            {
                iCheckSum += completeByte[i];
            }

            end.SetEndBytes(iCheckSum);

            end.EndBytes.CopyTo(completeByte, iBagLen - 4);

            return completeByte;
        }
        public byte[] SetLedArea(int iPingHao)
        {
            byte[] data = new byte[1];


            return data;
        }

        /// <summary>
        /// 设置条屏号
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iNewPingHao">新条屏号</param>
        /// <returns>协议编码</returns>
        public byte[] SetPingHao(int iPingHao, int iNewPingHao)
        {
            int iBagLen = head.HeadBytes.Length + argument.ArgumentBytes.Length + expand.ExpandBytes.Length + end.EndBytes.Length;

            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm25);

            argument.IPingIndex = iNewPingHao;

            completeByte = new byte[iBagLen];

            head.HeadBytes.CopyTo(completeByte, 0);
            argument.ArgumentBytes.CopyTo(completeByte, 16);
            expand.ExpandBytes.CopyTo(completeByte, 48);

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
        /// 设置LED分区信息
        /// </summary>
        /// <param name="iPingHao"></param>
        /// <param name="ledAreaInfo"></param>
        /// <returns></returns>
        public byte[] SetLedArea(int iPingHao, LedAreaInfo ledAreaInfo)
        {
            int iBagLen = head.HeadBytes.Length + 32 + 0 + end.EndBytes.Length;
            head.SetHeadBytes(iPingHao, iBagLen, CommAction.Comm29);
            completeByte = new byte[iBagLen];
            head.HeadBytes.CopyTo(completeByte, 0);
            byte[] areaByte = ledAreaInfo.GetByte();
            areaByte.CopyTo(completeByte, 16);
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