using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;

namespace PrintBarCode
{
    #region Code128 Class

    public class BandCode
    {
        /// <summary>
        /// Code128码
        /// </summary>
        public class Code128
        {

            private DataTable m_Code128 = new DataTable();
            private uint m_Height = 120;
            /// <summary>
            /// 高度
            /// </summary>
            public uint Height { get { return m_Height; } set { m_Height = value; } }
            private Font m_ValueFont = null;

            /// <summary>

            /// 是否显示可见号码  如果为NULL不显示号码

            /// </summary>

            private Font ValueFont { get { return m_ValueFont; } set { m_ValueFont = value; } }



            private byte m_Magnify = 2;

            /// <summary>

            /// 放大倍数

            /// </summary>

            public byte Magnify { get { return m_Magnify; } set { m_Magnify = value; } }

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



            public Code128()
            {

                m_Code128.Columns.Add("ID");

                m_Code128.Columns.Add("Code128A");

                m_Code128.Columns.Add("Code128B");

                m_Code128.Columns.Add("Code128C");

                m_Code128.Columns.Add("BandCode");



                m_Code128.CaseSensitive = true;





                #region 数据表

                string[] str_arr0 = { "0", " ", " ", "00", "212222" };

                string[] str_arr1 = { "1", "!", "!", "01", "222122" };

                string[] str_arr2 = { "2", "\"", "\"", "02", "222221" };

                string[] str_arr3 = { "3", "#", "#", "03", "121223" };

                string[] str_arr4 = { "4", "$", "$", "04", "121322" };

                string[] str_arr5 = { "5", "%", "%", "05", "131222" };

                string[] str_arr6 = { "6", "&", "&", "06", "122213" };

                string[] str_arr7 = { "7", "'", "'", "07", "122312" };

                string[] str_arr8 = { "8", "(", "(", "08", "132212" };

                string[] str_arr9 = { "9", ")", ")", "09", "221213" };

                string[] str_arr10 = { "10", "*", "*", "10", "221312" };

                string[] str_arr11 = { "11", "+", "+", "11", "231212" };

                string[] str_arr12 = { "12", ",", ",", "12", "112232" };

                string[] str_arr13 = { "13", "-", "-", "13", "122132" };

                string[] str_arr14 = { "14", ".", ".", "14", "122231" };

                string[] str_arr15 = { "15", "/", "/", "15", "113222" };

                string[] str_arr16 = { "16", "0", "0", "16", "123122" };

                string[] str_arr17 = { "17", "1", "1", "17", "123221" };

                string[] str_arr18 = { "18", "2", "2", "18", "223211" };

                string[] str_arr19 = { "19", "3", "3", "19", "221132" };

                string[] str_arr20 = { "20", "4", "4", "20", "221231" };

                string[] str_arr21 = { "21", "5", "5", "21", "213212" };

                string[] str_arr22 = { "22", "6", "6", "22", "223112" };

                string[] str_arr23 = { "23", "7", "7", "23", "312131" };

                string[] str_arr24 = { "24", "8", "8", "24", "311222" };

                string[] str_arr25 = { "25", "9", "9", "25", "321122" };

                string[] str_arr26 = { "26", ":", ":", "26", "321221" };

                string[] str_arr27 = { "27", ";", ";", "27", "312212" };

                string[] str_arr28 = { "28", "<", "<", "28", "322112" };

                string[] str_arr29 = { "29", "=", "=", "29", "322211" };

                string[] str_arr30 = { "30", ">", ">", "30", "212123" };

                string[] str_arr31 = { "31", "?", "?", "31", "212321" };

                string[] str_arr32 = { "32", "@", "@", "32", "232121" };

                string[] str_arr33 = { "33", "A", "A", "33", "111323" };

                string[] str_arr34 = { "34", "B", "B", "34", "131123" };

                string[] str_arr35 = { "35", "C", "C", "35", "131321" };

                string[] str_arr36 = { "36", "D", "D", "36", "112313" };

                string[] str_arr37 = { "37", "E", "E", "37", "132113" };

                string[] str_arr38 = { "38", "F", "F", "38", "132311" };

                string[] str_arr39 = { "39", "G", "G", "39", "211313" };

                string[] str_arr40 = { "40", "H", "H", "40", "231113" };

                string[] str_arr41 = { "41", "I", "I", "41", "231311" };

                string[] str_arr42 = { "42", "J", "J", "42", "112133" };

                string[] str_arr43 = { "43", "K", "K", "43", "112331" };

                string[] str_arr44 = { "44", "L", "L", "44", "132131" };

                string[] str_arr45 = { "45", "M", "M", "45", "113123" };

                string[] str_arr46 = { "46", "N", "N", "46", "113321" };

                string[] str_arr47 = { "47", "O", "O", "47", "133121" };

                string[] str_arr48 = { "48", "P", "P", "48", "313121" };

                string[] str_arr49 = { "49", "Q", "Q", "49", "211331" };

                string[] str_arr50 = { "50", "R", "R", "50", "231131" };

                string[] str_arr51 = { "51", "S", "S", "51", "213113" };

                string[] str_arr52 = { "52", "T", "T", "52", "213311" };

                string[] str_arr53 = { "53", "U", "U", "53", "213131" };

                string[] str_arr54 = { "54", "V", "V", "54", "311123" };

                string[] str_arr55 = { "55", "W", "W", "55", "311321" };

                string[] str_arr56 = { "56", "X", "X", "56", "331121" };

                string[] str_arr57 = { "57", "Y", "Y", "57", "312113" };

                string[] str_arr58 = { "58", "Z", "Z", "58", "312311" };

                string[] str_arr59 = { "59", "[", "[", "59", "332111" };

                string[] str_arr60 = { "60", "\\", "\\", "60", "314111" };

                string[] str_arr61 = { "61", "]", "]", "61", "221411" };

                string[] str_arr62 = { "62", "^", "^", "62", "431111" };

                string[] str_arr63 = { "63", "_", "_", "63", "111224" };

                string[] str_arr64 = { "64", "NUL", "`", "64", "111422" };

                string[] str_arr65 = { "65", "SOH", "a", "65", "121124" };

                string[] str_arr66 = { "66", "STX", "b", "66", "121421" };

                string[] str_arr67 = { "67", "ETX", "c", "67", "141122" };

                string[] str_arr68 = { "68", "EOT", "d", "68", "141221" };

                string[] str_arr69 = { "69", "ENQ", "e", "69", "112214" };

                string[] str_arr70 = { "70", "ACK", "f", "70", "112412" };

                string[] str_arr71 = { "71", "BEL", "g", "71", "122114" };

                string[] str_arr72 = { "72", "BS", "h", "72", "122411" };

                string[] str_arr73 = { "73", "HT", "i", "73", "142112" };

                string[] str_arr74 = { "74", "LF", "j", "74", "142211" };

                string[] str_arr75 = { "75", "VT", "k", "75", "241211" };

                string[] str_arr76 = { "76", "FF", "I", "76", "221114" };

                string[] str_arr77 = { "77", "CR", "m", "77", "413111" };

                string[] str_arr78 = { "78", "SO", "n", "78", "241112" };

                string[] str_arr79 = { "79", "SI", "o", "79", "134111" };

                string[] str_arr80 = { "80", "DLE", "p", "80", "111242" };

                string[] str_arr81 = { "81", "DC1", "q", "81", "121142" };

                string[] str_arr82 = { "82", "DC2", "r", "82", "121241" };

                string[] str_arr83 = { "83", "DC3", "s", "83", "114212" };

                string[] str_arr84 = { "84", "DC4", "t", "84", "124112" };

                string[] str_arr85 = { "85", "NAK", "u", "85", "124211" };

                string[] str_arr86 = { "86", "SYN", "v", "86", "411212" };

                string[] str_arr87 = { "87", "ETB", "w", "87", "421112" };

                string[] str_arr88 = { "88", "CAN", "x", "88", "421211" };

                string[] str_arr89 = { "89", "EM", "y", "89", "212141" };

                string[] str_arr90 = { "90", "SUB", "z", "90", "214121" };

                string[] str_arr91 = { "91", "ESC", "{", "91", "412121" };

                string[] str_arr92 = { "92", "FS", "|", "92", "111143" };

                string[] str_arr93 = { "93", "GS", "}", "93", "111341" };

                string[] str_arr94 = { "94", "RS", "~", "94", "131141" };

                string[] str_arr95 = { "95", "US", "DEL", "95", "114113" };

                string[] str_arr96 = { "96", "FNC3", "FNC3", "96", "114311" };

                string[] str_arr97 = { "97", "FNC2", "FNC2", "97", "411113" };

                string[] str_arr98 = { "98", "SHIFT", "SHIFT", "98", "411311" };

                string[] str_arr99 = { "99", "CODEC", "CODEC", "99", "113141" };

                string[] str_arr100 = { "100", "CODEB", "FNC4", "CODEB", "114131" };

                string[] str_arr101 = { "101", "FNC4", "CODEA", "CODEA", "311141" };

                string[] str_arr102 = { "102", "FNC1", "FNC1", "FNC1", "411131" };

                string[] str_arr103 = { "103", "StartA", "StartA", "StartA", "211412" };

                string[] str_arr104 = { "104", "StartB", "StartB", "StartB", "211214" };

                string[] str_arr105 = { "105", "StartC", "StartC", "StartC", "211232" };

                string[] str_arr106 = { "106", "Stop", "Stop", "Stop", "2331112" };
                m_Code128.Rows.Add(str_arr0);

                m_Code128.Rows.Add(str_arr1);

                m_Code128.Rows.Add(str_arr2);

                m_Code128.Rows.Add(str_arr3);

                m_Code128.Rows.Add(str_arr4);

                m_Code128.Rows.Add(str_arr5);

                m_Code128.Rows.Add(str_arr6);

                m_Code128.Rows.Add(str_arr7);

                m_Code128.Rows.Add(str_arr8);

                m_Code128.Rows.Add(str_arr9);

                m_Code128.Rows.Add(str_arr10);

                m_Code128.Rows.Add(str_arr11);

                m_Code128.Rows.Add(str_arr12);

                m_Code128.Rows.Add(str_arr13);

                m_Code128.Rows.Add(str_arr14);

                m_Code128.Rows.Add(str_arr15);

                m_Code128.Rows.Add(str_arr16);

                m_Code128.Rows.Add(str_arr17);

                m_Code128.Rows.Add(str_arr18);

                m_Code128.Rows.Add(str_arr19);

                m_Code128.Rows.Add(str_arr20);

                m_Code128.Rows.Add(str_arr21);

                m_Code128.Rows.Add(str_arr22);

                m_Code128.Rows.Add(str_arr23);

                m_Code128.Rows.Add(str_arr24);

                m_Code128.Rows.Add(str_arr25);

                m_Code128.Rows.Add(str_arr26);

                m_Code128.Rows.Add(str_arr27);

                m_Code128.Rows.Add(str_arr28);

                m_Code128.Rows.Add(str_arr29);

                m_Code128.Rows.Add(str_arr30);

                m_Code128.Rows.Add(str_arr31);

                m_Code128.Rows.Add(str_arr32);

                m_Code128.Rows.Add(str_arr33);

                m_Code128.Rows.Add(str_arr34);

                m_Code128.Rows.Add(str_arr35);

                m_Code128.Rows.Add(str_arr36);

                m_Code128.Rows.Add(str_arr37);

                m_Code128.Rows.Add(str_arr38);

                m_Code128.Rows.Add(str_arr39);

                m_Code128.Rows.Add(str_arr40);

                m_Code128.Rows.Add(str_arr41);

                m_Code128.Rows.Add(str_arr42);

                m_Code128.Rows.Add(str_arr43);

                m_Code128.Rows.Add(str_arr44);

                m_Code128.Rows.Add(str_arr45);

                m_Code128.Rows.Add(str_arr46);

                m_Code128.Rows.Add(str_arr47);

                m_Code128.Rows.Add(str_arr48);

                m_Code128.Rows.Add(str_arr49);

                m_Code128.Rows.Add(str_arr50);

                m_Code128.Rows.Add(str_arr51);

                m_Code128.Rows.Add(str_arr52);

                m_Code128.Rows.Add(str_arr53);

                m_Code128.Rows.Add(str_arr54);

                m_Code128.Rows.Add(str_arr55);

                m_Code128.Rows.Add(str_arr56);

                m_Code128.Rows.Add(str_arr57);

                m_Code128.Rows.Add(str_arr58);

                m_Code128.Rows.Add(str_arr59);

                m_Code128.Rows.Add(str_arr60);

                m_Code128.Rows.Add(str_arr61);

                m_Code128.Rows.Add(str_arr62);

                m_Code128.Rows.Add(str_arr63);

                m_Code128.Rows.Add(str_arr64);

                m_Code128.Rows.Add(str_arr65);

                m_Code128.Rows.Add(str_arr66);

                m_Code128.Rows.Add(str_arr67);

                m_Code128.Rows.Add(str_arr68);

                m_Code128.Rows.Add(str_arr69);

                m_Code128.Rows.Add(str_arr70);

                m_Code128.Rows.Add(str_arr71);

                m_Code128.Rows.Add(str_arr72);

                m_Code128.Rows.Add(str_arr73);

                m_Code128.Rows.Add(str_arr74);

                m_Code128.Rows.Add(str_arr75);

                m_Code128.Rows.Add(str_arr76);

                m_Code128.Rows.Add(str_arr77);

                m_Code128.Rows.Add(str_arr78);

                m_Code128.Rows.Add(str_arr79);

                m_Code128.Rows.Add(str_arr80);

                m_Code128.Rows.Add(str_arr81);

                m_Code128.Rows.Add(str_arr82);

                m_Code128.Rows.Add(str_arr83);

                m_Code128.Rows.Add(str_arr84);

                m_Code128.Rows.Add(str_arr85);

                m_Code128.Rows.Add(str_arr86);

                m_Code128.Rows.Add(str_arr87);

                m_Code128.Rows.Add(str_arr88);

                m_Code128.Rows.Add(str_arr89);

                m_Code128.Rows.Add(str_arr90);

                m_Code128.Rows.Add(str_arr91);

                m_Code128.Rows.Add(str_arr92);

                m_Code128.Rows.Add(str_arr93);

                m_Code128.Rows.Add(str_arr94);

                m_Code128.Rows.Add(str_arr95);

                m_Code128.Rows.Add(str_arr96);

                m_Code128.Rows.Add(str_arr97);

                m_Code128.Rows.Add(str_arr98);

                m_Code128.Rows.Add(str_arr99);

                m_Code128.Rows.Add(str_arr100);

                m_Code128.Rows.Add(str_arr101);

                m_Code128.Rows.Add(str_arr102);

                m_Code128.Rows.Add(str_arr103);

                m_Code128.Rows.Add(str_arr104);

                m_Code128.Rows.Add(str_arr105);

                m_Code128.Rows.Add(str_arr106);

                #endregion

            }
            /// <summary>

