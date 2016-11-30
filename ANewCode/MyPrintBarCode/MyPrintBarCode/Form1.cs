using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPrintBarCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox3.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请输入内容");

                }
                else
                {
                    string barCodeType = this.comboBox1.SelectedItem.ToString();
                    int height = Convert.ToInt32(this.textBox1.Text);
                    int width = Convert.ToInt32(this.textBox2.Text);
                    string barCode = this.textBox3.Text.Trim();
                    
                    PrintBarCode printBarCode = new PrintBarCode();
                    printBarCode.Print(barCodeType, height, width, barCode);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
