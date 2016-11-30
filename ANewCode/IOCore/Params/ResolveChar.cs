using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore.Params
{
    /// <summary>
    /// 处理字符串
    /// </summary>
    internal static class ResolveChar
    {
        /// <summary>
        /// 获取显式字符串
        /// </summary>
        /// <param name="input">待显示字符串</param>
        /// <param name="eCharType">全半角类型</param>
        /// <returns>字符串</returns>
        public static string GetChar(string input, CharType eCharType)
        {
            string rtChar = "";
            switch (eCharType)
            {
                case CharType.SBC:
                    rtChar = Encod.SDEncod.ToSBC(input);
                    break;
                case CharType.DBC:
                    rtChar = Encod.SDEncod.ToDBC(input);
                    break;
                case CharType.None:
                default:
                    rtChar = input;
                    break;
            }
            return rtChar;
        }

        /// <summary>
        /// 获取显式字符串数组
        /// </summary>
        /// <param name="input">待显示字符串</param>
        /// <param name="iLen">长度</param>
        /// <returns>数组</returns>
        public static string[] GetChars(string input, int iLen)
        {
            int tLen = Convert.ToInt32(Math.Ceiling((double)input.Length / (double)iLen));
            string[] rtChars = new string[tLen];
            for (int y = 0; y < rtChars.Length; y++)
            {
                for (int i = 0; i < input.Length; i += iLen)
                {
                    int count = input.Length - y * iLen > iLen ? iLen : input.Length - y * iLen;
                    rtChars[y] = input.Substring(y * iLen, count);
                }
            }
            return rtChars;
        }

        /// <summary>
        /// 获取显式指定长度字符串数组
        /// </summary>
        /// <param name="input">待显示字符串</param>
        /// <param name="iLen">长度</param>
        /// <returns>数组</returns>
        public static string[] GetUChars(string input, int iLen)
        {
            int uLen = Encod.SDEncod.GetStringByteLength(input);
            int tLen = Convert.ToInt32(Math.Ceiling((double)uLen / (double)iLen));
            string[] rtChars = new string[tLen];
            int index = 0;
            for (int y = 0; y < rtChars.Length; y++)
            {
                int startIndex = getLegth(rtChars, y - 1);
                index = Encod.SDEncod.GetCharIndex(input.Substring(startIndex), iLen);

                rtChars[y] = input.Substring(startIndex, index);
            }
            return rtChars;
        }
        /// <summary>
        /// 统计字符数
        /// </summary>
        /// <param name="rtChars">数组</param>
        /// <param name="index">不为空索引</param>
        /// <returns>字符数</returns>
        private static int getLegth(string[] rtChars, int index)
        {
            int tIndex = 0;
            for (int i = 0; index < rtChars.Length && i <= index; i++)
            {
                tIndex += rtChars[i].Length;
            }
            return tIndex;
        }
    }
}
