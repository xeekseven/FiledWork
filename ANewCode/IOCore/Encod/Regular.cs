using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IOCore.Encod
{
    /// <summary>
    /// 正则表达式
    /// </summary>
    internal static class Regular
    {
        /// <summary>
        /// IP地址检验
        /// </summary>
        /// <param name="input">输入的ＩＰ</param>
        /// <returns>TRUE： 为IP地址/FALSE： 不为IP地址</returns>
        public static bool IsIP(string input)
        {
            return Regex.IsMatch(input, @"^(/d{1,2}|1/d/d|2[0-4]/d|25[0-5])/.(/d{1,2}|1/d/d|2[0-4]/d|25[0-5])/.(/d{1,2}|1/d/d|2[0-4]/d|25[0-5])/.(/d{1,2}|1/d/d|2[0-4]/d|25[0-5])$", RegexOptions.Compiled);
        }
        /// <summary>
        /// MAC地址检验
        /// </summary>
        /// <param name="input">输入的MAC</param>
        /// <returns>TRUE： 为MAC地址/FALSE： 不为MAC地址</returns>
        public static bool IsMAC(string input)
        {
            return Regex.IsMatch(input, @"^[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}-[0-9a-fA-F]{2}$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 大写字母检验
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回True:有匹配项/False:没有匹配项</returns>
        public static bool IsBigLetter(string input)
        {
            return Regex.IsMatch(input, "[A-Z]", RegexOptions.Compiled);
        }
        /// <summary>
        /// 小写字母检验
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回True:有匹配项/False:没有匹配项</returns>
        public static bool IsSmallLetter(string input)
        {
            return Regex.IsMatch(input, "[a-z]", RegexOptions.Compiled);
        }
        /// <summary>
        /// 数字检验
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回True:有匹配项/False:没有匹配项</returns>
        public static bool IsDigital(string input)
        {
            return Regex.IsMatch(input, "[0-9]", RegexOptions.Compiled);
        }
        /// <summary>
        /// 字符检验
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回True:有匹配项/False:没有匹配项</returns>
        public static bool IsCharacter(string input)
        {
            return Regex.IsMatch(input, "[\u0000-\u00FF]", RegexOptions.Compiled);
        }
        /// <summary>
        /// 汉字检验
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回True:有匹配项/False:没有匹配项</returns>
        public static bool IsChineseCharacter(string input)
        {
            return Regex.IsMatch(input, "^[\u4e00-\u9fa5]+$", RegexOptions.Compiled);
        }
        /// <summary>
        /// 判断输入的字符串中是否含有大写字母，小写字母，数字，字符检验
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回True:有匹配项/False:没有匹配项</returns>
        public static bool IsNotChineseCharacter(string input)
        {
            return Regex.IsMatch(input, "^[0-9a-zA-Z\u0000-\u00FF]*$", RegexOptions.Compiled);
        }

    }
}
