using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore.Encod
{
    /// <summary>
    /// 全半角转换 
    /// </summary>
    internal static class SDEncod
    {
        /// <summary>
        /// 转全角的函数(SBC case) 
        /// 任意字符串->全角字符串
        /// 
        /// 全角空格为12288,半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288; continue;
                }

                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转半角的函数(DBC case) 
        /// 任意字符串->半角字符串
        /// 
        /// 全角空格为12288,半角空格为32
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32; continue;
                }

                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 获取字符串的字节数（数字，字母，标点符号，汉字）
        /// </summary>
        /// <param name="argValue">字符串</param>
        /// <returns>长度</returns>
        public static int GetStringByteLength(string argValue)
        {
            int iLength = 0;
            for (int i = 0; i < argValue.Length; i++)
            {
                char cValue = argValue[i];
                if ((cValue < 128) || ((cValue > 65376) && (cValue < 65440)))
                {
                    iLength++;
                }
                else
                {
                    iLength += 2;
                }
            }
            return iLength;
        }

        /// <summary>
        /// 获取字符索引
        /// </summary>
        /// <param name="argValue">字符串</param>
        /// <param name="iLen">长度</param>
        /// <returns>索引</returns>
        public static int GetCharIndex(string argValue, int iLen)
        {
            int i = 0;
            int iLength = 0;
            for (i = 0; i < argValue.Length; i++)
            {
                char cValue = argValue[i];
                if ((cValue < 128) || ((cValue > 65376) && (cValue < 65440)))
                {
                    iLength++;
                }
                else
                {
                    iLength += 2;
                }
                if (iLength == iLen)
                {
                    return i + 1;
                }
                if (iLength > iLen)
                {
                    return i;
                }
            }
            return i;
        }
    }
}
