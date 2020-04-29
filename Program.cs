using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 操作系统课设
{
    public class PCB
    {
        public PCB(string pn,int tt,int ut,int at)
        {
            this.process_name = pn;
            this.total_time = tt;
            //this.need_time = nt;
            this.used_time = ut;
            this.arrive_time = at;
            this.done_time = 0;
            this.wait_time = 0;
        }
        public string process_name { get; set; }
        public int total_time { get; set;}
        //public int need_time { get; set; }
        public int used_time { get; set; }
        public int arrive_time { get; set; }
        public int wait_time { get; set; }
        public int done_time { get; set; }
        public PCB Clone()
        {
            return this.MemberwiseClone() as PCB;
        }
    }
    
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
        
    }
}
