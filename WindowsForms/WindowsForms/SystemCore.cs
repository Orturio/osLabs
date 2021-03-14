using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    public class SystemCore
    {
        List<Process> processes = new List<Process>();

        MainForm mainForm = new MainForm();

        public void AddProcesses() 
        {
            processes.Add(new Process(processes.Count(), mainForm));
        }

        public SystemCore(MainForm mainForm)
        {
            this.mainForm = mainForm;
            processes = new List<Process>();
        }

        public void toPlan()
        {
            int temp = 0;
            while (true)
            {
                for (int i = 0; i < processes.Count(); i++)
                {
                    processes[i].start();
                    temp += processes[i].timeOfOneIteration;
                    processes[i].minusProcessExecutionTime();
                    if (processes[i].processExecutionTime < 0)
                    {
                        processes.Remove(processes[i]);
                        i--;
                    }
                    //Максимальное время для процесса
                    int maximumTimeForProcesses = 500;
                    if (temp > maximumTimeForProcesses)
                    {
                        return;
                    }
                }
                if (processes.Count() == 0)
                {
                    return;
                }
            }
        }

        public void Start()
        {
            int n = new Random().Next() % 3 + 1;
            for (int i = 0; i < n; ++i)
            {
                processes.Add(new Process(i, mainForm));
            }
            toPlan();
        }
    }
}