            /// 获取128图形

            /// </summary>

            /// <param name="p_Text">文字</param>

            /// <param name="p_Code">编码</param>      

            /// <returns>图形</returns>

            public Bitmap GetCodeImage(string p_Text, Encode p_Code)
            {

                string _ViewText = p_Text;

                string _Text = "";

                //IList<int> _TextNumb=new List<int>();

                ArrayList _TextNumb = new ArrayList();

                int _Examine = 0;  //首位

                switch (p_Code)
                {

                    case Encode.Code128C:

                        _Examine = 105;

                        if (!((p_Text.Length & 1) == 0)) throw new Exception("128C长度必须是偶数");

                        while (p_Text.Length != 0)
                        {

                            int _Temp = 0;

                            try
                            {

                                int _CodeNumb128 = Int32.Parse(p_Text.Substring(0, 2));

                            }

                            catch
                            {

                                throw new Exception("128C必须是数字！");

                            }

                            _Text += GetValue(p_Code, p_Text.Substring(0, 2), ref _Temp);

                            _TextNumb.Add(_Temp);

                            p_Text = p_Text.Remove(0, 2);

                        }

                        break;

                    case Encode.EAN128:

                        _Examine = 105;

                        if (!((p_Text.Length & 1) == 0)) throw new Exception("EAN128长度必须是偶数");

                        _TextNumb.Add(102);

                        _Text += "411131";

                        while (p_Text.Length != 0)
                        {

                            int _Temp = 0;

                            try
                            {

                                int _CodeNumb128 = Int32.Parse(p_Text.Substring(0, 2));

                            }

                            catch
                            {

                                throw new Exception("128C必须是数字！");

                            }

                            _Text += GetValue(Encode.Code128C, p_Text.Substring(0, 2), ref _Temp);

                            _TextNumb.Add(_Temp);

                            p_Text = p_Text.Remove(0, 2);

                        }

                        break;

                    default:

                        if (p_Code == Encode.Code128A)
                        {

                            _Examine = 103;

                        }

                        else
                        {

                            _Examine = 104;

                        }



                        while (p_Text.Length != 0)
                        {

                            int _Temp = 0;

                            string _ValueCode = GetValue(p_Code, p_Text.Substring(0, 1), ref _Temp);

                            if (_ValueCode.Length == 0) throw new Exception("无效的字符集!" + p_Text.Substring(0, 1).ToString());

                            _Text += _ValueCode;

                            _TextNumb.Add(_Temp);

                            p_Text = p_Text.Remove(0, 1);

                        }

                        break;

                }



                if (_TextNumb.Count == 0) throw new Exception("错误的编码,无数据");

                _Text = _Text.Insert(0, GetValue(_Examine)); //获取开始位



                for (int i = 0; i != _TextNumb.Count; i++)
                {

                    _Examine += Convert.ToInt32(_TextNumb[i].ToString()) * (i + 1);

                }

                _Examine = _Examine % 103;           //获得严效位

                _Text += GetValue(_Examine);  //获取严效位



                _Text += "2331112"; //结束位



                Bitmap _CodeImage = GetImage(_Text);

                GetViewText(_CodeImage, _ViewText);

                return _CodeImage;

            }



