using System;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IOCore
{
    /// <summary>
    /// Led返回信息事件
    /// </summary>
    /// <param name="sender">对象</param>
    /// <param name="btData">返回信</param>
    public delegate void LedDataReceived(object sender, byte[] btData);
    /// <summary>
    /// 串口屏指令发送
    /// </summary>
    public interface IOCommSend
    {
        /// <summary>
        /// 建立串口对象
        /// </summary>
        /// <param name="portName">PortName,例如"COM1","COM2"等</param>
        /// <param name="baudRate">波特率,例如57600等</param>
        /// <returns>true:成功/false:失败</returns>
        bool CreateCom(string portName, int baudRate);
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        bool Open();
        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        bool Close();
        /// <summary>
        /// 设置LED参数
        /// </summary>
        /// <param name="ledArg">LED参数</param>
        bool SetLedArg(Params.LedArg ledArg);
        /// <summary>
        /// 开屏
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        bool OpenPing();
        /// <summary>
        /// 开屏
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        bool OpenPing(int iPingHao);
        /// <summary>
        /// 关屏
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        bool ClosePing();
        /// <summary>
        /// 关屏
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        bool ClosePing(int iPingHao);
        /// <summary>
        /// 清屏
        /// </summary>
        /// <returns>true:成功/false:失败</returns>
        bool ClearPing();
        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        bool ClearPing(int iPingHao);
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">信息序号</param>
        /// <param name="sMsg">信息</param>
        /// <param name="iCount">一屏显示的字数</param>
        /// <param name="eCharType">字符类型</param>
        /// <param name="eDisplayType">显示方式</param>
        /// <returns>true:成功/false:失败</returns>
        bool SendPing(int iPingHao, int iPingIndex, string sMsg, int iCount, CharType eCharType, DisplayType eDisplayType);
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">信息序号</param>
        /// <param name="sMsg">信息</param>
        /// <param name="iCount">一屏显示的字数</param>
        /// <param name="eDisplayType">显示方式</param>
        /// <returns>true:成功/false:失败</returns>
        bool SendPing(int iPingHao, int iPingIndex, string sMsg, int iCount, DisplayType eDisplayType);
        /// <summary>
        /// 宁波条屏发送
        /// 开始3个字显示品牌名，接下来3个字显示规格，最后显示数量，品牌与规格显示颜色不一样。        /// 
        /// </summary>
        /// <param name="iPingHao">屏号</param>
        /// <param name="productNameFirst">名称第一部分，品牌</param>
        /// <param name="productNameSecond">名称第二部分，规格</param>
        /// <param name="Qty"></param>
        /// <returns></returns>
        bool SendPingNB(int iPingHao, string productNameFirst, string productNameSecond, string Qty);
        /// <summary>
        /// 发送常规文本信息
        /// </summary>
        /// <param name="ledNo">屏号</param>
        /// <param name="msg">文本信息内容</param>
        /// <param name="fontColor">文字颜色</param>
        /// <returns></returns>
        bool SendMsg(int ledNo, string msg, Color fontColor);
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iPingIndex">信息序号</param>
        /// <param name="sMsg">信息</param>
        /// <param name="iCount">一屏显示的字数</param>
        /// <returns>true:成功/false:失败</returns>
        bool SendPing(int iPingHao, int iPingIndex, string sMsg, int iCount);
        /// <summary>
        /// 设置控制卡（显示屏）ID
        /// </summary>
        /// <param name="iPingHao">条屏号</param>
        /// <param name="iNewPingHao">新条屏号</param>
        /// <returns>true:成功/false:失败</returns>
        bool SetPingHao(int iPingHao, int iNewPingHao);
        /// <summary>
        /// 设置LED分区信息
        /// </summary>
        /// <param name="iPingHao"></param>
        /// <param name="ledAreaInfo"></param>
        /// <returns></returns>
        bool SetLedArea(int iPingHao, LedAreaInfo ledAreaInfo);
        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrorInfo { get; }
        /// <summary>
        /// 屏幕数
        /// </summary>
        int PingNum { get; }
        /// <summary>
        /// 发屏用时（毫秒）
        /// </summary>
        int UsedTime { get; }
        /// <summary>
        /// 设置发屏时差（毫秒）
        /// </summary>
        int SetDelayTime { set; }
        /// <summary>
        /// Led返回信息事件
        /// </summary>
        event LedDataReceived EventLedData;
    }
}
