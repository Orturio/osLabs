using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsForms
{
    public class Thread
    {
        MainForm mainForm = new MainForm();       
        public int tid { get; set; }
        public int pid { get; set; }
        public int threadExecutionTime { get; set; }
        public int timeOfOneIteration { get; set; }

        public Thread (int tid, int pid, MainForm mainForm)
        {
            this.tid = tid;
            this.pid = pid;
            this.mainForm = mainForm;
            Random rand = new Random();

            this.threadExecutionTime = (rand.Next() % 21) + 10;
            this.timeOfOneIteration = (rand.Next() % 4) + 3;
        }

        public void  minusThreadExecutionTime()
        {
            threadExecutionTime -= timeOfOneIteration;           
        }

        public void Start()
        {
            mainForm.Threads.Add((pid, tid, timeOfOneIteration));
            mainForm.DrawThread(mainForm.gr);
        }
    }
}
