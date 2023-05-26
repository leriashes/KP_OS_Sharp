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
        private int openedPID;
        private string text;

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

        public int OpenedPID
        {
            get
            {
                return openedPID;
            }
        }

        public Pipe(int name, int type, int serverPID)
        {
            this.name = name;
            this.type = type;
            this.serverPID = serverPID;
            openedPID = 0;
            text = "";
        }

        public void Open(int PID)
        {
            openedPID = PID;
        }

        public void Close()
        {
            openedPID = 0;
        }
    }
}
