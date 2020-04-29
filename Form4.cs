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
    public partial class Form4 : Form
    {
        int time = 0;
        public static PCB[] list4 = new PCB[10];
        List<PCB> l = new List<PCB>();
        Queue<PCB> q = new Queue<PCB>();
        public Form4()
        {
            InitializeComponent();
            for (int i = 0; Form1.list[i] != null; i++)
            {
                list4[i] = Form1.list[i].Clone();
            }
        }

        private void 多级反馈调度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void 先来先服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            l = list4.ToList<PCB>();
            for(int i = 0; i < 10; i++)
            {
                l.Remove(null);
            }
            l.Sort((a, b) => a.total_time.CompareTo(b.total_time));
            
            //l.Sort(delegate (PCB p1, PCB p2) { return p1.total_time.CompareTo(p2.total_time); });

            if (l.Count != 0)
            {
                for(int i = 0; i < l.Count; i++)
                {
                    if (l[i].arrive_time == 0)
                    {
                        q.Enqueue(l[i]);
                    }
                }
            }
            PCB[] l1 = new PCB[10];
            q.CopyTo(l1, 0);
            for (int i = 0; i < q.Count; i++)
            {
                dataGridView1.Rows.Add(l1[i].process_name, l1[i].total_time.ToString(), l1[i].used_time.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label2.Text = time.ToString() + "s";
            dataGridView1.Rows.Clear();
            if (q.Count == 0)
            {
                timer1.Stop();
                label1.Visible = true;
                dataGridView2.Visible = true;
                dataGridView2.DataSource = l;
                time = 0;

            }
            else
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i].arrive_time == time)
                    {
                        q.Enqueue(l[i]);
                    }
                }
                q.First().used_time++;
                if (q.First().used_time >= q.First().total_time)
                {
                    q.First().done_time = time;
                    q.First().wait_time = q.First().done_time - q.First().arrive_time;
                    q.Dequeue();
                }
                PCB[] l1 = new PCB[10];
                q.CopyTo(l1, 0);
                for (int i = 0; i < q.Count; i++)
                {
                    dataGridView1.Rows.Add(l1[i].process_name, l1[i].total_time.ToString(), l1[i].used_time.ToString());
                }
            }
            
        }
    }
}
