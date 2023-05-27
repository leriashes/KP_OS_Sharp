namespace KP_OS_Sharp
{
    internal class Pipe
    {
        private int name;
        private int type;
        private int serverPID;
        private int openedPID;

        private int status;
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

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }

        }

        public Pipe(int name, int type, int serverPID)
        {
            this.name = name;
            this.type = type;
            this.serverPID = serverPID;
            openedPID = 0;
            text = "";
            status = 2;
        }

        public void Open(int PID)
        {
            openedPID = PID;
        }

        public void Close()
        {
            openedPID = 0;
            status = 1;
        }

        public string Read(int symbolsNumber)
        {
            string result = "";

            for (int i = 0; i < symbolsNumber; i++)
            {
                if (text.Length > 0)
                {
                    result += text[0];
                    text = text.Substring(1);
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public void Write (string text)
        {
            this.text += text;
        }
    }
}
