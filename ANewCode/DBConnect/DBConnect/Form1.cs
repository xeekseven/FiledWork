using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnect;

namespace DBConnect
{
    public partial class Form1 : Form
    {
        DbOprClass db = new DbOprClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getData()
        {
            try
            {
                DataSet ds = db.GetData();
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.txtID.Text);
                if (db.DeleteData(id))
                {
                    this.getData();
                    MessageBox.Show(string.Format("删除成功，被删除的ＩＤ号{0}", id));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
