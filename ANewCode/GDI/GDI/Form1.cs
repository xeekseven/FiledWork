using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Graphics g = this.CreateGraphics();
            g.DrawEllipse(Pens.Black, 50, 50, 50, 50);
            //g.Dispose();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawEllipse(Pens.Black, 50, 50, 50, 50);
            g.Dispose();
        }
    }
}
