using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    public class Process
    {
        public List<Thread> threads = new List<Thread>();
        MainForm mainForm = new MainForm(); 
        public int pid { get; set; }
        public int timeOfOneIteration { get; set; }
        public int processExecutionTime { get; set; }

        public Process (int pid, MainForm mainForm)
        {
            this.pid = pid;
            this.mainForm = mainForm;
            Random rand = new Random();
            processExecutionTime = 0;

            for (int i = 0; i < rand.Next() % 3 + 1; i++)
            {
                this.createThread();
                processExecutionTime += threads[i].timeOfOneIteration;
            }
        }

        public void minusProcessExecutionTime()
        {          
                processExecutionTime -= timeOfOneIteration;
        }

        public void createThread()
        {
            threads.Add(new Thread(threads.Count(), pid, mainForm));
        }

        public void toPlan()
        {
            int temp = 0;
            while (true)
            {
                for (int i = 0; i < threads.Count(); i++)
                {
                    threads[i].Start();
                    temp += threads[i].timeOfOneIteration;
                    threads[i].minusThreadExecutionTime();
                    if (threads[i].threadExecutionTime < 0)
                    {
                        threads.Remove(threads[i]);
                        i--;
                    }
                    //Максимальное время для потока
                    int maximumTimeForThreads = 30;
                    if (temp > maximumTimeForThreads)
                    {
                        timeOfOneIteration = temp;
                        return;
                    }
                }
                if (threads.Count() == 0)
                {
                    timeOfOneIteration = temp;
                    return;
                }
            }
        }

        public void start()
        {
            toPlan();
        }
    }
}
