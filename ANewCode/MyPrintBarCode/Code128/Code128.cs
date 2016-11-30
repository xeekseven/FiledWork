using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace Code128
{
    public class Code128
    {
        #region 变量
        private DataTable dtCode128 = new DataTable();  //128码数据集   
        private uint _height = 40;                      //高度
        private Font _codeValueFont = null;             //是否显示可见号码  如果为NULL不显示号码
        private byte _magnify = 0;                      //放大倍数
        #endregion

        #region 属性
        #region Height
        /// <summary>           
        /// 高度            
        /// </summary>           
        public uint Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }
        #endregion

        #region ValueFont
        /// <summary>            
        /// 是否显示可见号码  如果为NULL不显示号码            
        /// </summary>            
        public Font ValueFont
        {
            get
            {
                return this._codeValueFont;
            }
            set
            {
                this._codeValueFont = value;
            }
        }
        #endregion

        #region Magnify
        /// <summary>            
        /// 放大倍数            
        /// </summary>            
        public byte Magnify
        {
            get
            {
                return this._magnify;
            }
            set
            {
                this._magnify = value;
            }
        }
        #endregion
        #endregion

        #region 枚举
        #region Encode
        /// <summary>            
        /// 条码类别            
        /// </summary>            
        public enum Encode
        {
            Code128A,
            Code128B,
            Code128C,
            EAN128
        }
        #endregion
        #endregion

        #region 方法
        #region Code128
        /// <summary>
        /// 128码数据
        /// </summary>
        public Code128()
        {
            dtCode128.Columns.Add("ID");
            dtCode128.Columns.Add("Code128A");
            dtCode128.Columns.Add("Code128B");
            dtCode128.Columns.Add("Code128C");
            dtCode128.Columns.Add("BandCode");
            dtCode128.CaseSensitive = true;

            #region 数据表
            dtCode128.Rows.Add("0", " ", " ", "00", "212222");
            dtCode128.Rows.Add("1", "!", "!", "01", "222122");
            dtCode128.Rows.Add("2", "\"", "\"", "02", "222221");
            dtCode128.Rows.Add("3", "#", "#", "03", "121223");
            dtCode128.Rows.Add("4", "$", "$", "04", "121322");
            dtCode128.Rows.Add("5", "%", "%", "05", "131222");
            dtCode128.Rows.Add("6", "&", "&", "06", "122213");
            dtCode128.Rows.Add("7", "'", "'", "07", "122312");
            dtCode128.Rows.Add("8", "(", "(", "08", "132212");
            dtCode128.Rows.Add("9", ")", ")", "09", "221213");
            dtCode128.Rows.Add("10", "*", "*", "10", "221312");
            dtCode128.Rows.Add("11", "+", "+", "11", "231212");
            dtCode128.Rows.Add("12", ",", ",", "12", "112232");
            dtCode128.Rows.Add("13", "-", "-", "13", "122132");
            dtCode128.Rows.Add("14", ".", ".", "14", "122231");
            dtCode128.Rows.Add("15", "/", "/", "15", "113222");
            dtCode128.Rows.Add("16", "0", "0", "16", "123122");
            dtCode128.Rows.Add("17", "1", "1", "17", "123221");
            dtCode128.Rows.Add("18", "2", "2", "18", "223211");
            dtCode128.Rows.Add("19", "3", "3", "19", "221132");
            dtCode128.Rows.Add("20", "4", "4", "20", "221231");
            dtCode128.Rows.Add("21", "5", "5", "21", "213212");
            dtCode128.Rows.Add("22", "6", "6", "22", "223112");
            dtCode128.Rows.Add("23", "7", "7", "23", "312131");
            dtCode128.Rows.Add("24", "8", "8", "24", "311222");
            dtCode128.Rows.Add("25", "9", "9", "25", "321122");
            dtCode128.Rows.Add("26", ":", ":", "26", "321221");
            dtCode128.Rows.Add("27", ";", ";", "27", "312212");
            dtCode128.Rows.Add("28", "<", "<", "28", "322112");
            dtCode128.Rows.Add("29", "=", "=", "29", "322211");
            dtCode128.Rows.Add("30", ">", ">", "30", "212123");
            dtCode128.Rows.Add("31", "?", "?", "31", "212321");
            dtCode128.Rows.Add("32", "@", "@", "32", "232121");
            dtCode128.Rows.Add("33", "A", "A", "33", "111323");
            dtCode128.Rows.Add("34", "B", "B", "34", "131123");
            dtCode128.Rows.Add("35", "C", "C", "35", "131321");
            dtCode128.Rows.Add("36", "D", "D", "36", "112313");
            dtCode128.Rows.Add("37", "E", "E", "37", "132113");
            dtCode128.Rows.Add("38", "F", "F", "38", "132311");
            dtCode128.Rows.Add("39", "G", "G", "39", "211313");
            dtCode128.Rows.Add("40", "H", "H", "40", "231113");
            dtCode128.Rows.Add("41", "I", "I", "41", "231311");
            dtCode128.Rows.Add("42", "J", "J", "42", "112133");
            dtCode128.Rows.Add("43", "K", "K", "43", "112331");
            dtCode128.Rows.Add("44", "L", "L", "44", "132131");
            dtCode128.Rows.Add("45", "M", "M", "45", "113123");
            dtCode128.Rows.Add("46", "N", "N", "46", "113321");
            dtCode128.Rows.Add("47", "O", "O", "47", "133121");
            dtCode128.Rows.Add("48", "P", "P", "48", "313121");
            dtCode128.Rows.Add("49", "Q", "Q", "49", "211331");
            dtCode128.Rows.Add("50", "R", "R", "50", "231131");
            dtCode128.Rows.Add("51", "S", "S", "51", "213113");
            dtCode128.Rows.Add("52", "T", "T", "52", "213311");
            dtCode128.Rows.Add("53", "U", "U", "53", "213131");
            dtCode128.Rows.Add("54", "V", "V", "54", "311123");
            dtCode128.Rows.Add("55", "W", "W", "55", "311321");
            dtCode128.Rows.Add("56", "X", "X", "56", "331121");
            dtCode128.Rows.Add("57", "Y", "Y", "57", "312113");
            dtCode128.Rows.Add("58", "Z", "Z", "58", "312311");
            dtCode128.Rows.Add("59", "[", "[", "59", "332111");
            dtCode128.Rows.Add("60", "\\", "\\", "60", "314111");
            dtCode128.Rows.Add("61", "]", "]", "61", "221411");
            dtCode128.Rows.Add("62", "^", "^", "62", "431111");
            dtCode128.Rows.Add("63", "_", "_", "63", "111224");
            dtCode128.Rows.Add("64", "NUL", "`", "64", "111422");
            dtCode128.Rows.Add("65", "SOH", "a", "65", "121124");
            dtCode128.Rows.Add("66", "STX", "b", "66", "121421");
            dtCode128.Rows.Add("67", "ETX", "c", "67", "141122");
            dtCode128.Rows.Add("68", "EOT", "d", "68", "141221");
            dtCode128.Rows.Add("69", "ENQ", "e", "69", "112214");
            dtCode128.Rows.Add("70", "ACK", "f", "70", "112412");
            dtCode128.Rows.Add("71", "BEL", "g", "71", "122114");
            dtCode128.Rows.Add("72", "BS", "h", "72", "122411");
            dtCode128.Rows.Add("73", "HT", "i", "73", "142112");
            dtCode128.Rows.Add("74", "LF", "j", "74", "142211");
            dtCode128.Rows.Add("75", "VT", "k", "75", "241211");
            dtCode128.Rows.Add("76", "FF", "I", "76", "221114");
            dtCode128.Rows.Add("77", "CR", "m", "77", "413111");
            dtCode128.Rows.Add("78", "SO", "n", "78", "241112");
            dtCode128.Rows.Add("79", "SI", "o", "79", "134111");
            dtCode128.Rows.Add("80", "DLE", "p", "80", "111242");
            dtCode128.Rows.Add("81", "DC1", "q", "81", "121142");
            dtCode128.Rows.Add("82", "DC2", "r", "82", "121241");
            dtCode128.Rows.Add("83", "DC3", "s", "83", "114212");
            dtCode128.Rows.Add("84", "DC4", "t", "84", "124112");
            dtCode128.Rows.Add("85", "NAK", "u", "85", "124211");
            dtCode128.Rows.Add("86", "SYN", "v", "86", "411212");
            dtCode128.Rows.Add("87", "ETB", "w", "87", "421112");
            dtCode128.Rows.Add("88", "CAN", "x", "88", "421211");
            dtCode128.Rows.Add("89", "EM", "y", "89", "212141");
            dtCode128.Rows.Add("90", "SUB", "z", "90", "214121");
            dtCode128.Rows.Add("91", "ESC", "{", "91", "412121");
            dtCode128.Rows.Add("92", "FS", "|", "92", "111143");
            dtCode128.Rows.Add("93", "GS", "}", "93", "111341");
            dtCode128.Rows.Add("94", "RS", "~", "94", "131141");
            dtCode128.Rows.Add("95", "US", "DEL", "95", "114113");
            dtCode128.Rows.Add("96", "FNC3", "FNC3", "96", "114311");
            dtCode128.Rows.Add("97", "FNC2", "FNC2", "97", "411113");
            dtCode128.Rows.Add("98", "SHIFT", "SHIFT", "98", "411311");
            dtCode128.Rows.Add("99", "CODEC", "CODEC", "99", "113141");
            dtCode128.Rows.Add("100", "CODEB", "FNC4", "CODEB", "114131");
            dtCode128.Rows.Add("101", "FNC4", "CODEA", "CODEA", "311141");
            dtCode128.Rows.Add("102", "FNC1", "FNC1", "FNC1", "411131");
            dtCode128.Rows.Add("103", "StartA", "StartA", "StartA", "211412");
            dtCode128.Rows.Add("104", "StartB", "StartB", "StartB", "211214");
            dtCode128.Rows.Add("105", "StartC", "StartC", "StartC", "211232");
            dtCode128.Rows.Add("106", "Stop", "Stop", "Stop", "2331112");
            #endregion
        }
        #endregion

        #region GetCodeImage
        /// <summary>           
        /// 获取128图形            
        /// </summary>            
        /// <param name="barCode">条码</param>           
        /// <param name="codeType">条码类型</param>                  
        /// <returns>图形</returns>            
        public Bitmap GetCodeImage(string barCode, Encode codeType)
        {
            string viewBarCode = barCode;
            string text = "";
            IList<int> textNumb = new List<int>();
            int examine = 0;  //首位            
            switch (codeType)
            {
                case Encode.Code128C:
                    examine = 105;
                    if (!((barCode.Length & 1) == 0)) throw new Exception("128C长度必须是偶数");
                    while (barCode.Length != 0)
                    {
                        int temp = 0;
                        try
                        {
                            int codeNumb128 = Int32.Parse(barCode.Substring(0, 2));
                        }
                        catch
                        {
                            throw new Exception("128C必须是数字！");
                        }

                        text += GetValue(codeType, barCode.Substring(0, 2), ref temp);
                        textNumb.Add(temp);
                        barCode = barCode.Remove(0, 2);
                    }
                    break;
                case Encode.EAN128:
                    examine = 105;
                    if (!((barCode.Length & 1) == 0)) throw new Exception("EAN128长度必须是偶数");
                    textNumb.Add(102);
                    text += "411131";
                    while (barCode.Length != 0)
                    {
                        int temp = 0;
                        try
                        {
                            int codeNumb128 = Int32.Parse(barCode.Substring(0, 2));
                        }
                        catch
                        {
                            throw new Exception("128C必须是数字！");
                        }
                        text += GetValue(Encode.Code128C, barCode.Substring(0, 2), ref temp);
                        textNumb.Add(temp);
                        barCode = barCode.Remove(0, 2);
                    }
                    break;
                default:
                    if (codeType == Encode.Code128A)
                    {
                        examine = 103;
                    }
                    else
                    {
                        examine = 104;
                    }
                    while (barCode.Length != 0)
                    {
                        int temp = 0;
                        string codeValueCode = GetValue(codeType, barCode.Substring(0, 1), ref temp);
                        if (codeValueCode.Length == 0) throw new Exception("无效的字符集!" + barCode.Substring(0, 1).ToString());
                        text += codeValueCode;
                        textNumb.Add(temp);
                        barCode = barCode.Remove(0, 1);
                    }
                    break;
            }

            if (textNumb.Count == 0)
            {
                throw new Exception("错误的编码,无数据");
            }
            text = text.Insert(0, GetValue(examine)); //获取开始位              
            for (int i = 0; i != textNumb.Count; i++)
            {
                examine += textNumb[i] * (i + 1);
            }
            examine = examine % 103;           //获得严效位              
            text += GetValue(examine);  //获取严效位            
            text += "2331112"; //结束位
            Bitmap codeImage = GetImage(text);
            GetViewText(codeImage, viewBarCode);
            return codeImage;
        }
        #endregion

        #region GetValue
        /// <summary>            
        /// 获取目标对应的数据            
        /// </summary>            
        /// <param name="codeType">条码类型</param>            
        /// <param name="codeValue">数值 A b  30</param>           
        /// <param name="codeID">返回编号</param>            
        /// <returns>编码</returns>            
        private string GetValue(Encode codeType, string codeValue, ref int codeID)
        {
            if (dtCode128 == null)
            {
                return "";
            }
            DataRow[] dr = dtCode128.Select(codeType.ToString() + "='" + codeValue + "'");
            if (dr.Length != 1)
            {
                throw new Exception("错误的编码" + codeValue.ToString());
            }
            codeID = Int32.Parse(dr[0]["ID"].ToString());
            return dr[0]["BandCode"].ToString();
        }
        #endregion

        #region GetValue
        /// <summary>            
        /// 根据编号获得条纹            
        /// </summary>            
        /// <param name="codeTypeId"></param>            
        /// <returns></returns>            
        private string GetValue(int codeTypeId)
        {
            DataRow[] dr = dtCode128.Select("ID='" + codeTypeId.ToString() + "'");
            if (dr.Length != 1)
            {
                throw new Exception("验效位的编码错误" + codeTypeId.ToString());
            }
            return dr[0]["BandCode"].ToString();
        }
        #endregion

        #region GetImage
        /// <summary>            
        /// 获得条码图形            
        /// </summary>            
        /// <param name="barCode">文字</param>            
        /// <returns>图形</returns>            
        private Bitmap GetImage(string barCode)
        {
            char[] codeValue = barCode.ToCharArray();
            int width = 0;
            for (int i = 0; i != codeValue.Length; i++)
            {
                width += Int32.Parse(codeValue[i].ToString()) * (Magnify + 1);
            }
            Bitmap codeImage = new Bitmap(width, (int)Height);
            Graphics garphics = Graphics.FromImage(codeImage);

            int lenEx = 0;
            for (int i = 0; i != codeValue.Length; i++)
            {
                int codeValueNumb = Int32.Parse(codeValue[i].ToString()) * (Magnify + 1);  //获取宽和放大系数           
                if (!((i & 1) == 0))
                {
                    garphics.FillRectangle(Brushes.White, new Rectangle(lenEx, 0, codeValueNumb, (int)Height));
                }
                else
                {
                    garphics.FillRectangle(Brushes.Black, new Rectangle(lenEx, 0, codeValueNumb, (int)Height));
                }

                lenEx += codeValueNumb;
            }
            garphics.Dispose();
            return codeImage;
        }
        #endregion

        #region GetViewText
        /// <summary>            
        /// 显示可见条码文字 如果小于40 不显示文字            
        /// </summary>            
        /// <param name="bitmap">图形</param>                       
        private void GetViewText(Bitmap bitmap, string pviewBarCode)
        {
            if (pviewBarCode.Length > 40)
            {
                ValueFont = new Font("宋体", 10);
            }

            if (ValueFont == null)
            {
                return;
            }

            Graphics graphics = Graphics.FromImage(bitmap);
            SizeF drawSize = graphics.MeasureString(pviewBarCode, ValueFont);
            if (drawSize.Height > bitmap.Height - 10 || drawSize.Width > bitmap.Width)
            {
                graphics.Dispose();
                return;
            }
            int starY = bitmap.Height - (int)drawSize.Height;
            graphics.FillRectangle(Brushes.White, new Rectangle(0, starY, bitmap.Width, (int)drawSize.Height));
            graphics.DrawString(pviewBarCode, ValueFont, Brushes.Black, 0, starY);
        }
        #endregion
        #endregion
    }
}
