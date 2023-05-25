using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal class DeleteCommand : Command
    {

        public DeleteCommand(int pipeName) : base(pipeName)
        {

        }

        public override int Run()
        {
            return OSystem.OS().DeletePipe(PID, pipeName);
        }
    }
}
