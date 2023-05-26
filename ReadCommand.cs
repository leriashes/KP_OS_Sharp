﻿using System;
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
        private int symbolsRemainder;

        public override string Text 
        { 
            set
            {
                text = "";
            }
                
        }

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
                output.Text += "Идёт чтение из канала \"" + pipeName + "\"...\r\n";
            }

            if (remainder == 0)
            {
                symbolsRemainder = symbolsNumber;

                for (int i = 0; i < symbolsNumber; i++) 
                {
                    if (pipe.Text.Length > 0)
                    {
                        text += pipe.Text[0];
                        pipe.Text = pipe.Text.Substring(1);
                        symbolsRemainder--;
                    }
                    else
                    {
                        break;
                    }
                }

                result = 0;

                if (symbolsRemainder != 0)
                {
                    output.Text += "Удалось считать только " + (symbolsNumber - symbolsRemainder) + " из " + symbolsNumber + " символ";
                    if (symbolsNumber % 10 == 1 && symbolsNumber != 11)
                    {
                        output.Text += "а ";
                    }
                    else
                    {
                        output.Text += "ов ";
                    }

                    output.Text += ".\r\n";
                    symbolsNumber = symbolsRemainder;
                    result = 1;
                    duration = 2;
                    remainder = 2;
                }

                output.Text += "Результат: \"" + text + "\"\r\n";

                if (symbolsRemainder == 0)
                    output.Text += "Чтение завершено. ";
                output.Text += "Закрываю канал.\r\n";
                pipe.Close();
            }

            if (waiting == 0)
            {
                output.Text += "Перехожу к следующей инструкции.\r\n";
                result = 0;
            }

            return result;
        }
    }
}
