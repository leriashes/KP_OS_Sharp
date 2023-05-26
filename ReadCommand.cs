using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OS_Sharp
{
    internal class ReadCommand : Command
    {
        private int symbolsNumber;
        private int remainder;
        private int waiting;
        private Pipe pipe;

        public ReadCommand(int pipeName, int duration, int symbolsNumber) : base(pipeName, duration)
        {
            this.symbolsNumber = symbolsNumber;
            remainder = duration;
            pipe = null;
            waiting = -1;
            text = "";
        }

        public override int Run()
        {
            int result = 1;

            if (remainder < duration && pipe == null)
            {
                output.Text += "Канал \"" + pipeName + "\" был удалён.\r\n";
                duration = remainder;
            }

            if (remainder == duration) 
            {
                int openResult = OSystem.OS().OpenPipe(PID, pipeName, 2, out pipe);

                if (openResult == 0)
                {
                    output.Text += "Канал \"" + pipeName + "\" открыт на чтение.\r\nНачинаю чтение " + symbolsNumber + " символ";
                    if (symbolsNumber % 10 == 1 && symbolsNumber != 11)
                    {
                        output.Text += "а ";
                    }
                    else
                    {
                        output.Text += "ов ";
                    }

                    output.Text += ".\r\n";

                    waiting = -1;
                    remainder--;
                }
                else if (openResult == 1)
                {
                    output.Text += "Не удалось открыть канал \"" + pipeName + "\" на чтение: недостаточно прав.\r\n";
                    result = 0;
                    waiting = 0;
                }
                else if (openResult == 2)
                {
                    output.Text += "Не удалось открыть канал \"" + pipeName + "\" на чтение: канал с заданным именем не существует.\r\n";

                    if (waiting == -1)
                        waiting = 5;
                    waiting--;
                }
                else if (openResult == 3)
                {
                    output.Text += "Не удалось открыть канал \"" + pipeName + "\" на чтение: канал с заданным именем занят другим процессом.\r\n";
                    if (waiting == -1)
                        waiting = 5;

                    waiting--;
                }
            }
            else 
            {
                remainder--;
            }

            if (remainder == 0)
            {
                output.Text += "Чтение завершено.\r\n";
                pipe.Close();
                result = 0;
            }

            if (waiting == 0)
            {
                output.Text += "Перехожу к следующей инструкци.\r\n";
                result = 0;
            }

            return result;
        }
    }
}