            /// <summary>

            /// 获取目标对应的数据

            /// </summary>

            /// <param name="p_Code">编码</param>

            /// <param name="p_Value">数值 A b  30</param>

            /// <param name="p_SetID">返回编号</param>

            /// <returns>编码</returns>

            private string GetValue(Encode p_Code, string p_Value, ref int p_SetID)
            {

                if (m_Code128 == null) return "";

                DataRow[] _Row = m_Code128.Select(p_Code.ToString() + "='" + p_Value + "'");

                if (_Row.Length != 1) throw new Exception("错误的编码" + p_Value.ToString());

                p_SetID = Int32.Parse(_Row[0]["ID"].ToString());

                return _Row[0]["BandCode"].ToString();

            }

            /// <summary>

            /// 根据编号获得条纹

            /// </summary>

            /// <param name="p_CodeId"></param>

            /// <returns></returns>

            private string GetValue(int p_CodeId)
            {

                DataRow[] _Row = m_Code128.Select("ID='" + p_CodeId.ToString() + "'");

                if (_Row.Length != 1) throw new Exception("验效位的编码错误" + p_CodeId.ToString());

                return _Row[0]["BandCode"].ToString();

            }



            /// <summary>

            /// 获得条码图形

            /// </summary>

            /// <param name="p_Text">文字</param>

