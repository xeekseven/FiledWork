using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IOCore.Command
{
    /// <summary>
    /// 指令扩展内容
    /// </summary>
    internal class Expand
    {
        private byte[] expandByte = new byte[0];

        /// <summary>
        /// 指令扩展内容
        /// </summary>
        public byte[] ExpandBytes
        {
            get
            {
                return expandByte;
            }
        }

        /// <summary>
        /// 设置指令扩展内容
        /// </summary>
        /// <param name="sMsg">信息</param>
        /// <param name="bmpArg">位图参数</param>
        /// <param name="font">字体</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="eDisplay">显示类型</param>
        public void SetExpandBytes(string sMsg, Params.BitmapArg bmpArg, Font font, Color fontColor, DisplayType eDisplay)
        {

            switch (eDisplay)
            {
                case DisplayType.SBCHorizontal:
                    {
                        Bitmap bmp = Encod.ImageEncod.SBCHorizontalBitmap(sMsg, bmpArg, font, fontColor);
                        expandByte = Encod.ImageEncod.GetImageBytes(bmp, ColorType.Double);
                    }
                    break;
                case DisplayType.SBCVertical:
                    {
                        Bitmap bmp = Encod.ImageEncod.SBCVerticalBitmap(sMsg, bmpArg, font, fontColor);
                        expandByte = Encod.ImageEncod.GetImageBytes(bmp, ColorType.Double);
                    }
                    break;
                case DisplayType.Vertical:
                    {
                        Bitmap bmp = Encod.ImageEncod.VerticalBitmap(sMsg, bmpArg, font, fontColor);
                        expandByte = Encod.ImageEncod.GetImageBytes(bmp, ColorType.Double);
                    }
                    break;
                case DisplayType.Horizontal:
                case DisplayType.None:
                default:
                    {
                        Bitmap bmp = Encod.ImageEncod.NoneBitmap(sMsg, bmpArg, font, fontColor);
                        expandByte = Encod.ImageEncod.GetImageBytes(bmp, ColorType.Double);
                    }
                    break;
            }
        }
        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="ledNo"></param>
        /// <param name="msg"></param>
        /// <param name="fornColor"></param>
        public void SetExpandBytesSendMsg(int ledNo, string msg, Color fornColor)
        {
            byte[]  byteMsg=new byte[1024];
            if (msg.Length > 512)
            {
                msg = msg.Substring(0, 512);
            }
            int msgLen = Encod.TextEncod.CopyWchar(msg, ref byteMsg);            
            expandByte = new byte[msgLen];
            for (int i = 0; i < expandByte.Length; i++)
            {
                expandByte[i] = byteMsg[i];
            }
        }
        public void SetExpandBytesNB(string productNameFirst, string productNameSecond, string qty, Color fontColor)
        {
            Bitmap bmp = Encod.ImageEncod.GetLedBmpNB(productNameFirst, productNameSecond,qty,fontColor);
            expandByte = Encod.ImageEncod.GetImageBytes(bmp, ColorType.Double);
        }
    }
}
