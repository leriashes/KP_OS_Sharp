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

        public ModelForm()
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
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            int n = OSystem.OS().GetProcessesNumber();

            for (int i = 0; i < 8; i++)
            {
                groupBoxes[i].Visible = i < n;

                if (i < n)
                    textBox9.Text += "Процесс " + (i + 1).ToString() + " создан.\r\n";
            }

            textBox9.Text += "\r\n";

            while (true)
            {
                for (int i = 0; i < n; i++)
                {

                }

                break;
            }
        }
    }
}
