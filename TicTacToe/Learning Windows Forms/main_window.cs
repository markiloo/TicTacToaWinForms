using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace main_window_methods
{
    public partial class main_window : Form
    {
        Random random = new Random();
        bool isPlayerTurn = true;
        string[] markers = { "X", "O" };

        public main_window()
        {
            InitializeComponent();
            isPlayerTurn = random.Next(0, 2) == 0;
            Turn_label.Text = "Current Turn: " + markers[isPlayerTurn ? 0:1];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Button> play_area = new List<Button> { box_1, box_2, box_3, box_4, box_5, box_6, box_7, box_8, box_9 };

            foreach (var box in play_area)
            {
                box.Enabled = true;
                box.Text = "?";
                box.BackColor = Color.LightGray;
            }
            win_label.Text = "...";
        }
        private void play_area_click(object sender, EventArgs e)
        {
            Button box_clicked = (Button)sender;

            if (isPlayerTurn)
            {
                box_clicked.Text = markers[isPlayerTurn ? 0 : 1];
                box_clicked.BackColor = Color.Aqua;
                
            }
            else if (isPlayerTurn == false)
            {
                box_clicked.Text = markers[isPlayerTurn ? 0 : 1];
                box_clicked.BackColor = Color.Red;   
            }

            Turn_label.Text = "Current Turn: " + markers[isPlayerTurn ? 1 : 0];

            check_win(markers[isPlayerTurn ? 0 : 1]);

            isPlayerTurn = !isPlayerTurn;
            box_clicked.Enabled = false;

        }

        private void check_win(string marker)
        {
            List<Button> play_area = new List<Button> { box_1, box_2, box_3, box_4, box_5, box_6, box_7, box_8, box_9 };

            bool HorizonalWin = (box_1.Text == marker && box_2.Text == marker && box_3.Text == marker) || (box_4.Text == marker && box_5.Text == marker && box_6.Text == marker) || (box_7.Text == marker && box_8.Text == marker && box_9.Text == marker);
            bool VerticalWin = (box_1.Text == marker && box_4.Text == marker && box_7.Text == marker) || (box_2.Text == marker && box_5.Text == marker && box_8.Text == marker) || (box_3.Text == marker && box_6.Text == marker && box_9.Text == marker);
            bool DiagonalWin = (box_5.Text == marker && box_1.Text == marker && box_9.Text == marker) || (box_5.Text == marker && box_3.Text == marker && box_7.Text == marker);

            if (HorizonalWin || VerticalWin || DiagonalWin)
            {
                foreach(Button button in play_area) 
                {
                    button.Enabled = false;
                    win_label.Text = marker + " Wins!";
                }
            }
        }


    }
}