            /// <returns>图形</returns>

            private Bitmap GetImage(string p_Text)
            {

                char[] _Value = p_Text.ToCharArray();

                int _Width = 0;

                for (int i = 0; i != _Value.Length; i++)
                {

                    //_Width += Int32.Parse(_Value[i].ToString()) * (m_Magnify + 1);
                    _Width += Int32.Parse(_Value[i].ToString()) * (m_Magnify);  //asdc
                }



                Bitmap _CodeImage = new Bitmap(_Width, (int)m_Height);

                Graphics _Garphics = Graphics.FromImage(_CodeImage);

                //Pen _Pen;

                int _LenEx = 0;

                for (int i = 0; i != _Value.Length; i++)
                {

                    //int _ValueNumb = Int32.Parse(_Value[i].ToString()) * (m_Magnify + 1);  //获取宽和放大系数

                    int _ValueNumb = Int32.Parse(_Value[i].ToString()) * (m_Magnify);  //获取宽和放大系数   //asdc


                    if (!((i & 1) == 0))
                    {

                        //_Pen = new Pen(Brushes.White, _ValueNumb);

                        _Garphics.FillRectangle(Brushes.White, new Rectangle(_LenEx, 0, _ValueNumb, (int)m_Height));

                    }

                    else
                    {

                        //_Pen = new Pen(Brushes.Black, _ValueNumb);

                        _Garphics.FillRectangle(Brushes.Black, new Rectangle(_LenEx, 0, _ValueNumb, (int)m_Height));

                    }

                    //_Garphics.(_Pen, new Point(_LenEx, 0), new Point(_LenEx, m_Height));

                    _LenEx += _ValueNumb;



                }

                _Garphics.Dispose();

                return _CodeImage;

            }

