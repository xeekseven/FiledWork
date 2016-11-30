using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IOCore.Params;
using IOCore.Command;
using IOCore.Encod;

namespace 双洋LED条屏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private IOCore.IOCommSend commSend = new IOCore.LedComm();
        private void open_Click(object sender, EventArgs e)
        {
            this.OpenPort();
        }
        private string Info
        {
            set
            {
                this.textBox3.Text +=string.Format("\r\n {0}",value);
            }
        }
        private void OpenPort()
        {
            commSend.CreateCom(string.Format("COM{0}",this.txtCom.Text),57600);
            commSend.EventLedData += new IOCore.LedDataReceived(commSend_EventLedData);
            //this.Info = "初始化成功";
            if (commSend.Open())
            {
                this.Info = "初始化成功";
            }
            else
            {
                this.Info = "初始化失败";
            }
        }
         void commSend_EventLedData(object sender, byte[] btData)
        {
            string retString = "";
            for (int i = 0; i < btData.Length; i++)
            {
                retString = string.Format("{0},{1}", retString, (char)btData[i]);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.commSend.Close();
        }

        private void send_Click(object sender, EventArgs e)
        {
            this.SendLed();
        }
        private IOCore.MoveAction getMoveAction(string sMoveAction)
        {
            IOCore.MoveAction move = IOCore.MoveAction.open;
            switch (sMoveAction)
            {
                case "随机":
                    move = IOCore.MoveAction.random;
                    break;
                case "立刻显示":
                    move = IOCore.MoveAction.imm;
                    break;
                case "左移":
                    move = IOCore.MoveAction.left;
                    break;
                case "右移":
                    move = IOCore.MoveAction.right;
                    break;
                case "上移":
                    move = IOCore.MoveAction.up;
                    break;
                case "下移":
                    move = IOCore.MoveAction.down;
                    break;
                case "从左向右展开":
                    move = IOCore.MoveAction.downS;
                    break;
                case "从上向下展开":
                    move = IOCore.MoveAction.rightPS;
                    break;
                case "从中间向2边展开":
                    move = IOCore.MoveAction.arabr;
                    break;
                case "水平百叶窗":
                    move = IOCore.MoveAction.horizontalb;
                    break;
                case "垂直百叶窗":
                    move = IOCore.MoveAction.stacked;
                    break;
                case "上下交叉对进":
                    move = IOCore.MoveAction.vertical;
                    break;
                case "左右交叉对展":
                    move = IOCore.MoveAction.together;
                    break;
                case "连续左移（走马灯）":
                    move = IOCore.MoveAction.open;
                    break;
                case "菱形扩散":
                    move = IOCore.MoveAction.udt;
                    break;
                case "斜向下移":
                    move = IOCore.MoveAction.downO;
                    break;
                case "斜向左展":
                    move = IOCore.MoveAction.level;
                    break;
                case "马赛克":
                    move = IOCore.MoveAction.staggeredud;
                    break;
                case "下雨":
                    move = IOCore.MoveAction.rain;
                    break;
            }
            return move;
        }
        /// <summary>
        /// 获取移动速度和级别
        /// </summary>
        /// <param name="sMoveSpeed">标签</param>
        /// <returns>移动速度和级别</returns>
        private IOCore.MoveSpeed getMoveSpeed(string sMoveSpeed)
        {
            IOCore.MoveSpeed move = IOCore.MoveSpeed.Speed05;
            switch (sMoveSpeed)
            {
                case "1级":
                    move = IOCore.MoveSpeed.Speed01;
                    break;
                case "2级":
                    move = IOCore.MoveSpeed.Speed02;
                    break;
                case "3级":
                    move = IOCore.MoveSpeed.Speed03;
                    break;
                case "4级":
                    move = IOCore.MoveSpeed.Speed04;
                    break;
                case "5级":
                    move = IOCore.MoveSpeed.Speed05;
                    break;
                case "6级":
                    move = IOCore.MoveSpeed.Speed06;
                    break;
                case "7级":
                    move = IOCore.MoveSpeed.Speed07;
                    break;
                case "8级":
                    move = IOCore.MoveSpeed.Speed08;
                    break;
                case "9级":
                    move = IOCore.MoveSpeed.Speed09;
                    break;
                case "10级":
                    move = IOCore.MoveSpeed.Speed10;
                    break;
                case "11级":
                    move = IOCore.MoveSpeed.Speed11;
                    break;
                case "12级":
                    move = IOCore.MoveSpeed.Speed12;
                    break;
            }
            return move;
        }
        /// <summary>
        /// 获取停留时间
        /// </summary>
        /// <param name="sMoveSpeed">标签</param>
        /// <returns>移动速度和级别</returns>
        private IOCore.StopTime getStopTime(string sStopTime)
        {
            IOCore.StopTime stopTime = IOCore.StopTime.Time00;
            switch (sStopTime)
            {
                case "不停留":
                    stopTime = IOCore.StopTime.Time00;
                    break;
                case "1秒":
                    stopTime = IOCore.StopTime.Time01;
                    break;
                case "2秒":
                    stopTime = IOCore.StopTime.Time02;
                    break;
                case "3秒":
                    stopTime = IOCore.StopTime.Time03;
                    break;
                case "4秒":
                    stopTime = IOCore.StopTime.Time04;
                    break;
                case "5秒":
                    stopTime = IOCore.StopTime.Time05;
                    break;
                case "6秒":
                    stopTime = IOCore.StopTime.Time06;
                    break;
                case "7秒":
                    stopTime = IOCore.StopTime.Time07;
                    break;
                case "8秒":
                    stopTime = IOCore.StopTime.Time08;
                    break;
                case "15秒":
                    stopTime = IOCore.StopTime.Time09;
                    break;
                case "30秒":
                    stopTime = IOCore.StopTime.Time11;
                    break;
                case "一直显示":
                    stopTime = IOCore.StopTime.Time17;
                    break;
            }
            return stopTime;
        }
        private void SendLed()
        {
            try
            {
                bool ret = false;
                ret = commSend.ClearPing(Convert.ToInt32(this.txtScn.Text));
                System.Threading.Thread.Sleep(150);
                if (ret)
                {
                    this.Info = "发送LED清屏指令成功";
                }
                else
                {
                    this.Info = "发送Led清屏失败"+commSend.ErrorInfo;
                }
                IOCore.Params.LedArg ledArg = new IOCore.Params.LedArg();
                ledArg.MoveActionArg = getMoveAction("立即显示");
                ledArg.MoveSpeedArg = getMoveSpeed("1秒");
                ledArg.StopTimeArg = getStopTime("一直显示");
                ledArg.StopWayArg = IOCore.StopWay.fa;
                ledArg.FontArg = new Font("宋体",9F);

                ledArg.FontColorArg = IOCore.FontColor.Green;
                ledArg.ContentTypeArg = IOCore.ContentType.Image;
                ledArg.BitmapArg = new IOCore.Params.BitmapArg(80, 16, 12, 12);

                ledArg.PartitionArg = IOCore.Partition.Part01;
                commSend.SetLedArg(ledArg);
                commSend.SetDelayTime = 150;
                //屏索引
                ret = commSend.SendPing(Convert.ToInt32(this.txtScn.Text), 3, this.textBox1.Text, 6, IOCore.DisplayType.SBCHorizontal);

                System.Threading.Thread.Sleep(150);
                commSend.OpenPing(Convert.ToInt32(this.txtScn.Text));
                this.Info = string.Format("发送条屏{0}，{1}", ret ? "成功" : "失败", commSend.ErrorInfo);

            }
            catch (Exception ex)
            {
                this.Info = string.Format("发送条屏错误:{0}",ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SendLedNB();
        }
        private void SendLedNB()
        {
            try
            {
                long tt = System.DateTime.Now.Ticks;
                bool ret = false;
                ret = commSend.ClearPing(Convert.ToInt32(this.txtScn.Text));
                System.Threading.Thread.Sleep(150);
                if (ret)
                {
                    this.Info = "发送LED清屏指令成功";
                }
                else
                {
                    this.Info = "发送LED清屏指令失败:{0}" + commSend.ErrorInfo;
                }
                //汉字参数
                IOCore.Params.LedArg ledArg = new IOCore.Params.LedArg();
                ledArg.MoveActionArg = getMoveAction("立刻显示");
                ledArg.MoveSpeedArg = getMoveSpeed("1秒");
                ledArg.StopTimeArg = getStopTime("一直显示");
                ledArg.StopWayArg = IOCore.StopWay.fa;
                ledArg.FontArg = new Font("宋体", 9F);

                ledArg.FontColorArg = IOCore.FontColor.Green;
                ledArg.ContentTypeArg = IOCore.ContentType.Image;
                ledArg.BitmapArg = new IOCore.Params.BitmapArg(80, 16, 12, 12);

                ledArg.PartitionArg = IOCore.Partition.Part01;//汉字分区
                commSend.SetLedArg(ledArg);
                commSend.SetDelayTime = 0;

                //屏索引：数字区是1开始，汉字区从3开始
                ret = commSend.SendPingNB(Convert.ToInt32(this.txtScn.Text),
                   this.textBox1.Text,
                   this.textBox2.Text,
                   "234");

                System.Threading.Thread.Sleep(150);
                commSend.OpenPing(Convert.ToInt32(this.txtScn.Text));
                this.Info = string.Format("发送条屏{0},{1}", ret ? "成功" : "失败", commSend.ErrorInfo);
                tt = System.DateTime.Now.Ticks - tt;
                tt = tt / 10000;
                this.Info = string.Format("耗时:{0}", tt);
            }
            catch (Exception ex)
            {
                this.Info = string.Format("发送条屏错误:{0}", ex.Message);
            }


            //try
            //{
            //    long tt = System.DateTime.Now.Ticks;
            //    bool ret = false;
            //    ret = commSend.ClearPing(Convert.ToInt32(this.txtCom.Text));
            //    System.Threading.Thread.Sleep(150);
            //    if (ret)
            //    {
            //        this.Info = "发送LED清屏指令成功";
            //    }
            //    else
            //    {
            //        this.Info = "发送LED清屏指令失败:{0}" + commSend.ErrorInfo;

            //    }

            //    IOCore.Params.LedArg ledArg = new IOCore.Params.LedArg();
            //    ledArg.MoveActionArg = getMoveAction("立即显示");
            //    ledArg.MoveSpeedArg = getMoveSpeed("1秒");
            //    ledArg.StopTimeArg = getStopTime("一直显示");
            //    ledArg.StopWayArg = IOCore.StopWay.fa;
            //    ledArg.FontArg = new Font("宋体", 9F);

            //    ledArg.FontColorArg = IOCore.FontColor.Green;
            //    ledArg.ContentTypeArg = IOCore.ContentType.Image;
            //    ledArg.BitmapArg = new IOCore.Params.BitmapArg(80, 16, 12, 12);

            //    ledArg.PartitionArg = IOCore.Partition.Part01;
            //    commSend.SetLedArg(ledArg);
            //    commSend.SetDelayTime = 0;
            //    ret = commSend.SendPingNB(Convert.ToInt32(this.txtScn.Text), this.textBox1.Text, this.textBox2.Text, "100");

            //    System.Threading.Thread.Sleep(150);

            //    this.Info = string.Format("\n发送条屏{0},{1}", ret ? "成功" : "失败", commSend.ErrorInfo);
            //    tt = System.DateTime.Now.Ticks - tt;
            //    tt = tt / 10000;
            //    this.Info = string.Format("耗时:{0}", tt);
            //}
            //catch (Exception e)
            //{
            //    this.Info = string.Format("\n发送条屏错误:{0}", e.Message);
            //}
        }
    }
}
