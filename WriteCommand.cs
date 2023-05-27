namespace KP_OS_Sharp
{
    internal class WriteCommand : Command
    {
        private int symbolsNumber;
        private int remainder;
        private int waiting;
        private Pipe pipe;

        public override string Text 
        {
            set
            {
                for (int i = 0, j = 0; i < symbolsNumber; i++)
                {
                    text += value[j];

                    j++;

                    if (j == value.Length)
                        j = 0;
                }
            }
        }

        public WriteCommand(int pipeName, int duration, int symbolsNumber) : base(pipeName, duration)
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

            if (remainder == duration)
            {
                int openResult = OSystem.OS().OpenPipe(PID, pipeName, 3, out pipe);

                if (openResult == 0)
                {
                    output.Text += "Канал \"" + pipeName + "\" открыт на запись.\r\nНачинаю запись " + symbolsNumber + " символ";
                    if (symbolsNumber % 10 == 1 && symbolsNumber != 11)
                    {
                        output.Text += "а ";
                    }
                    else
                    {
                        output.Text += "ов ";
                    }

                    output.Text += ": \"" + text + "\"\r\n";

                    waiting = -1;
                    remainder--;

                    pipe.Text += text;
                }
                else if (openResult == 1)
                {
                    output.Text += "Не удалось открыть канал \"" + pipeName + "\" на запись: недостаточно прав.\r\n";
                    result = 0;
                    waiting = 0;
                }
                else if (openResult == 2)
                {
                    output.Text += "Не удалось открыть канал \"" + pipeName + "\" на запись: канал с заданным именем не существует.\r\n";

                    if (waiting == -1)
                        waiting = 5;
                    waiting--;
                }
                else if (openResult == 3)
                {
                    output.Text += "Не удалось открыть канал \"" + pipeName + "\" на запись: канал с заданным именем занят другим процессом.\r\n";
                    if (waiting == -1)
                        waiting = 5;

                    waiting--;
                }
            }
            else
            {
                remainder--;
                output.Text += "Идёт запись в канал \"" + pipeName + "\"...\r\n";
            }

            if (remainder == 0)
            {
                output.Text += "Запись завершена. Закрываю канал.\r\n";
                pipe.Close();
                result = 0;
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