            /// <summary>

            /// 显示可见条码文字如果小于40 不显示文字

            /// </summary>

            /// <param name="p_Bitmap">图形</param>           

            private void GetViewText(Bitmap p_Bitmap, string p_ViewText)
            {

                if (m_ValueFont == null) return;



                Graphics _Graphics = Graphics.FromImage(p_Bitmap);

                SizeF _DrawSize = _Graphics.MeasureString(p_ViewText, m_ValueFont);

                if (_DrawSize.Height > p_Bitmap.Height - 10 || _DrawSize.Width > p_Bitmap.Width)
                {

                    _Graphics.Dispose();

                    return;

                }



                int _StarY = p_Bitmap.Height - (int)_DrawSize.Height;



                _Graphics.FillRectangle(Brushes.White, new Rectangle(0, _StarY, p_Bitmap.Width, (int)_DrawSize.Height));

                //_Graphics.DrawString(p_ViewText, m_ValueFont, Brushes.Black, Convert.ToInt32(p_Bitmap.Width/3), _StarY);



                _Graphics.FillRectangle(Brushes.White, new Rectangle(-10, p_Bitmap.Height + (int)_DrawSize.Height, 10, p_Bitmap.Height + (int)_DrawSize.Height));

                _Graphics.FillRectangle(Brushes.White, new Rectangle(-10, p_Bitmap.Height, p_Bitmap.Width, 5));

                _Graphics.FillRectangle(Brushes.White, new Rectangle(p_Bitmap.Width, p_Bitmap.Height + (int)_DrawSize.Height, 10, p_Bitmap.Height + (int)_DrawSize.Height));

            }





            //12345678

            //(105 + (1 * 12 + 2 * 34 + 3 * 56 + 4 *78)) % 103 = 47

            //结果为starc +12 +34 +56 +78 +47 +end

        }







    }

    #endregion

}
