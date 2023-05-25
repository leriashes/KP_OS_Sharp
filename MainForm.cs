using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace KP_OS_Sharp
{
	public partial class MainForm : Form
	{
		private int selected_process = -1;
		private int processes_number = 0;
		private List<int> actions;
		private List<List<int>> programms;

		private List<FlowLayoutPanel> flowLayoutPanels;
		private List<Panel> panels;
		private List<Label> labels;

		public MainForm()
		{
			InitializeComponent();

			programms = new List<List<int>>();

			for (int i = 0; i < 184; i++)
			{
				programms.Add(new List<int>());

				for (int j = 0; j < 3; j++)
				{
					programms[i].Add(0);
				}
			}

			flowLayoutPanels = new List<FlowLayoutPanel>();
			panels = new List<Panel>();
			labels = new List<Label>();

			flowLayoutPanels.Add(flowLayoutPanel1);
			flowLayoutPanels.Add(flowLayoutPanel2);
			flowLayoutPanels.Add(flowLayoutPanel3);
			flowLayoutPanels.Add(flowLayoutPanel4);
			flowLayoutPanels.Add(flowLayoutPanel5);
			flowLayoutPanels.Add(flowLayoutPanel6);
			flowLayoutPanels.Add(flowLayoutPanel7);
			flowLayoutPanels.Add(flowLayoutPanel8);

			panels.Add(panel2);
			panels.Add(panel3);
			panels.Add(panel4);
			panels.Add(panel5);
			panels.Add(panel6);
			panels.Add(panel7);
			panels.Add(panel8);
			panels.Add(panel9);
			panels.Add(panel10);
			panels.Add(panel11);
			panels.Add(panel12);
			panels.Add(panel13);
			panels.Add(panel14);
			panels.Add(panel15);
			panels.Add(panel16);
			panels.Add(panel17);
			panels.Add(panel18);
			panels.Add(panel19);
			panels.Add(panel20);
			panels.Add(panel21);
			panels.Add(panel22);
			panels.Add(panel23);
			panels.Add(panel24);

			panels.Add(panel25);
			panels.Add(panel26);
			panels.Add(panel27);
			panels.Add(panel28);
			panels.Add(panel29);
			panels.Add(panel30);
			panels.Add(panel31);
			panels.Add(panel32);
			panels.Add(panel33);
			panels.Add(panel34);
			panels.Add(panel35);
			panels.Add(panel36);
			panels.Add(panel37);
			panels.Add(panel38);
			panels.Add(panel39);
			panels.Add(panel40);
			panels.Add(panel41);
			panels.Add(panel42);
			panels.Add(panel43);
			panels.Add(panel44);
			panels.Add(panel45);
			panels.Add(panel46);
			panels.Add(panel47);

			panels.Add(panel70);
			panels.Add(panel69);
			panels.Add(panel68);
			panels.Add(panel67);
			panels.Add(panel66);
			panels.Add(panel65);
			panels.Add(panel64);
			panels.Add(panel63);
			panels.Add(panel62);
			panels.Add(panel61);
			panels.Add(panel60);
			panels.Add(panel59);
			panels.Add(panel58);
			panels.Add(panel57);
			panels.Add(panel56);
			panels.Add(panel55);
			panels.Add(panel54);
			panels.Add(panel53);
			panels.Add(panel52);
			panels.Add(panel51);
			panels.Add(panel50);
			panels.Add(panel49);
			panels.Add(panel48);

			panels.Add(panel71);
			panels.Add(panel72);
			panels.Add(panel73);
			panels.Add(panel74);
			panels.Add(panel75);
			panels.Add(panel76);
			panels.Add(panel77);
			panels.Add(panel78);
			panels.Add(panel79);
			panels.Add(panel80);
			panels.Add(panel81);
			panels.Add(panel82);
			panels.Add(panel83);
			panels.Add(panel84);
			panels.Add(panel85);
			panels.Add(panel86);
			panels.Add(panel87);
			panels.Add(panel88);
			panels.Add(panel89);
			panels.Add(panel90);
			panels.Add(panel91);
			panels.Add(panel92);
			panels.Add(panel93);

			panels.Add(panel94);
			panels.Add(panel95);
			panels.Add(panel96);
			panels.Add(panel97);
			panels.Add(panel98);
			panels.Add(panel99);
			panels.Add(panel100);
			panels.Add(panel101);
			panels.Add(panel102);
			panels.Add(panel103);
			panels.Add(panel104);
			panels.Add(panel105);
			panels.Add(panel106);
			panels.Add(panel107);
			panels.Add(panel108);
			panels.Add(panel109);
			panels.Add(panel110);
			panels.Add(panel111);
			panels.Add(panel112);
			panels.Add(panel113);
			panels.Add(panel114);
			panels.Add(panel115);
			panels.Add(panel116);

			panels.Add(panel117);
			panels.Add(panel118);
			panels.Add(panel119);
			panels.Add(panel120);
			panels.Add(panel121);
			panels.Add(panel122);
			panels.Add(panel123);
			panels.Add(panel124);
			panels.Add(panel125);
			panels.Add(panel126);
			panels.Add(panel127);
			panels.Add(panel128);
			panels.Add(panel129);
			panels.Add(panel130);
			panels.Add(panel131);
			panels.Add(panel132);
			panels.Add(panel133);
			panels.Add(panel134);
			panels.Add(panel135);
			panels.Add(panel136);
			panels.Add(panel137);
			panels.Add(panel138);
			panels.Add(panel139);

			panels.Add(panel140);
			panels.Add(panel141);
			panels.Add(panel142);
			panels.Add(panel143);
			panels.Add(panel144);
			panels.Add(panel145);
			panels.Add(panel146);
			panels.Add(panel147);
			panels.Add(panel148);
			panels.Add(panel149);
			panels.Add(panel150);
			panels.Add(panel151);
			panels.Add(panel152);
			panels.Add(panel153);
			panels.Add(panel154);
			panels.Add(panel155);
			panels.Add(panel156);
			panels.Add(panel157);
			panels.Add(panel158);
			panels.Add(panel159);
			panels.Add(panel160);
			panels.Add(panel161);
			panels.Add(panel162);

			panels.Add(panel163);
			panels.Add(panel164);
			panels.Add(panel165);
			panels.Add(panel166);
			panels.Add(panel167);
			panels.Add(panel168);
			panels.Add(panel169);
			panels.Add(panel170);
			panels.Add(panel171);
			panels.Add(panel172);
			panels.Add(panel173);
			panels.Add(panel174);
			panels.Add(panel175);
			panels.Add(panel176);
			panels.Add(panel177);
			panels.Add(panel178);
			panels.Add(panel179);
			panels.Add(panel180);
			panels.Add(panel181);
			panels.Add(panel182);
			panels.Add(panel183);
			panels.Add(panel184);
			panels.Add(panel185);

			labels.Add(label3);
			labels.Add(label4);
			labels.Add(label5);
			labels.Add(label6);
			labels.Add(label7);
			labels.Add(label8);
			labels.Add(label9);
			labels.Add(label10);
			labels.Add(label11);
			labels.Add(label12);
			labels.Add(label13);
			labels.Add(label14);
			labels.Add(label15);
			labels.Add(label16);
			labels.Add(label17);
			labels.Add(label18);
			labels.Add(label19);
			labels.Add(label20);
			labels.Add(label21);
			labels.Add(label22);
			labels.Add(label23);
			labels.Add(label24);

			labels.Add(label25);
			labels.Add(label26);
			labels.Add(label27);
			labels.Add(label28);
			labels.Add(label29);
			labels.Add(label30);
			labels.Add(label31);
			labels.Add(label32);
			labels.Add(label33);
			labels.Add(label34);
			labels.Add(label35);
			labels.Add(label36);
			labels.Add(label37);
			labels.Add(label38);
			labels.Add(label39);
			labels.Add(label40);
			labels.Add(label41);
			labels.Add(label42);
			labels.Add(label43);
			labels.Add(label44);
			labels.Add(label45);
			labels.Add(label46);
			labels.Add(label47);

			labels.Add(label48);
			labels.Add(label49);
			labels.Add(label50);
			labels.Add(label51);
			labels.Add(label52);
			labels.Add(label53);
			labels.Add(label54);
			labels.Add(label55);
			labels.Add(label56);
			labels.Add(label57);
			labels.Add(label58);
			labels.Add(label59);
			labels.Add(label60);
			labels.Add(label61);
			labels.Add(label62);
			labels.Add(label63);
			labels.Add(label64);
			labels.Add(label65);
			labels.Add(label66);
			labels.Add(label67);
			labels.Add(label68);
			labels.Add(label69);
			labels.Add(label70);

			labels.Add(label71);
			labels.Add(label72);
			labels.Add(label73);
			labels.Add(label74);
			labels.Add(label75);
			labels.Add(label76);
			labels.Add(label77);
			labels.Add(label78);
			labels.Add(label79);
			labels.Add(label80);
			labels.Add(label81);
			labels.Add(label82);
			labels.Add(label83);
			labels.Add(label84);
			labels.Add(label85);
			labels.Add(label86);
			labels.Add(label87);
			labels.Add(label88);
			labels.Add(label89);
			labels.Add(label90);
			labels.Add(label91);
			labels.Add(label92);
			labels.Add(label93);

			labels.Add(label94);
			labels.Add(label95);
			labels.Add(label96);
			labels.Add(label97);
			labels.Add(label98);
			labels.Add(label99);
			labels.Add(label100);
			labels.Add(label101);
			labels.Add(label102);
			labels.Add(label103);
			labels.Add(label104);
			labels.Add(label105);
			labels.Add(label106);
			labels.Add(label107);
			labels.Add(label108);
			labels.Add(label109);
			labels.Add(label110);
			labels.Add(label111);
			labels.Add(label112);
			labels.Add(label113);
			labels.Add(label114);
			labels.Add(label115);
			labels.Add(label116);

			labels.Add(label117);
			labels.Add(label118);
			labels.Add(label119);
			labels.Add(label120);
			labels.Add(label121);
			labels.Add(label122);
			labels.Add(label123);
			labels.Add(label124);
			labels.Add(label125);
			labels.Add(label126);
			labels.Add(label127);
			labels.Add(label128);
			labels.Add(label129);
			labels.Add(label130);
			labels.Add(label131);
			labels.Add(label132);
			labels.Add(label133);
			labels.Add(label134);
			labels.Add(label135);
			labels.Add(label136);
			labels.Add(label137);
			labels.Add(label138);
			labels.Add(label139);

			labels.Add(label140);
			labels.Add(label141);
			labels.Add(label142);
			labels.Add(label143);
			labels.Add(label144);
			labels.Add(label145);
			labels.Add(label146);
			labels.Add(label147);
			labels.Add(label148);
			labels.Add(label149);
			labels.Add(label150);
			labels.Add(label151);
			labels.Add(label152);
			labels.Add(label153);
			labels.Add(label154);
			labels.Add(label155);
			labels.Add(label156);
			labels.Add(label157);
			labels.Add(label158);
			labels.Add(label159);
			labels.Add(label160);
			labels.Add(label161);
			labels.Add(label162);

			labels.Add(label163);
			labels.Add(label164);
			labels.Add(label165);
			labels.Add(label166);
			labels.Add(label167);
			labels.Add(label168);
			labels.Add(label169);
			labels.Add(label170);
			labels.Add(label171);
			labels.Add(label172);
			labels.Add(label173);
			labels.Add(label174);
			labels.Add(label175);
			labels.Add(label176);
			labels.Add(label177);
			labels.Add(label178);
			labels.Add(label179);
			labels.Add(label180);
			labels.Add(label181);
			labels.Add(label182);
			labels.Add(label183);
			labels.Add(label184);
			labels.Add(label185);
			labels.Add(label186);

			actions = new List<int>();

			for (int i = 0; i < 8; i++)
			{
				actions.Add(0);
			}

			for (int i = 0; i < 184; i++)
			{
				labels[i].TextAlign = ContentAlignment.MiddleCenter;
				labels[i].AutoSize = false;
				labels[i].Dock = DockStyle.Fill;
				labels[i].Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
			}
		}

		private void AddAction(object sender, EventArgs e, Color color, string text, int actionType, int code)
		{
			int index = selected_process * 23 + actions[selected_process];
			panels[index].BackColor = color;
			labels[index].Text = int.Parse(text).ToString();
			panels[index].Visible = true;
			actions[selected_process] += 1;

			Panel1_VisibleChanged(sender, e);

			if (actions[selected_process] == 23)
				panel1.Visible = false;

			programms[index].Clear();
			programms[index].Add(actionType);
			programms[index].Add(int.Parse(text));
			programms[index].Add(code);
		}

		private void CheckReady(string name, string period, string number, Button readyButton)
		{
			if (name == "" || period == "" || number == "" || int.Parse(period) > 23 - actions[selected_process] || int.Parse(period) == 0)
				readyButton.Enabled = false;
			else
				readyButton.Enabled = true;
		}

		private void SelectProcess(int index)
		{
			selected_process = index;
			flowLayoutPanels[index].BackColor = Color.Aquamarine;
			button_DelProcess.Enabled = true;

			if (actions[selected_process] < 23)
				panel1.Visible = true;
		}

		private void UnselectProcess()
		{
			for (int i = 0; i < 8; i++)
			{
				if (flowLayoutPanels[i].BackColor == Color.Aquamarine)
				{
					flowLayoutPanels[i].BackColor = Color.AliceBlue;
				}
			}

			button_DelProcess.Enabled = false;
			panel1.Visible = false;
			selected_process = -1;
		}

		private void Button_AddProcess_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 23; i++)
			{
				panels[processes_number * 23 + i].Visible = false;
			}

			flowLayoutPanels[processes_number].Visible = true;
			processes_number += 1;

			if (processes_number == 8)
			{
				button_AddProcess.Enabled = false;
			}

			button_start.Enabled = true;
		}

		private void Button_DelProcess_Click(object sender, EventArgs e)
		{
			processes_number -= 1;

			if (selected_process < 8)
			{
				//ДОЛЖНО ПЕРЕДВИГАТЬСЯ СОДЕРЖИМОЕ
				flowLayoutPanels[selected_process].BackColor = flowLayoutPanels[selected_process + 1].BackColor;

				for (int i = selected_process; i < 7; i++)
				{
					bool state = flowLayoutPanels[i].Visible;
					flowLayoutPanels[i].Visible = false;

					for (int j = 0; j < actions[i]; j++)
					{
						panels[i * 23 + j].Visible = false;
					}

					for (int j = 0; j < actions[i + 1]; j++)
					{
						panels[i * 23 + j].BackColor = panels[i * 23 + 23 + j].BackColor;
						labels[i * 23 + j].Text = labels[i * 23 + 23 + j].Text;
						panels[i * 23 + j].Visible = panels[i * 23 + 23 + j].Visible;

						programms[i * 23 + j].Clear();

						for (int k = 0; k < 3; k++)
						{
							programms[i * 23 + j].Insert(k, programms[i * 23 + 23 + j].First());
							programms[i * 23 + 23 + j].RemoveAt(0);
						}
					}

					actions[i] = actions[i + 1];

					flowLayoutPanels[i].Visible = state;
				}

				if (processes_number == 0)
					button_start.Enabled = false;

			}

			UnselectProcess();
			flowLayoutPanels[processes_number].Visible = false;
			button_AddProcess.Enabled = true;
		}

		private void Button_start_Click(object sender, EventArgs e)
		{
            List<Command> program = new List<Command>();


            for (int i = 0; i < processes_number; i++)
            {
                for (int j = 0; j < actions[i]; j++)
                {
                    int commandCode = programms[i * 23 + j][0];
                    int pipeName = programms[i * 23 + j][1];
                    int specialCode = programms[i * 23 + j][2];
                    
                    programms[i * 23 + j].Clear();

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

            ModelForm p = new ModelForm();
            p.ShowDialog();

            OSystem.OS().Stop();
        }

		private void FlowLayoutPanel1_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(0);
		}

		private void FlowLayoutPanel2_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(1);
		}

		private void FlowLayoutPanel3_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(2);
		}

		private void FlowLayoutPanel4_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(3);
		}

		private void FlowLayoutPanel5_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(4);
		}

		private void FlowLayoutPanel6_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(5);
		}

		private void FlowLayoutPanel7_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(6);
		}

		private void FlowLayoutPanel8_Click(object sender, EventArgs e)
		{
			UnselectProcess();
			SelectProcess(7);
		}

		private void Panel1_VisibleChanged(object sender, EventArgs e)
		{
			groupBox_add.Visible = false;
			groupBox_del.Visible = false;
			groupBox_read.Visible = false;
			groupBox_write.Visible = false;
		}

		private void Button_addPipe_Click(object sender, EventArgs e)
		{
			Panel1_VisibleChanged(sender, e);
			groupBox_add.Visible = true;
			maskedTextBox1.Text = "";
			radioButton1.Select();
		}

		private void Button_delPipe_Click(object sender, EventArgs e)
		{
			Panel1_VisibleChanged(sender, e);
			groupBox_del.Visible = true;
			maskedTextBox2.Text = "";
		}

		private void Button_read_Click(object sender, EventArgs e)
		{
			Panel1_VisibleChanged(sender, e);
			groupBox_read.Visible = true;
			maskedTextBox3.Text = "";
			maskedTextBox8.Text = "";
			maskedTextBox7.Text = "";
		}

		private void Button_write_Click(object sender, EventArgs e)
		{
			Panel1_VisibleChanged(sender, e);
			groupBox_write.Visible = true;
			maskedTextBox4.Text = "";
			maskedTextBox5.Text = "";
			maskedTextBox6.Text = "";
		}

		private void MainForm_Click(object sender, EventArgs e)
		{
			UnselectProcess();
		}

		private void panel_Main_Click(object sender, EventArgs e)
		{
			UnselectProcess();
		}

		private void Button_addAction_Click(object sender, EventArgs e)
		{
			int type = 0;

			if (radioButton2.Checked)
				type = 1;
			else if (radioButton3.Checked)
				type = 2;

			AddAction(sender, e, Color.YellowGreen, maskedTextBox1.Text, 0, type);
		}

		private void Button_writeAction_Click(object sender, EventArgs e)
		{
			AddAction(sender, e, Color.IndianRed, maskedTextBox4.Text, 3, System.Int32.Parse(maskedTextBox6.Text));

			int n = System.Int32.Parse(maskedTextBox5.Text) - 1;

			for (int i = 0; i < n; i++)
			{
				AddAction(sender, e, Color.IndianRed, maskedTextBox4.Text, 3, 0);
			}
		}

		private void Button_readAction_Click(object sender, EventArgs e)
		{
			AddAction(sender, e, Color.LightBlue, maskedTextBox3.Text, 2, System.Int32.Parse(maskedTextBox7.Text));

			int n = System.Int32.Parse(maskedTextBox8.Text) - 1;

			for (int i = 0; i < n; i++)
			{
				AddAction(sender, e, Color.LightBlue, maskedTextBox3.Text, 2, 0);
			}
		}

		private void Button_delAction_Click(object sender, EventArgs e)
		{
			AddAction(sender, e, Color.SaddleBrown, maskedTextBox2.Text, 1, 0);
		}

		private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
		{
			button_addAction.Enabled = (maskedTextBox1.Text != "");
		}

		private void MaskedTextBox2_TextChanged(object sender, EventArgs e)
		{
			button_delAction.Enabled = (maskedTextBox2.Text != "");
		}

		private void MaskedTextBox4_TextChanged(object sender, EventArgs e)
		{
			CheckReady(maskedTextBox4.Text, maskedTextBox5.Text, maskedTextBox6.Text, button_writeAction);
		}

		private void MaskedTextBox5_TextChanged(object sender, EventArgs e)
		{
			CheckReady(maskedTextBox4.Text, maskedTextBox5.Text, maskedTextBox6.Text, button_writeAction);
		}

		private void MaskedTextBox6_TextChanged(object sender, EventArgs e)
		{
			CheckReady(maskedTextBox4.Text, maskedTextBox5.Text, maskedTextBox6.Text, button_writeAction);
		}

		private void MaskedTextBox3_TextChanged(object sender, EventArgs e)
		{
			CheckReady(maskedTextBox3.Text, maskedTextBox8.Text, maskedTextBox7.Text, button_readAction);
		}

		private void MaskedTextBox8_TextChanged(object sender, EventArgs e)
		{
			CheckReady(maskedTextBox3.Text, maskedTextBox8.Text, maskedTextBox7.Text, button_readAction);
		}

		private void MaskedTextBox7_TextChanged(object sender, EventArgs e)
		{
			CheckReady(maskedTextBox3.Text, maskedTextBox8.Text, maskedTextBox7.Text, button_readAction);
		}
	}
}
