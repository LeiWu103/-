using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 操作系统课设
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1.p1.set_name(textBox1.Text);
            //Form1.p1.set_total_time(int.Parse(numericUpDown1.Value.ToString()));

            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                Form1.list0[i] = new PCB(dataGridView1.Rows[i].Cells[0].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()), 0, int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
            }
            this.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
