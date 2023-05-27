using System.Windows.Forms;

namespace KP_OS_Sharp
{
    internal abstract class Command
    {
        protected int pipeName;
        protected int ownerPID;
        protected TextBox output;
        protected int duration;
        protected string text;

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

        public virtual string Text
        {
            set
            {

                text = value; 
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
