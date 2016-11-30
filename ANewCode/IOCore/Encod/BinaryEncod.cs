using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore.Encod
{
    /// <summary>
    /// 进制编码
    /// </summary>
    internal static class BinaryEncod
    {
        #region 2,8,10,16进制转化
        /// <summary>
        /// 2进制转10进制
        /// </summary>
        /// <param name="binDat">2进制数据流</param>
        /// <returns>10进制数据流</returns>
        public static long BinToDec(string binDat)
        {
            long intDat = Convert.ToInt64(binDat, 2);
            return intDat;
        }
        /// <summary>
        /// 10进制转2进制
        /// </summary>
        /// <param name="intDat">10进制数据流</param>
        /// <returns>2进制数据流</returns>
        public static string DecToBin(long intDat)
        {
            string binTmp = "";//转换为2进制的数据
            string strBin = Convert.ToString(intDat, 2);
            if (strBin.Length < 16)
            {
                binTmp = strBin.PadLeft(16, '0');//将转换的bin空位补0
            }
            else
            {
                binTmp = strBin.Substring(strBin.Length - 16); //超过16位则截取左边16位 
            }
            return binTmp;
        }
        /// <summary>
        /// 2进制数的按位取反运算
        /// </summary>
        /// <param name="binDat">2进制数据流</param>
        /// <param name="intBit">位索引</param>
        /// <returns>2进制数据流</returns>
        public static string BitNot(string binDat, short intBit)
        {
            string binTmp, binTmp1;
            short i;
            binTmp = binDat;
            i = Convert.ToInt16(Convert.ToInt16(16) - intBit);
            if (Convert.ToInt16(binDat.Substring(i, 1)) > 0)
            {
                binTmp = binTmp.Remove(i, 1);
                binTmp1 = binTmp.Insert(i, "0");
            }
            else
            {
                binTmp = binTmp.Remove(i, 1);
                binTmp1 = binTmp.Insert(i, "1");
            }
            return binTmp1;
        }
        /// <summary>
        /// 10进制转换成8进制
        /// </summary>
        /// <param name="intData">10进制数据流</param>
        /// <returns>8进制数据流</returns>
        public static string HexToOct(long intData)
        {
            string binTmp = Convert.ToString(intData, 8);//转换为8进制的数据
            return binTmp;
        }
        /// <summary>
        /// 8进制转换成10进制
        /// </summary>
        /// <param name="intData">8进制数据流</param>
        /// <returns>10进制数据流</returns>
        public static string OctToHex(long intData)
        {
            string binTmp = Convert.ToInt64(intData.ToString(), 8).ToString();//转换为10进制的数据
            return binTmp;
        }
        /// <summary>
        /// 10进制转换成16进制
        /// </summary>
        /// <param name="intData">10进制数据流</param>
        /// <returns>16进制数据流</returns>
        public static string DecToHex(long intData)
        {
            string binTmp = Convert.ToString(intData, 16);//转换为16进制的数据
            return binTmp;
        }
        /// <summary>
        /// 16进制转换成10进制
        /// </summary>
        /// <param name="intData">16进制数据流</param>
        /// <returns>10进制数据流</returns>
        public static string HexToDec(string intData)
        {
            string binTmp = Convert.ToInt64(intData, 16).ToString();//转换为10进制的数据
            return binTmp;
        }
        /// <summary>
        /// 8进制转换成16进制
        /// </summary>
        /// <param name="intData">8进制数据流</param>
        /// <returns>16进制数据流</returns>
        public static string OctToDec(string intData)
        {
            string strBin = Convert.ToInt64(intData, 8).ToString();
            string binTmp = DecToHex(Convert.ToInt64(strBin));//转换为16进制的数据
            return binTmp;
        }
        /// <summary>
        /// 16进制转换成8进制
        /// </summary>
        /// <param name="intData">16进制数据流</param>
        /// <returns>8进制数据流</returns>
        public static string DecToOct(string intData)
        {
            string strBin = Convert.ToInt64(intData, 16).ToString();
            string binTmp = HexToOct(Convert.ToInt64(strBin));//转换为8进制的数据
            return binTmp;
        }
        #endregion

    }
}
