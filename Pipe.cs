using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal class Pipe
    {
        private int name;
        private int type;
        private int serverPID;

        public int Name
        {
            get 
            { 
                return name; 
            }
        }

        public int Type
        {
            get 
            { 
                return type; 
            }
        }

        public int ServerPID
        {
            get
            {
                return serverPID;
            }
        }
        //queue<System::String^> text;

        public Pipe(int name, int type, int serverPID)
        {
            this.name = name;
            this.type = type;
            this.serverPID = serverPID;
        }
    }
}
