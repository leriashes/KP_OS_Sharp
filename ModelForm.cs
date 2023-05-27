﻿using System;
using System.Collections.Generic;
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

        public ModelForm(int timerInterval, int processesNumber, List<List<int>> programs, List<int> actions)
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

            timer1.Interval = timerInterval * 1000;
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
                    int duration = programs[i * 23 + j][3];

                    Command command = null;

                    if (commandCode == 0)
                    {
                        command = new CreateCommand(pipeName, specialCode);
                    }
                    else if (commandCode == 1)
                    {
                        command = new DeleteCommand(pipeName);
                    }
                    else if (commandCode == 2 && duration != 0)
                    {
                        command = new ReadCommand(pipeName, duration, specialCode);
                    }
                    else if (commandCode == 3 && duration != 0)
                    {
                        command = new WriteCommand(pipeName, duration, specialCode);
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
            }

            timer1.Enabled = true;
            button_next.Enabled = true;

            textBox9.Text += "\r\n";

            OSystem.OS().Start();

            Timer1_Tick(sender, e);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (OSystem.OS().Tick())
            {
                timer1.Enabled = false;
                button_next.Enabled = false;
                OSystem.OS().Stop(); 
            }
        }

        private void Button_next_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;

            Timer1_Tick(sender, e);
        }
    }
}
