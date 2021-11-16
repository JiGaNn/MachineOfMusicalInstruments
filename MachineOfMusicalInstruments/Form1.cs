using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineOfMusicalInstruments
{
    public partial class Form1 : Form
    {
        List<MusInst> musInst = new List<MusInst>();
        private string queue = "";
        private void tb_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        public Form1()
        {
            InitializeComponent();
            ShowInfo();

            btnRefill.KeyUp += tb_KeyUp;
        }
        private void ShowInfo()
        {
            int guitarCount = 0;
            int pianoCount = 0;
            int drumCount = 0;

            foreach(var inst in this.musInst)
            {
                if (inst is Guitar)
                    guitarCount++;
                if (inst is Piano)
                    pianoCount++;
                if (inst is Drum)
                    drumCount++;
            }
            txtInfo.Text = "Гитары\t\tРояли\t\tБарабаны\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", guitarCount, pianoCount, drumCount);
            txtInfo.Text += "\n\nОчередь:";
            txtInfo.Text += queue;
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            queue = "";
            btnGet.KeyUp -= tb_KeyUp;
            musInst.Clear();
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next() % 3)
                {
                    case 0:
                        musInst.Add(Guitar.Generate());
                        queue += " Г";
                        break;
                    case 1:
                        musInst.Add(Piano.Generate());
                        queue += " Р";
                        break;
                    case 2:
                        musInst.Add(Drum.Generate());
                        queue += " Б";
                        break;
                }
            }
            ShowInfo();
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (musInst.Count == 0)
            {
                txtOut.Text = "Пусто O_o";
                pictureBox1.Visible = false;
                btnGet.KeyUp += tb_KeyUp;
                return;
            }
            pictureBox1.Visible = true;
            var musI = musInst[0];
            musInst.RemoveAt(0);
            queue = queue.Substring(2);
            txtOut.Text = musI.GetInfo();
            pictureBox1.Image = musI.img;
            ShowInfo();
        }
    }
}
