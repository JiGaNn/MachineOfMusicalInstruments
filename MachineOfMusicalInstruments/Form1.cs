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
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
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
            txtInfo.Text = "Струнные\tКлавишные\tУдарные\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", guitarCount, pianoCount, drumCount);
        }
    }
}
