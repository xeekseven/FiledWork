using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPC
{
    public partial class Form1 : Form
    {
        private PLCCommunicate.PLCCommunicate plcCommunicate;
        public Form1()
        {
            InitializeComponent();
        }
        private string logInfo
        {
            set
            {
                this.txtlog.Text +=string.Format("{0},{1} \r\n",System.DateTime.Now.ToString("HH:MM:SS"),value) ;
            }
        }
        private bool Init(string fileName)
        {
            try
            {
                this.plcCommunicate = new PLCCommunicate.PLCCommunicate();
                this.plcCommunicate.EvntItemChange += new PLCCommunicate.ItemChange(plcCommunicate_EventItemChange);
                this.plcCommunicate.OnConnectStateChange += new PLCCommunicate.PLCConnectState(plcCommunicate_OnConnectStateChange);
                bool retPlcInit = false;
                retPlcInit = this.plcCommunicate.Init(fileName);

                if (retPlcInit)
                {
                    if (this.plcCommunicate.Start())
                    {
                        return true;
                    }
                    else
                    {
                        this.logInfo = "与PLC的连接不成功！原因：" + this.plcCommunicate.LastErrInfo;

                    }
                }
                else
                {
                    this.logInfo = "PLC连接配置文件有误：" + this.plcCommunicate.LastErrInfo;
                }
            }
            catch (Exception ex)
            {
                this.logInfo = "Plc配置错误,"+ex.Message;
                return false;
            }
            return true;
        }
        void plcCommunicate_OnConnectStateChange(bool state)
        {
            this.logInfo = string.Format("plc连接状态变化:{0}", state);
        }
        /// <summary>
        /// PLC数据改变事件
        /// </summary>
        /// <param name="ItemIndex">Item索引</param>
        /// <param name="ItemData">Item数据</param>
        public void plcCommunicate_EventItemChange(int[] ItemIndex, int[][] ItemData)
        {
            try
            {
                string[] itemNames = new string[ItemIndex.Length];
                for (int j = 0; j < ItemIndex.Length; j++)
                {
                    itemNames[j] = this.plcCommunicate.ItemNames[ItemIndex[j]];
                }
                for (int i = 0; i < itemNames.Length; i++)
                {
                    switch (itemNames[i])
                    {

                        case "TestItem1":
                            //配置文件里面配置了1个单元，返回的数组长度为1，所以下标只有0.
                            this.textBox1.Text = string.Format("{0}", ItemData[i][0]);
                            break;
                        case "TestItem2":
                            //配置文件里面配置了2个单元，返回的数组长度为2，所以下标最大为1.
                            this.textBox2.Text = string.Format("{0},{1}", ItemData[i][0], ItemData[i][1]);
                            break;
                        case "TestItem4":
                            //配置文件里面配置了4个单元，返回的数组长度为4，所以下标最大为3.
                            this.textBox4.Text = string.Format("{0},{1},{2},{3}", ItemData[i][0], ItemData[i][1], ItemData[i][2], ItemData[i][3]);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.logInfo = string.Format("opc事件处理错误:{0}", ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Init("plcTest.xml"))
            {
                this.logInfo = "plc初始化成功";
            }
            else
            {
                this.logInfo = "plc初始化失败";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string itemName = "TestItem1";
            int[] data = new int[1];
            data[0] = Convert.ToInt32(this.textBox14.Text);
            this.WriteItem(itemName, data);
        }
        private void WriteItem(string itemName, int[] itemData)
        {
            try
            {
                if (this.plcCommunicate.setItemDataS(itemName, itemData))
                {
                    this.logInfo = string.Format("写数据成功,{0}", itemName);

                }
                else
                {
                    this.logInfo = string.Format("写数据失败,项名{0},错误{1}", itemName, this.plcCommunicate.LastErrInfo);
                }
            }
            catch (Exception ex)
            {
                this.logInfo = string.Format("写数据失败,项名{0} 错误{1}", itemName, ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string itemName = "TestItem2";
            int[] data = new int[2];
            data[0] = Convert.ToInt32(this.textBox13.Text);
            data[1] = Convert.ToInt32(this.textBox12.Text);
            this.WriteItem(itemName, data);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string itemName = "TestItem4";
            int[] data = new int[4];
            data[0] = Convert.ToInt32(this.textBox11.Text);
            data[1] = Convert.ToInt32(this.textBox10.Text);
            data[2] = Convert.ToInt32(this.textBox9.Text);
            data[3] = Convert.ToInt32(this.textBox8.Text);
            this.WriteItem(itemName, data);
        }
    }
}
