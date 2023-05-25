using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal abstract class Command
    {
        protected int pipeName;

        public int PipeName
        { 
            get 
            { 
                return pipeName; 
            } 
        }


        protected int ownerPID;

        public int PID
        {
            get
            {
                return ownerPID;
            }

            set
            {
                ownerPID = value;
            }
        }


        protected System.Windows.Forms.TextBox output;

        public System.Windows.Forms.TextBox Output
        {
            set 
            { 
                output = value; 
            }
        }

        public Command(int pipeName)
        {
            this.pipeName = pipeName;
        }

        public abstract int Run();
    }
}
