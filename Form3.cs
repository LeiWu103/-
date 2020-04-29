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
    public partial class Form3 : Form
    {
        public static Queue<PCB> q = new Queue<PCB>();
        public static int time=0;
        public static PCB[] list3 = new PCB[10];
        public Form3()
        {
            InitializeComponent();
            for (int i = 0; Form1.list[i] != null; i++)
            {
                list3[i] = Form1.list[i].Clone();
            }
        }

        private void 多级反馈调度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
            for(int i = 0; list3[i] != null; i++)
            {
                if (list3[i].arrive_time == 0)
                {
                    q.Enqueue(list3[i]);
                }
            }
            PCB[] list1 = new PCB[10];
            q.CopyTo(list1, 0);
            for (int i = 0; list1[i] != null; i++)
            {
                dataGridView1.Rows.Add(list1[i].process_name, list1[i].arrive_time, list1[i].used_time, list1[i].total_time);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = time.ToString();
            if (q.Count == 0)
            {
                timer1.Stop();
                label2.Visible = true;
                dataGridView2.Visible = true;
                dataGridView2.DataSource = list3;
                time = 0;
                
            }
            else
            {
                q.First().used_time++;
                for (int i = 0;list3[i] != null; i++)
                {
                    if (list3[i].arrive_time == time)
                    {
                        q.Enqueue(list3[i]);
                    }
                }
                if (q.First().used_time >= q.First().total_time)
                {
                    q.First().done_time = time;
                    q.First().wait_time = q.First().done_time - q.First().arrive_time;
                    q.Dequeue();
                }
                dataGridView1.Rows.Clear();
                PCB[] list1 = new PCB[10];
                q.CopyTo(list1, 0);

                for (int i = 0; list1[i] != null; i++)
                {
                    dataGridView1.Rows.Add(list1[i].process_name, list1[i].arrive_time, list1[i].used_time, list1[i].total_time);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void 短作业优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
