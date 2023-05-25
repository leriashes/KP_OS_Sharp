using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal class Process
    {
        private int ID;
        private bool status;
        private List<Command> program;
        private System.Windows.Forms.TextBox output;
        private int commandCounter;

        public int PID
        {
            get
            {
                return ID;
            }
        }
 
        public bool Status
        {
            get 
            { 
                return status; 
            }
        }

        public Process(int PID, System.Windows.Forms.TextBox output)
        {
            program = new List<Command>();
            ID = PID;
            this.output = output;
            commandCounter = 0;
            status = true;
        }

        public void AddCommand(Command newCommand)
        {
            program.Add(newCommand);
            newCommand.PID = PID;
            newCommand.Output = output;
        }

        public bool Run()
        {
            bool result = true;

            if (status) 
            {
                if (program.Count() == 0 || commandCounter >= program.Count())
                {
                    output.Text += "Процесс завершён.\r\n";
                    result = false;
                    status = false;
                }
                else
                {
                    int res = program[commandCounter].Run();

                    if (res == 0 || res == 1)
                    {
                        commandCounter++;
                    }
                }
            }

            return result;
        }
    }
}
