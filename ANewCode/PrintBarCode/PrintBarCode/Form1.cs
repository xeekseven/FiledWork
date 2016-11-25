using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintBarCode
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
                BandCode.Code128 _Code = new BandCode.Code128();
                _Code.Height = Convert.ToByte(100);
                _Code.Magnify = Convert.ToByte(2);
                BandCode.Code128.Encode encode = BandCode.Code128.Encode.Code128A;

                System.Drawing.Bitmap impTemp = _Code.GetCodeImage(this.textBox1.Text, encode);
                this.pictureBox1.Image = impTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
