using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MvpLearning.Interface;

namespace MvpLearning
{
    public partial class Form1 : UiInterface 
    {
        public event EventHandler UserAddEvent;
        public string UserName
        {

        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
