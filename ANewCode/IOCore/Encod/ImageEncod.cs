using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IOCore.Encod
{
    /// <summary>
    /// 图片编码
    /// </summary>
    internal static class ImageEncod
    {
        /// <summary>
        /// 获取图片16进制编码
        /// </summary>
        /// <param name="bmp">图片</param>
        /// <param name="colorType">颜色模式</param>
        /// <returns>16进制编码</returns>
        public static byte[] GetImageBytes(Bitmap bmp, ColorType colorType)
        {
            int iColorType = Convert.ToInt32(colorType);
            byte[] dots = new byte[bmp.Width * bmp.Height * iColorType];
            byte[] bytes = new byte[dots.Length / 8];

            Color pixel;
            int x, y;
            if (iColorType == 1)
            {
                //单色模式，不分红绿
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        if (pixel.R + pixel.G + pixel.B > 50)
                            dots[y * bmp.Width + x] = 1;
                        else
                            dots[y * bmp.Width + x] = 0;
                    }
                }
            }
            else if (iColorType == 2)
            {
                //双色模式，先红
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        if (pixel.R >= 50)
                            dots[y * bmp.Width + x] = 1;
                        else
                            dots[y * bmp.Width + x] = 0;
                    }
                }
                int offset = bmp.Width * bmp.Height;
                //后绿
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        if (pixel.G >= 50)
                            dots[y * bmp.Width + x + offset] = 1;
                        else
                            dots[y * bmp.Width + x + offset] = 0;
                    }
                }
            }
            else
            {
                //双色模式，先红
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        if (pixel.R >= 50)
                            dots[y * bmp.Width + x] = 1;
                        else
                            dots[y * bmp.Width + x] = 0;
                    }
                }
                int offset = bmp.Width * bmp.Height;
                //后绿
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        if (pixel.G >= 50)
                            dots[y * bmp.Width + x + offset] = 1;
                        else
                            dots[y * bmp.Width + x + offset] = 0;
                    }
                }
                offset = bmp.Width * bmp.Height * 2;
                //后蓝
                for (y = 0; y < bmp.Height; y++)
                {
                    for (x = 0; x < bmp.Width; x++)
                    {
                        pixel = bmp.GetPixel(x, y);
                        if (pixel.B >= 50)
                            dots[y * bmp.Width + x + offset] = 1;
                        else
                            dots[y * bmp.Width + x + offset] = 0;
                    }
                }
            }

            encodeImageBytes(dots, bytes);

            return bytes;
        }

        /// <summary>
        /// 生成16进制编码
        /// </summary>
        /// <param name="dots">二进制编码</param>
        /// <param name="bytes">16进制编码</param>
        private static void encodeImageBytes(byte[] dots, byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i += 2)
            {
                string strBinary = "";
                for (int k = 0; k < 8; k++)
                {
                    strBinary += dots[i * 8 + k];
                }
                bytes[i + 1] = Convert.ToByte(BinaryEncod.DecToHex(BinaryEncod.BinToDec(strBinary)), 16);
                strBinary = "";
                for (int k = 0; k < 8; k++)
                {
                    strBinary += dots[(i + 1) * 8 + k];
                }
                bytes[i] = Convert.ToByte(BinaryEncod.DecToHex(BinaryEncod.BinToDec(strBinary)), 16);
            }
        }

        /// <summary>
        /// 生成横体(None)文字图片
        /// </summary>
        /// <param name="Info">信息</param>
        /// <param name="bmpArg">位图参数</param>
        /// <param name="font">字体</param>
        /// <param name="fontColor">字体颜色</param>
        /// <returns>图片</returns>
        public static Bitmap NoneBitmap(string Info, Params.BitmapArg bmpArg, Font font, Color fontColor)
        {
            Bitmap bmp = new Bitmap(bmpArg.BackWidth, bmpArg.BackHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                int x = -1;
                for (int i = 0; i < Info.Length; i++)
                {
                    string str = Info[i].ToString();
                    using (Font tFont = new Font(font, FontStyle.Regular))
                    {
                        using (Brush brush = new SolidBrush(fontColor))
                        {
                            float ff = (float)(Encod.Regular.IsChineseCharacter(str) ? 1.5 : Encod.Regular.IsNotChineseCharacter(str) ? 0.8 : 1.2);
                            graphics.DrawString(str, tFont, brush, x, 1);
                            x += Convert.ToInt32(font.Size * ff);
                        }
                    }
                }
            }
            return bmp;
        }

        /// <summary>
        /// 生成竖体文字图片(数字)
        /// </summary>
        /// <param name="Info">信息</param>
        /// <param name="bmpArg">位图参数</param>
        /// <param name="font">字体</param>
        /// <param name="fontColor">字体颜色</param>
        /// <returns>图片</returns>
        public static Bitmap VerticalBitmap(string Info, Params.BitmapArg bmpArg, Font font, Color fontColor)
        {
            Bitmap bmp = new Bitmap(bmpArg.BackWidth, bmpArg.BackHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                int x = -1;
                for (int i = 0; i < Info.Length; i++)
                {
                    string str = Info[i].ToString();
                    using (Font tFont = new Font(font, FontStyle.Regular))
                    {
                        using (Brush brush = new SolidBrush(fontColor))
                        {
                            //float ff = (float)(Encod.Regular.IsChineseCharacter(str) ? 1.5 : Encod.Regular.IsNotChineseCharacter(str) ? 0.8 : 1.2);
                            float ff = (float)(Encod.Regular.IsChineseCharacter(str) ? 1.5 : Encod.Regular.IsNotChineseCharacter(str) ? 0.7 : 1.2);
                            //graphics.DrawString(str, tFont, brush, x, 1);
                            graphics.DrawString(str, tFont, brush, x, 3);//neil
                            x += Convert.ToInt32(font.Size * ff);
                        }
                    }
                }
            }
            bmp.RotateFlip(RotateFlipType.Rotate90FlipXY);
            return bmp;
        }

        /// <summary>
        /// 生成全角横体文字图片
        /// </summary>
        /// <param name="Info">信息</param>
        /// <param name="bmpArg">位图参数</param>
        /// <param name="font">字体</param>
        /// <param name="fontColor">字体颜色</param>
        /// <returns>图片</returns>
        public static Bitmap SBCHorizontalBitmap(string Info, Params.BitmapArg bmpArg, Font font, Color fontColor)
        {
            Bitmap bmp = new Bitmap(bmpArg.BackWidth, bmpArg.BackHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                for (int i = 0; i < Info.Length; i++)
                {
                    if (i > 3)
                    {
                        fontColor = Color.Red;
                    }
                    string str = Info[i].ToString();
                    Bitmap smallBitmap = new Bitmap(bmpArg.FontWidth, bmpArg.FontHeight);
                    using (Graphics smallGraphics = Graphics.FromImage(smallBitmap))
                    {
                        smallGraphics.Clear(Color.White);
                        using (Font tFont = new Font(font, FontStyle.Regular))
                        {
                            using (Brush brush = new SolidBrush(fontColor))
                            {
                                int x = Encod.Regular.IsChineseCharacter(str) ? -1 : Encod.Regular.IsNotChineseCharacter(str) ? 1 : -1;
                                smallGraphics.DrawString(str, tFont, brush, x, 1);
                            }
                        }
                    }
                    graphics.DrawImage(smallBitmap, i * bmpArg.FontWidth, 0);
                }
            }
            return bmp;
        }

        /// <summary>
        /// 生成全角竖体文字图片
        /// </summary>
        /// <param name="Info">信息</param>
        /// <param name="bmpArg">位图参数</param>
        /// <param name="font">字体</param>
        /// <param name="fontColor">字体颜色</param>
        /// <returns>图片</returns>
        public static Bitmap SBCVerticalBitmap(string Info, Params.BitmapArg bmpArg, Font font, Color fontColor)
        {
            Bitmap bmp = new Bitmap(bmpArg.BackWidth, bmpArg.BackHeight);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                for (int i = 0; i < Info.Length; i++)
                {
                    if (i > 2)
                    {
                        fontColor = Color.Blue;
                    }
                    string str = Info[i].ToString();
                    Bitmap smallBitmap = new Bitmap(bmpArg.FontWidth, bmpArg.FontHeight);
                    using (Graphics smallGraphics = Graphics.FromImage(smallBitmap))
                    {
                        smallGraphics.Clear(Color.White);
                        using (Font tFont = new Font(font, FontStyle.Regular))
                        {
                            using (Brush brush = new SolidBrush(fontColor))
                            {
                                int x = Encod.Regular.IsChineseCharacter(str) ? -1 : Encod.Regular.IsNotChineseCharacter(str) ? 1 : -1;
                                smallGraphics.DrawString(str, tFont, brush, x-1, 0);
                            }
                        }
                    }
                    if ((str != "（") && (str != "）") && (str != "(") && (str != ")"))//neil
                        smallBitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    graphics.DrawImage(smallBitmap, i * bmpArg.FontWidth, 0);
                    

                }
                Bitmap numBitmap = NumberVerticalBitmap("147", fontColor);
                numBitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                //numBitmap.Save("testNum.bmp");
                graphics.DrawImage(numBitmap, 73, 0);
            }
            //bmp.Save("test2.bmp");
            return bmp;
        }
        public static Bitmap GetLedBmpNB(string productNameFirst, string productNameSecond, string qty, Color fontColor)
        {
            Bitmap bmp = new Bitmap(80, 16);
            Font font = new Font("宋体", 9F);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                int iFirst = productNameFirst.Length;
                if (iFirst > 3)
                {
                    iFirst = 3;
                    productNameFirst = productNameFirst.Substring(0, 3);
                }
                int iSecond = productNameSecond.Length;
                if (iSecond < 3)
                {
                    iFirst = 3;
                }
                if (iSecond > 6-iFirst)
                {
                    iSecond = 6 - iFirst;
                    productNameSecond = productNameSecond.Substring(0, iSecond);
                }
                
                Bitmap firstBmp = GetWordBmp(productNameFirst, font, fontColor);
                Bitmap secondBmp =GetWordBmp(productNameSecond,font,Color.Blue);                 
                Bitmap numBitmap = NumberVerticalBitmap(qty, fontColor);
                graphics.DrawImage(firstBmp, 0, 0);
                graphics.DrawImage(secondBmp, iFirst * 12,0);
                graphics.DrawImage(numBitmap, 73, 0);
            }            
            return bmp;
        }
        public static Bitmap GetWordBmp(string strMsg, Font font, Color fontColor)
        {
            Bitmap bmp = new Bitmap(12 * strMsg.Length, 12);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                for (int i = 0; i < strMsg.Length; i++)
                {
                    string str = strMsg[i].ToString();
                    Bitmap smallBitmap = new Bitmap(12, 12);
                    using (Graphics smallGraphics = Graphics.FromImage(smallBitmap))
                    {
                        smallGraphics.Clear(Color.White);
                        using (Font tFont = new Font(font, FontStyle.Regular))
                        {
                            using (Brush brush = new SolidBrush(fontColor))
                            {
                                int x = Encod.Regular.IsChineseCharacter(str) ? -1 : Encod.Regular.IsNotChineseCharacter(str) ? 1 : -1;
                                smallGraphics.DrawString(str, tFont, brush, x - 1, 0);
                            }
                        }
                    }                     
                    smallBitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    graphics.DrawImage(smallBitmap, i * 12, 0);
                }
            }
            return bmp;
        }
        public static Bitmap NumberVerticalBitmap(string strNum, Color fontColor)
        {
            Bitmap bmp = new Bitmap(16, 16);
            Graphics graphics = Graphics.FromImage(bmp);
            for (int i = 0; i < strNum.Length; i++)
            {
                Bitmap singleBmp = GetNumberBitmap(Convert.ToInt32(strNum.Substring(i,1)), fontColor);
                //singleBmp.RotateFlip(RotateFlipType.Rotate90FlipXY);
                graphics.DrawImage(singleBmp, i * 5, 0);
            }            
            bmp.RotateFlip(RotateFlipType.Rotate90FlipXY);
            return bmp;
        }
        public static Bitmap bitmapLedNumber = null;
        public static Bitmap GetNumberBitmap(int num, Color fontColor)
        {
            if (bitmapLedNumber == null)
            {
                bitmapLedNumber = (Bitmap)Bitmap.FromFile("LED数字.bmp");
            }
            int y = 0;
            if (fontColor == Color.Blue)
            {
                y = 6;
            }
            Rectangle rect = new Rectangle(num * 5, y, 5, 5);
            Bitmap bit= bitmapLedNumber.Clone(rect, bitmapLedNumber.PixelFormat);
            bit.Save("test.bmp");
            return bit;
        }
    }
}
