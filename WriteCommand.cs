﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal class WriteCommand : Command
    {
        private int symbolsNumber;

        public WriteCommand(int pipeName, int duration, int symbolsNumber) : base(pipeName, duration)
        {
            this.symbolsNumber = symbolsNumber;
        }

        public override int Run()
        {
            int result = 0;

            return result;
        }
    }
}
