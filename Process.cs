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

        public int PID
        {
            get
            {
                return ID;
            }
        }

        private List<Command> program;
 
        public Process(int PID)
        {
            ID = PID;
        }

        public void AddCommand(Command newCommand)
        {
            program.Add(newCommand);
        }
    }
}
