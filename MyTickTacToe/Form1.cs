using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyTickTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            resetMatrix();
            ClearGame();
        }

        public enum VALUE
        {
            H = 0,
            A = 1,
            E = 2
        };

        const string H = "C:\\Users\\Admin\\source\\repos\\MyTickTacToe\\MyTickTacToe\\H.jpg";
        const string A = "C:\\Users\\Admin\\source\\repos\\MyTickTacToe\\MyTickTacToe\\A.jpg";
        
        private VALUE NextValue { get; set; }
        public int ACount = 0;
        public int HCount = 0;

        public const int WIDTH = 3;
        public const int HEIGHT = 3;
        public int[,] matrix = new int[WIDTH, HEIGHT];
        private bool WeHaveAWinner = false;

        private void ClearGame()
        {
            ACount = 0;
            HCount = 0;

            button1.Image = null;
            button1.Tag = VALUE.E;
            button2.Image = null;
            button2.Tag = VALUE.E;
            button3.Image = null;
            button3.Tag = VALUE.E;
            button4.Image = null;
            button4.Tag = VALUE.E;
            button5.Image = null;
            button5.Tag = VALUE.E;
            button6.Image = null;
            button6.Tag = VALUE.E;
            button7.Image = null;
            button7.Tag = VALUE.E;
            button8.Image = null;
            button8.Tag = VALUE.E;
            button9.Image = null;
            button9.Tag = VALUE.E;

            button10.BackColor = SystemColors.Control;
            button10.Text = "";
            NextValue = VALUE.H;
            WeHaveAWinner = false;
            resetMatrix();
        }

        private void resetMatrix()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = int.MaxValue;
                }
            }
        }

        private void BGSwitcher(Button button, int i, int j)
        {
            if (WeHaveAWinner)
            {
                string message = "We already have a Winner!";
                string caption = "Start New Game";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                return;
            }

            if (button10.Text == "")
            {
                button10.Text = "Start New Game?";
            }
            if (button.Image == null)
            {
                switch (NextValue)
                {
                    case VALUE.A:
                        button.Image = Image.FromFile(A);
                        matrix[i, j] = (int)VALUE.A;
                        ACount++;
                        button.Tag = VALUE.A;
                        NextValue = VALUE.H;
                        break;
                    case VALUE.H:
                        button.Image = Image.FromFile(H);
                        matrix[i, j] = (int)VALUE.H;
                        HCount++;
                        button.Tag = VALUE.H;
                        NextValue = VALUE.A;
                        break;
                }
            }
           
            if ( ACount >=3 || HCount >=3)
            {
                Check(i,j);
            }
        }

        private void Check(int ii, int jj)
        {
            for (var i=0; i<WIDTH; ++i)
            {
                var vhcount = 0;
                var vacount = 0;
                for (var j = 0; j <HEIGHT; ++j)
                {
                    if (matrix[i, j] == (int)(VALUE.A))
                    {
                        vacount++;
                    }
                    else if (matrix[i, j] == (int)(VALUE.H))
                    {
                        vhcount++;
                    }
                }

                if (vacount == 3)
                {
                    AnnounceWinner("A is the WINNER!");
                    return;
                }
                if (vhcount == 3)
                {
                    AnnounceWinner("H is the WINNER!");
                    return;
                }
            }

            for (var i = 0; i < WIDTH; ++i)
            {
                var vhcount = 0;
                var vacount = 0;
                for (var j = 0; j < HEIGHT; ++j)
                {
                    if (matrix[j, i] == (int)(VALUE.A))
                    {
                        vacount++;
                    }
                    else if (matrix[j, i] == (int)(VALUE.H))
                    {
                        vhcount++;
                    }
                }

                if (vacount == 3)
                {
                    AnnounceWinner("A is the WINNER!");
                    return;
                }
                if (vhcount == 3)
                {
                    AnnounceWinner("H is the WINNER!");
                    return;
                }
            }

            if ( matrix[0,0] == matrix[1,1] && matrix[1,1] == matrix[2,2])
            {
                if (matrix[0,0] == (int)(VALUE.A))
                {
                    AnnounceWinner("A is the WINNER!");
                }
                else
                {
                    AnnounceWinner("H is the WINNER!");
                }
            }

            if (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0])
            {
                if (matrix[0, 0] == (int)(VALUE.A))
                {
                    AnnounceWinner("A is the WINNER!");
                }
                else
                {
                    AnnounceWinner("H is the WINNER!");
                }
            }

        }

        public void AnnounceWinner(string winner)
        {
            button10.BackColor = Color.Red;
            button10.Text = String.Concat(winner, "           Start New Game?         ", winner);
            WeHaveAWinner = true;
        }
        
        private void ButtonReset (Button button)
        {
            if ( button.Tag.Equals(VALUE.A))
            {
                ACount--;
            }
            else if (button.Tag.Equals(VALUE.H))
            {
                HCount--;
            }

            button.Image = null;
            button.Tag = VALUE.E;
        }
      

        private void button10_Click(object sender, EventArgs e)
        {
            ClearGame();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button1);
            }
            else
            {
                BGSwitcher(button1,0,0);
            }
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button2);
            }
            else
            {
                BGSwitcher(button2,1,0);
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button3);
            }
            else
            {
                BGSwitcher(button3,2,0);
            }
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button4);
            }
            else
            {
                BGSwitcher(button4,0,1);
            }
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button5);
            }
            else
            {
                BGSwitcher(button5,1,1);
            }
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button6);
            }
            else
            {
                BGSwitcher(button6,2,1);
            }
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button7);
            }
            else
            {
                BGSwitcher(button7,0,2);
            }
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button8);
            }
            else
            {
                BGSwitcher(button8,1,2);
            }
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ButtonReset(button9);
            }
            else
            {
                BGSwitcher(button9,2,2);
            }
        }
    }
}
