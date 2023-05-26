﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_OS_Sharp
{
    internal abstract class Command
    {
        protected int pipeName;
        protected int ownerPID;
        protected TextBox output;
        protected int duration;

        public int PipeName
        { 
            get 
            { 
                return pipeName; 
            } 
        }

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

        public TextBox Output
        {
            set 
            { 
                output = value; 
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }
        }

        public Command(int pipeName, int duration)
        {
            this.pipeName = pipeName;
            this.duration = duration;
        }

        public abstract int Run();
    }
}
