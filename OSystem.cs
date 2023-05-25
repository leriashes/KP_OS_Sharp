using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_OS_Sharp
{
    internal class OSystem
    {
	    private static OSystem instance;
        private List<Process> processes;
        private List<Pipe> pipes;

        protected OSystem() 
        {
            processes = new List<Process>();
            pipes = new List<Pipe>();
        }

        public static OSystem OS()
        {
            if (instance == null)
            {
                instance = new OSystem();
            }

            return instance;
        }

        public int GetProcessesNumber()
        {
            return processes.Count();
        }

        public void AddProcess(List<Command> program)
        {
            processes.Add(new Process(processes.Count() + 1));

            int n = program.Count();
            int index = processes.Count() - 1;

            for (int i = 0; i < n; i++)
            {
                processes[index].AddCommand(program[i]);
            }
        }

        public void DelProcess(int PID)
        {
            for (int i = 0; i < processes.Count(); i++)
            {
                if (processes[i].PID == PID)
                {
                    processes.RemoveAt(i);
                    break;
                }
            }
        }

        public void Stop()
        {
            processes.Clear();
        }

        public int CreatePipe(int PID, int pipeName, int pipeType)
        {
            int n = pipes.Count();
            int result = 0;

            for (int i = 0; i < n && result == 0; i++)
            {
                if (pipes[i].Name == pipeName)
                {
                    result = 1;
                }
            }

            if (result == 0)
            {
                pipes.Add(new Pipe(pipeName, pipeType, PID));
            }

            return result;
        }

        public int DeletePipe(int PID, int pipeName)
        {
            int result = 2;
            int n = pipes.Count();
            int k = -1;

            for (int i = 0; i < n && result == 2; i++)
            {
                if (pipes[i].Name == pipeName)
                {
                    k = i;
                    result = 1;
                }
            }

            if (k != -1 && pipes[k].ServerPID == PID)
                result = 0;

            if (result == 0)
            {
                pipes.RemoveAt(k); ;
            }

            return result;
        }
    }
}
