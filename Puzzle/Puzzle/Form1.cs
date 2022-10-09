﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int movesNumber = 0, labelIndex = 0;
        //esta opcion es para crear numeros ramdon 
        public void shuffleButtons()
        {
            List<int> labelList = new List<int>();
            Random rand = new Random();
            foreach(Button btn in this.groupBox1.Controls)
            {
                while(labelList.Contains(labelIndex))
                    labelIndex=rand.Next(16);

                btn.Text = (labelIndex == 0) ? "" : labelIndex + "";
                btn.BackColor = (btn.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLight);
                labelList.Add(labelIndex);
            }
            movesNumber = 0;
            btnNumMovents.Text="Numero de movimientos: "+movesNumber;

        }
        //este metodo sirve para mover los numeros
        private void swaplabel1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
                return;

            Button whiteBtn = null;
            foreach (Button bt in this.groupBox1.Controls)
            {
                if (bt.Text == "")
                {
                    whiteBtn = bt;
                    break;
                }
            }

            if (btn.TabIndex == (whiteBtn.TabIndex - 1) ||
                btn.TabIndex == (whiteBtn.TabIndex - 4) ||
                btn.TabIndex == (whiteBtn.TabIndex + 1) ||
                btn.TabIndex == (whiteBtn.TabIndex + 4))
            {
                whiteBtn.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btn.BackColor = Color.White;
                whiteBtn.Text = btn.Text;
                btn.Text = "";
                movesNumber++;
                btnNumMovents.Text = "Numero de movimientos : " + movesNumber;
            }
            checkOrder();
        }
        //aqui miro si estan en orden para decir que gan
        private void checkOrder()
        {
            int index = 0;
            foreach (Button btn in this.groupBox1.Controls)
            {
                if (btn.Text != "" && Convert.ToInt16(btn.Text) != index)
                {
                    return;

                }

                index++;
            }

            MessageBox.Show("Ganaste con este numero de " + movesNumber + " movimientos");
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            shuffleButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shuffleButtons();

        }
    }
}
