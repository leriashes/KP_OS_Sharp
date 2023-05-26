using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_OS_Sharp
{
    internal class Process
    {
        private int ID;
        private bool status;
        private List<Command> program;
        private TextBox output;
        private int commandCounter;
        private string text;

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

        public Process(int PID, TextBox output)
        {
            program = new List<Command>();
            ID = PID;
            this.output = output;
            commandCounter = 0;
            status = true;

            if (PID % 8 == 1)
            {
                text = "ОДИН1-ONE_";
            }
            else if (PID % 8 == 2)
            {
                text = "ДВА2-TWO_";
            }
            else if (PID % 8 == 3)
            {
                text = "ТРИ3-THREE_";
            }
            else if (PID % 8 == 4)
            {
                text = "ЧЕТЫРЕ4-FOUR_";
            }
            else if (PID % 8 == 5)
            {
                text = "ПЯТЬ5-FIVE_";
            }
            else if (PID % 8 == 6)
            {
                text = "ШЕСТЬ6-SIX_";
            }
            else if (PID % 8 == 7)
            {
                text = "СЕМЬ7-SEVEN_";
            }
            else
            {
                text = "ВОСЕМЬ8-EIGHT_";
            }
        }

        public void AddCommand(Command newCommand)
        {
            program.Add(newCommand);
            newCommand.PID = PID;
            newCommand.Output = output;
            newCommand.Text = text;
        }

        public bool Run()
        {
            bool result = true;

            if (status) 
            {
                if (program.Count() == 0 || commandCounter >= program.Count())
                {
                    output.Text += "Завершил работу.\r\n";
                    result = false;
                    status = false;
                }
                else
                {
                    int res = program[commandCounter].Run();

                    if (res == 0)
                    {
                        commandCounter++;
                    }
                }
            }

            return result;
        }
    }
}
