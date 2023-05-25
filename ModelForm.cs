using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KP_OS_Sharp
{
	public partial class ModelForm : Form
	{
        private List<TextBox> textBoxes;
        private List<GroupBox> groupBoxes;
        private int processes_number = 0;
        private List<List<int>> programs;
        private List<int> actions;

        public ModelForm(int processesNumber, List<List<int>> programs, List<int> actions)
		{
			InitializeComponent();

			textBoxes = new List<TextBox>();
			groupBoxes = new List<GroupBox>();

            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(textBox5);
            textBoxes.Add(textBox6);
            textBoxes.Add(textBox7);
            textBoxes.Add(textBox8);
            textBoxes.Add(textBox9);

            groupBoxes.Add(groupBox1);
            groupBoxes.Add(groupBox2);
            groupBoxes.Add(groupBox3);
            groupBoxes.Add(groupBox4);
            groupBoxes.Add(groupBox5);
            groupBoxes.Add(groupBox6);
            groupBoxes.Add(groupBox7);
            groupBoxes.Add(groupBox8);
            groupBoxes.Add(groupBox9);

            OSystem.OS().Output = textBox9;
            OSystem.OS().Outputs = textBoxes;

            processes_number = processesNumber;
            this.programs = programs;
            this.actions = actions;
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            List<Command> program = new List<Command>();

            for (int i = 0; i < processes_number; i++)
            {
                for (int j = 0; j < actions[i]; j++)
                {
                    int commandCode = programs[i * 23 + j][0];
                    int pipeName = programs[i * 23 + j][1];
                    int specialCode = programs[i * 23 + j][2];

                    //programs[i * 23 + j].Clear();

                    Command command = null;

                    if (commandCode == 0)
                    {
                        command = new CreateCommand(pipeName, specialCode);
                    }
                    else if (commandCode == 1)
                    {
                        ;
                    }
                    else if (commandCode == 2)
                    {
                        ;
                    }
                    else if (commandCode == 3)
                    {
                        ;
                    }

                    if (command != null)
                        program.Add(command);
                }


                OSystem.OS().AddProcess(program);
                program.Clear();
            }

            for (int i = 0; i < 8; i++)
            {
                groupBoxes[i].Visible = i < processes_number;

                //if (i < processes_number)
                    //OSystem.OS().AddProcess();
                    //textBox9.Text += "Процесс " + (i + 1).ToString() + " создан.\r\n";
            }

            textBox9.Text += "\r\n";

            timer1.Enabled = true;

            OSystem.OS().Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (OSystem.OS().Tick())
            {
                timer1.Enabled = false;
                OSystem.OS().Stop(); 
            }
        }
    }
}
