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

    public partial class Form1 : Form
    {

        public static int time = 0;
        public static PCB[] list0 = new PCB[10];
        public static PCB[] list = new PCB[10];
        
        public static int p1 = 0, p2 = 0, p3 = 0;
        public static Queue<PCB> q1 = new Queue<PCB>();
        public static Queue<PCB> q2 = new Queue<PCB>();
        public static Queue<PCB> q3 = new Queue<PCB>();
        public Form1()
        {

            InitializeComponent();
            //list[0] = (new PCB("A", 2, 0, 0));
            //list[1] = (new PCB("B", 9, 0, 0));
            //list[2] = (new PCB("C", 5, 0, 1));
            //list[3] = (new PCB("D", 1, 0, 10));
            for(int i = 0; list[i] != null; i++)
            {
                list0[i] = list[i].Clone();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (list0.Length == 0)
            {
                MessageBox.Show("现在没有进程，请添加！");
            }
            else
            {
                
                for(int i = 0; list0[i]!=null; i++)
                {
                    if (list0[i].arrive_time == 0)
                    {
                        q1.Enqueue(list0[i]);
                    }
                }
                PCB[] list1 = new PCB[10];
                q1.CopyTo(list1, 0);
                for (int i = 0; list1[i] != null; i++)
                {
                    dataGridView1.Rows.Add(list1[i].process_name, list1[i].arrive_time,list1[i].used_time,list1[i].total_time);
                }
                timer1.Start();
                timer2.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            time++;
            for (int i = 0; list0[i]!=null; i++)
            {
                if (list0[i].arrive_time == time)
                {
                    q1.Enqueue(list0[i]);
                    timer2.Start();
                    timer3.Stop();
                    timer4.Stop();
                }
            }
            label2.Text =  time.ToString() + "s";
            label2.Refresh();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            PCB[] list1 = new PCB[10];
            q1.CopyTo(list1, 0);
            for (int i = 0; list1[i] != null; i++)
            {

                dataGridView1.Rows.Add(list1[i].process_name, list1[i].arrive_time, list1[i].used_time);
            }
            PCB[] list2 = new PCB[10];
            q2.CopyTo(list2, 0);
            for (int i = 0; list2[i] != null; i++)
            {
                //dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(list2[i].process_name, list2[i].arrive_time, list2[i].used_time);
            }
            PCB[] list3 = new PCB[10];
            q3.CopyTo(list3, 0);
            for (int i = 0; list3[i] != null; i++)
            {
                //dataGridView3.Rows.Clear();
                dataGridView3.Rows.Add(list3[i].process_name, list3[i].arrive_time, list3[i].used_time);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Form2 form2 = new Form2();
            form2.Show();
            
        }

       

        private void timer2_Tick(object sender, EventArgs e)
        {
            p1++;
            
            label1.Text = "第一级队列，时间片2s\n当前已使用" + p1.ToString()+"个";
            q1.First().used_time += 2;
            if (q1.First().used_time >= q1.First().total_time)
            {
                q1.First().done_time = time+1;
                q1.First().wait_time = time - q1.First().arrive_time+1;
                q1.Dequeue();
                if (q1.Count == 0)
                {
                    timer2.Stop();
                    dataGridView1.Rows.Clear();
                }
            }
            else
            {
                q2.Enqueue(q1.Dequeue());
                if (q1.Count == 0)
                {
                    timer2.Stop();
                    dataGridView1.Rows.Clear();
                }
            }


            if (q1.Count == 0)
            {
                timer3.Start();
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void 先进先出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        private void 短作业优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < list0.Length; i++)
            {
                list0[i] = null;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            p2++;
            label3.Text = "第二级队列，时间片4s\n当前已使用" + p2.ToString() + "个";
            q2.First().used_time += 4;
            if (q2.First().used_time >= q2.First().total_time)
            {
                q2.First().done_time = time+1;
                q2.First().wait_time = time - q2.First().arrive_time;
                q2.Dequeue();
                if (q1.Count == 0)
                {
                    timer3.Stop();
                    dataGridView2.Rows.Clear();
                }
            }
            else
            {
                q3.Enqueue(q2.Dequeue());
                if (q2.Count == 0)
                {
                    timer3.Stop();
                    dataGridView2.Rows.Clear();
                }
            }
           
            if (q2.Count == 0)
            {
                timer4.Start();
                
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            p3++;
            label4.Text = "第三级队列，时间片6s\n当前已使用" + p3.ToString() + "个";
            q3.First().used_time += 6;
            if (q3.First().used_time >= q3.First().total_time)
            {
                q3.First().done_time = time+1;
                q3.First().wait_time = time - q3.First().arrive_time+1;
                q3.Dequeue();
            }
            
            if (q3.Count == 0)
            {
                timer1.Stop();
                timer4.Stop();
                time++;
                
                label2.Text = time.ToString() + "s";
                label2.Refresh();
                dataGridView3.Rows.Clear();
                MessageBox.Show("所有进程均已结束，共用时" + time.ToString() + "秒。");
                dataGridView4.DataSource = list0;
                label5.Visible=true;
                dataGridView4.Visible = true;
                time=0;
            }
        }
    }
}