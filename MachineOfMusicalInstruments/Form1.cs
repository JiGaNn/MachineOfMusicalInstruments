﻿using System;
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
        private void btnRefill_Click(object sender, EventArgs e)
        {
            musInst.Clear();
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next() % 3)
                {
                    case 0:
                        musInst.Add(new Guitar());
                        break;
                    case 1:
                        musInst.Add(new Piano());
                        break;
                    case 2:
                        musInst.Add(new Drum());
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
                return;
            }
            var musI = musInst[0];
            musInst.RemoveAt(0);
            txtOut.Text = musI.GetInfo();
            ShowInfo();
        }
    }
}
