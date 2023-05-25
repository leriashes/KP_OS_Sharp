using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal class CreateCommand : Command
    {
        private int pipeType;

        public CreateCommand(int pipeName, int pipeType) :base(pipeName) 
        { 
            this.pipeType = pipeType; 
        }

        public override int Run() 
        {
            return OSystem.OS().CreatePipe(PID, pipeName, pipeType);
        }
    }
}
