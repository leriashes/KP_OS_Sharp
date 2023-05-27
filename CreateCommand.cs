namespace KP_OS_Sharp
{
    internal class CreateCommand : Command
    {
        private int pipeType;

        public CreateCommand(int pipeName, int pipeType) :base(pipeName, 1) 
        { 
            this.pipeType = pipeType; 
        }

        public override int Run() 
        {
            int result = OSystem.OS().CreatePipe(PID, pipeName, pipeType);

            if (result == 0) 
            {
                output.Text += "Создан канал \"" + pipeName + "\".\r\n";
            }
            else if (result == 1)
            {
                output.Text += "Не удалось создать канал \"" + pipeName + "\": канал с заданным именем уже существует.\r\n";
                result = 0;
            }

            return result;
        }
    }
}
