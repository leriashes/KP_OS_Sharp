using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KP_OS_Sharp
{
    internal class OSystem
    {
	    private static OSystem instance;
        private List<Process> processes;
        private List<Pipe> pipes;

        private System.Windows.Forms.TextBox output;
        private List<System.Windows.Forms.TextBox> outputs;

        private int countReady;
        private int countTicks;

        public System.Windows.Forms.TextBox Output
        {
            set 
            { 
                output = value; 
            }
        }

        public List<System.Windows.Forms.TextBox> Outputs
        {
            set
            {
                outputs = value;
            }
        }


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
            processes.Add(new Process(processes.Count() + 1, outputs[processes.Count()]));

            int n = program.Count();
            int index = processes.Count() - 1;

            for (int i = 0; i < n; i++)
            {
                processes[index].AddCommand(program[i]);
            }

            output.Text += "Процесс " + processes.Count().ToString() + " создан.\r\n";
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

        public void Start()
        {
            countReady = 0;
            countTicks = 1;
        }

        public bool Tick()
        {
            output.Text += "\r\n\r\n---------- " + countTicks + " ----------";

            for (int i = 0; i < processes.Count(); i++)
            {
                if (processes[i].Status)
                {
                    //outputs[i].Text += "Шаг " + k + ": ";
                    outputs[i].Text += "---------- " + countTicks + " ----------\r\n";

                    if (!processes[i].Run())
                    {
                        countReady++;
                        output.Text += "\r\nПроцесс " + (i + 1) + " завершён.\r\n"; 
                    }

                    outputs[i].Text += "\r\n";
                }
            }

            countTicks++;

            return countReady >= processes.Count();
        }

        public void Stop()
        {
            output.Text += "\r\n\r\n\r\n----- ВСЕ ПРОЦЕССЫ ЗАВЕРШЕНЫ -----";

            if (pipes.Count()  > 0) 
            {
                for (int i = 0; i < pipes.Count(); i++) 
                {
                    output.Text += "\r\nКанал \"" + pipes[i].Name + "\" закрыт операционной системой.\r\n";
                }
            }

            processes.Clear();
            pipes.Clear();
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

                output.Text += "\r\nКанал \"" + pipes[pipes.Count() - 1].Name + "\" создан.\r\n";
                output.Text += "Владелец: Процесс " + pipes[pipes.Count() - 1].ServerPID + ".\r\n";
                output.Text += "Тип канала: ";

                if (pipes[pipes.Count() - 1].Type == 0)
                {
                    output.Text += "сервер читает, клиент пишет.\r\n";
                }
                else if (pipes[pipes.Count() - 1].Type == 1)
                {
                    output.Text += "сервер пишет, клиент читает.\r\n";
                }
                else
                {
                    output.Text += "дуплексный.\r\n";
                }
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

                output.Text += "\r\nКанал \"" + pipeName + "\" удалён.\r\n";
            }

            return result;
        }
    }
}
