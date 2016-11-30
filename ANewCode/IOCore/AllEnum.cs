using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCore
{
    #region -指令方式-
    /// <summary>
    /// 指令方式
    /// </summary>
    public enum CommAction
    {
        /// <summary>
        /// 发送信息(0x01为历史遗留指令，已经废除)
        /// </summary>
        Comm01 = 0x01,//发送信息
        /// <summary>
        /// 追加信息内容
        /// </summary>
        Comm02 = 0x02,//追加信息内容
        /// <summary>
        /// 发送信息
        /// </summary>
        Comm03 = 0x03,//发送信息
        /// <summary>
        /// 删除信息
        /// </summary>
        Comm05 = 0x05,//删除信息
        /// <summary>
        /// 清除所有信息
        /// </summary>
        Comm06 = 0x06,//清除所有信息
        /// <summary>
        /// 取消临时/报警信息
        /// </summary>
        Comm08 = 0x08,//取消临时/报警信息
        /// <summary>
        /// 设定按键报警信息内容
        /// </summary>
        Comm09 = 0x09,//设定按键报警信息内容
        /// <summary>
        /// 设置显示屏亮度
        /// </summary>
        Comm10 = 0x10,//设置显示屏亮度
        /// <summary>
        /// 设置显示屏定时调亮度
        /// </summary>
        Comm11 = 0x11,//设置显示屏定时调亮度
        /// <summary>
        /// 设置显示屏自动调亮度
        /// </summary>
        Comm12 = 0x12,//设置显示屏自动调亮度
        /// <summary>
        /// 读取亮度设置
        /// </summary>
        Comm13 = 0x13,//读取亮度设置
        /// <summary>
        /// 临时设置屏幕显示状态
        /// </summary>
        Comm19 = 0x19,//临时设置屏幕显示状态
        /// <summary>
        /// 设置屏幕显示状态
        /// </summary>
        Comm20 = 0x20,//设置屏幕显示状态
        /// <summary>
        /// 时间校正指令
        /// </summary>
        Comm21 = 0x21,//时间校正指令
        /// <summary>
        /// 时间查询
        /// </summary>
        Comm22 = 0x22,//时间查询
        /// <summary>
        /// 显示屏硬件设置
        /// </summary>
        Comm23 = 0x23,//显示屏硬件设置
        /// <summary>
        /// 读取硬件设置
        /// </summary>
        Comm24 = 0x24,//读取硬件设置
        /// <summary>
        /// 设置控制卡（显示屏）ID
        /// </summary>
        Comm25 = 0x25,//设置控制卡（显示屏）ID
        /// <summary>
        /// 设置控制卡自动开关机
        /// </summary>
        Comm26 = 0x26,//设置控制卡自动开关机 
        /// <summary>
        /// 读取屏幕开关机设定
        /// </summary>
        Comm27 = 0x27,//读取屏幕开关机设定 
        /// <summary>
        /// 设置默认波特率
        /// </summary>
        Comm28 = 0x28,//设置默认波特率 
        /// <summary>
        /// 设置分区信息
        /// </summary>
        Comm29 = 0x29,//设置分区信息 
        /// <summary>
        /// 测试指令
        /// </summary>
        Comm30 = 0x30,//测试指令 
        /// <summary>
        /// 校验和字段是否有效开关
        /// </summary>
        Comm31 = 0x31,//校验和字段是否有效开关 
        /// <summary>
        /// 控制卡重启
        /// </summary>
        Comm32 = 0x32,//控制卡重启 
        /// <summary>
        /// 参数复位
        /// </summary>
        Comm33 = 0x33,//参数复位 
        /// <summary>
        /// 获取控制卡固件版本
        /// </summary>
        Comm35 = 0x35,//获取控制卡固件版本
        /// <summary>
        /// 查询控制卡信息
        /// </summary>
        Comm40 = 0x40 //查询控制卡信息 
    }
    #endregion

    /// <summary>
    /// LED分区信息
    /// </summary>
    public class LedAreaInfo
    {
        public LedAreaInfo()
        {
        }
        /// <summary>
        /// 启用分区1
        /// </summary>
        public bool OpenArea1 = true;
        /// <summary>
        /// 启用分区2
        /// </summary>
        public bool OpenArea2 = false;
        /// <summary>
        /// 启用分区3
        /// </summary>
        public bool OpenArea3 = false;
        /// <summary>
        /// 启用分区4
        /// </summary>
        public bool OpenArea4 = false;
        /// <summary>
        /// 分区1左上角坐标x
        /// </summary>
        public byte Area1Left = 0;
        /// <summary>
        /// 分区1左上角坐标y
        /// </summary>
        public byte Area1Top = 0;
        /// <summary>
        /// 分区1宽（值为像素点除以8）
        /// </summary>
        public byte Area1Width = 16;
        /// <summary>
        /// 分区1高（值为像素点除以8）
        /// </summary>
        public byte Area1Height = 16;
        public byte Area2Left = 0;
        public byte Area2Top = 0;
        public byte Area2Width = 0;
        public byte Area2Height = 0;
        public byte Area3Left = 0;
        public byte Area3Top = 0;
        public byte Area3Width = 0;
        public byte Area3Height = 0;
        public byte Area4Left = 0;
        public byte Area4Top = 0;
        public byte Area4Width = 0;
        public byte Area4Height = 0;
        public byte[] GetByte()
        {
            byte[] areaByte = new byte[32];
            areaByte[0] = OpenArea1? (byte)1 : (byte)0;
            areaByte[1] = Area1Left;
            areaByte[2] = Area1Top;
            areaByte[3] = Area1Width;
            areaByte[4] = Area1Height;
            areaByte[5] = 0;
            areaByte[6] = 0;
            areaByte[7] = 0;
            areaByte[8] = OpenArea2 ? (byte)1 : (byte)0;
            areaByte[9] = Area1Left;
            areaByte[10] = Area1Top;
            areaByte[11] = Area1Width;
            areaByte[12] = Area1Height;
            areaByte[13] = 0;
            areaByte[14] = 0;
            areaByte[15] = 0;
            areaByte[16] = OpenArea3 ? (byte)1 : (byte)0;
            areaByte[17] = Area3Left;
            areaByte[18] = Area3Top;
            areaByte[19] = Area3Width;
            areaByte[20] = Area3Height;
            areaByte[21] = 0;
            areaByte[22] = 0;
            areaByte[23] = 0;
            areaByte[24] = OpenArea4 ? (byte)1 : (byte)0;
            areaByte[25] = Area4Left;
            areaByte[26] = Area4Top;
            areaByte[27] = Area4Width;
            areaByte[28] = Area4Height;
            areaByte[29] = 0;
            areaByte[30] = 0;
            areaByte[31] = 0;

            return areaByte;
        }

    }
    
    #region -动画方式-
    /// <summary>
    /// 动画方式
    /// </summary>
    public enum MoveAction
    {
        /// <summary>
        /// 随机
        /// </summary>
        random = 0x00,
        /// <summary>
        /// 立刻显示
        /// </summary>
        imm = 0x01, 
        /// <summary>
        /// 左移
        /// </summary>
        left = 0x02,
        /// <summary>
        /// 右移
        /// </summary>
        right = 0x03,
        /// <summary>
        /// 上移
        /// </summary>
        up = 0x04, 
        /// <summary>
        /// 下移
        /// </summary>
        down = 0x05, 
        /// <summary>
        /// 从左向右展开
        /// </summary>
        downS = 0x06,
        /// <summary>
        /// 从上向下展开
        /// </summary>
        rightPS = 0x07,
        /// <summary>
        /// 从中间向2边展开
        /// </summary>
        arabr = 0x08, 
        /// <summary>
        /// 水平百叶窗
        /// </summary>
        horizontalb = 0x09, 
        /// <summary>
        /// 垂直百叶窗
        /// </summary>
        stacked = 0x0A, 
        /// <summary>
        /// 上下交叉对进
        /// </summary>
        vertical = 0x0B, 
        /// <summary>
        /// 左右交叉对展
        /// </summary>
        together = 0x0C, 
        /// <summary>
        /// 连续左移（走马灯）
        /// </summary>
        open = 0x0D, 
        /// <summary>
        /// 菱形扩散
        /// </summary>
        udt = 0x0E, 
        /// <summary>
        /// 斜向下移
        /// </summary>
        downO = 0x0F, 
        /// <summary>
        /// 斜向左展
        /// </summary>
        level = 0x10,
        /// <summary>
        /// 马赛克
        /// </summary>
        staggeredud = 0x11,
        /// <summary>
        /// 下雨
        /// </summary>
        rain = 0x12 
    }
    #endregion

    #region -停留方式-
    /// <summary>
    /// 停留方式
    /// </summary>
    public enum StopWay
    {
        /// <summary>
        /// 无环绕闪烁
        /// </summary>
        fa = 0x00, //无环绕闪烁
        /// <summary>
        /// 红4点
        /// </summary>
        red4 = 0x10, //红4点
        /// <summary>
        /// 绿4点
        /// </summary>
        green4 = 0x20,//绿4点
        /// <summary>
        /// 黄4点
        /// </summary>
        yellow4 = 0x30,//黄4点
        /// <summary>
        /// 红1点
        /// </summary>
        red1 = 0x40,//红1点
        /// <summary>
        /// 绿1点
        /// </summary>
        Yellow1 = 0x50,//绿1点
        /// <summary>
        /// 黄1点
        /// </summary>
        green1 = 0x60, //黄1点
        /// <summary>
        /// 红单线闪烁
        /// </summary>
        redsingle = 0x70,//红单线闪烁
        /// <summary>
        /// 绿单线闪烁
        /// </summary>
        greensingle = 0x80,//绿单线闪烁
        /// <summary>
        /// 黄单线闪烁
        /// </summary>
        yellowsingle = 0x90,//黄单线闪烁
        /// <summary>
        /// 红单线环绕
        /// </summary>
        redsingleline = 0xA0,//红单线环绕
        /// <summary>
        /// 绿单线环绕
        /// </summary>
        greensingleline = 0xB0,//绿单线环绕
        /// <summary>
        /// 黄单线环绕
        /// </summary>
        yellowround = 0xC0,//黄单线环绕
        /// <summary>
        /// 红双线环绕
        /// </summary>
        redwiresurround = 0xD0,//红双线环绕
        /// <summary>
        /// 绿双线环绕
        /// </summary>
        greenwirearound = 0xE0,//绿双线环绕
        /// <summary>
        /// 黄双线环绕
        /// </summary>
        yellowwirearound = 0xF0//黄双线环绕
    }
    #endregion

    #region -移动速度和级别-
    /// <summary>
    /// 移动速度和级别
    /// </summary>
    public enum MoveSpeed
    {
        /// <summary>
        /// 1级(最慢)
        /// </summary>
        Speed01 = 0xF0,
        /// <summary>
        /// 2级
        /// </summary>
        Speed02 = 0xF7,
        /// <summary>
        /// 3级
        /// </summary>
        Speed03 = 0xFF,
        /// <summary>
        /// 4级
        /// </summary>
        Speed04 = 0xA0,
        /// <summary>
        /// 5级
        /// </summary>
        Speed05 = 0xA7,
        /// <summary>
        /// 6级
        /// </summary>
        Speed06 = 0xAF,
        /// <summary>
        /// 7级
        /// </summary>
        Speed07 = 0x40,
        /// <summary>
        /// 8级
        /// </summary>
        Speed08 = 0x47,
        /// <summary>
        /// 9级
        /// </summary>
        Speed09 = 0x4F,
        /// <summary>
        /// 10级
        /// </summary>
        Speed10 = 0x10,
        /// <summary>
        /// 11级
        /// </summary>
        Speed11 = 0x17,
        /// <summary>
        /// 12级(最快)
        /// </summary>
        Speed12 = 0x1F
    }
    #endregion

    #region -页面停留时间-
    /// <summary>
    /// 页面停留时间
    /// </summary>
    public enum StopTime
    {
        /// <summary>
        /// 不停留
        /// </summary>
        Time00 = 0x00,
        /// <summary>
        /// 1秒
        /// </summary>
        Time01 = 0x01,
        /// <summary>
        /// 2秒
        /// </summary>
        Time02 = 0x02,
        /// <summary>
        /// 3秒
        /// </summary>
        Time03 = 0x03,
        /// <summary>
        /// 4秒
        /// </summary>
        Time04 = 0x04,
        /// <summary>
        /// 5秒
        /// </summary>
        Time05 = 0x05,
        /// <summary>
        /// 6秒
        /// </summary>
        Time06 = 0x06,
        /// <summary>
        /// 7秒
        /// </summary>
        Time07 = 0x07,
        /// <summary>
        /// 8秒
        /// </summary>
        Time08 = 0x08,
        /// <summary>
        /// 15秒
        /// </summary>
        Time09 = 0x0F,
         /// <summary>
        /// 20秒
        /// </summary>
        Time10 = 0x14,
        /// <summary>
        /// 30秒
        /// </summary>
        Time11 = 0x1E,
        /// <summary>
        /// 71秒
        /// </summary>
        Time12 = 0x47,
        /// <summary>
        /// 79秒
        /// </summary>
        Time13 = 0x4F,
        /// <summary>
        /// 160秒
        /// </summary>
        Time14 = 0xA0,
        /// <summary>
        /// 167秒
        /// </summary>
        Time15 = 0xA7,
        /// <summary>
        /// 175秒
        /// </summary>
        Time16 = 0xAF,
        /// <summary>
        /// 一直显示
        /// </summary>
        Time17 = 0xFF
    }
    #endregion

    #region -内容类型-
    /// <summary>
    /// 内容类型
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// 纯文本(调用字库)
        /// </summary>
        Text = 0x00,
        /// <summary>
        /// 位图数据
        /// </summary>
        Image = 0x01
    }
    #endregion

    #region -颜色模式-
    /// <summary>
    /// 颜色模式
    /// </summary>
    public enum ColorType : int
    {
        /// <summary>
        /// 单色模式
        /// </summary>
        Single = 1,
        /// <summary>
        /// 双色模式
        /// </summary>
        Double = 2,
        /// <summary>
        /// 三色模式
        /// </summary>
        Three = 3
    }
    #endregion

    #region -文字颜色-
    /// <summary>
    /// 文字颜色
    /// </summary>
    public enum FontColor
    {
        /// <summary>
        /// 红色
        /// </summary>
        Red = 0x01,
        /// <summary>
        /// 绿色
        /// </summary>
        Green = 0x02,
         /// <summary>
        /// 蓝色(三色可用)
        /// </summary>
        Blue = 0x04
   }
    #endregion

    #region -显示类型-
    /// <summary>
    /// 显示类型
    /// </summary>
    public enum DisplayType : int
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// 全角横显
        /// </summary>
        SBCHorizontal = 1,
        /// <summary>
        /// 全角竖显
        /// </summary>
        SBCVertical = 2,
        /// <summary>
        /// 横显
        /// </summary>
        Horizontal = 3,
        /// <summary>
        /// 竖显
        /// </summary>
        Vertical = 4
    }
    #endregion

    #region -字符类型-
    /// <summary>
    /// 字符类型
    /// </summary>
    public enum CharType :int 
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// 全角
        /// </summary>
        SBC = 1,
        /// <summary>
        /// 半角
        /// </summary>
        DBC = 2
    }
    #endregion

    #region -分区号-
    /// <summary>
    /// 分区号
    /// </summary>
    public enum Partition
    {
        /// <summary>
        /// 第一块分区
        /// </summary>
        Part01 = 0x00,
        /// <summary>
        /// 第二块分区
        /// </summary>
        Part02 = 0x01,
        /// <summary>
        /// 第三块分区
        /// </summary>
        Part03 = 0x02,
        /// <summary>
        /// 第四块分区
        /// </summary>
        Part04 = 0x04
    }
    #endregion
}
