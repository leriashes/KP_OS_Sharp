using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_OS_Sharp
{
    internal class DeleteCommand : Command
    {

        public DeleteCommand(int pipeName) : base(pipeName, 1)
        {

        }

        public override int Run()
        {
            int result = OSystem.OS().DeletePipe(PID, pipeName);

            if (result == 0)
            {
                output.Text += "Удалён канал \"" + pipeName + "\".\r\n";
            }
            else if (result == 1)
            {
                output.Text += "Не удалось удалить канал \"" + pipeName + "\": нет прав.\r\n";
                result = 0;
            }
            else if (result == 2)
            {
                output.Text += "Не удалось удалить канал \"" + pipeName + "\": канал с заданным именем не существует.\r\n";
                result = 0;
            }
            else
            {
                output.Text += "Не удалось удалить канал \"" + pipeName + "\": канал с заданным именем занят другим процессом-клиентом.\r\n";
                result = 1;
            }

            return result;
        }
    }
}
