﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] gameBoard = new string[9];
        int currentTurn = 0;
        

        int currentRound = 1;

        int scoreX = 0;
        int scoreO = 0;

        // A variable to check if somebody wins on the last turn.
        int notDraw = 0;

        public String returnSymbol(int turn)
        {
            if( turn % 2 == 0)
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }

        public System.Drawing.Color determineColor(String symbol)
        {
            if(symbol.Equals("O"))
            {
                return System.Drawing.Color.LightBlue;
            }
            else if(symbol.Equals("X"))
            {
                return System.Drawing.Color.LightGreen;
            }
            return System.Drawing.Color.LightGray;
        }

        public void checkForWinner()
        {
            for(int i=0; i<8; i++)
            {
                String combination = "";
                int one=0, two=0, three=0;

                switch (i)
                {
                    case 0:
                        combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
                        one = 0;
                        two = 4;
                        three = 8;
                        break;
                    case 1:
                        combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
                        one = 2;
                        two = 4;
                        three = 6;
                        break; 
                    case 2:
                        combination = gameBoard[0] + gameBoard[1] + gameBoard[2];
                        one = 0;
                        two = 1;
                        three = 2;
                        break;
                    case 3:
                        combination = gameBoard[3] + gameBoard[4] + gameBoard[5];
                        one = 3;
                        two = 4;
                        three = 5;
                        break;
                    case 4:
                        combination = gameBoard[6] + gameBoard[7] + gameBoard[8];
                        one = 6;
                        two = 7;
                        three = 8;
                        break;
                    case 5:
                        combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
                        one = 0;
                        two = 3;
                        three = 6;
                        break;
                    case 6:
                        combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
                        one = 1;
                        two = 4;
                        three = 7;
                        break;
                    case 7:
                        combination = gameBoard[2] + gameBoard[5] + gameBoard[8];
                        one = 2;
                        two = 5;
                        three = 8;
                        break;
                }

                if (combination.Equals("OOO"))
                {
                    foreach (Control x in this.Controls)
                    {
                        if (x is Button && x.Text == "")
                        {
                            x.Enabled = false;
                        }
                    }
                    notDraw = 1;
                    scoreO++;
                    changeColor(one);
                    changeColor(two);
                    changeColor(three);
                    history.AppendText(Environment.NewLine);
                    history.AppendText($"{textBox2.Text} won the {currentRound}. game");
                }
                else if (combination.Equals("XXX"))
                {
                    foreach (Control x in this.Controls)
                    {
                        if (x is Button && x.Text == "")
                        {
                            x.Enabled = false;
                        }
                    }
                    notDraw = 1;
                    scoreX++;
                    // Change color to red from every winner button
                    changeColor(one);
                    changeColor(two);
                    changeColor(three);
                    history.AppendText(Environment.NewLine);
                    history.AppendText($"{textBox1.Text} won the {currentRound}. game");
                }
                scoreBox.Text = "Score: " + Environment.NewLine + $"({textBox1.Text}) {scoreX} - {scoreO} ({textBox2.Text})";
            }
            // outside of for loop so it doesn't repeat itself
            checkDraw();

        }

        public void reset()
        {
            foreach(Control x in this.Controls)
            {
                if (x is Button && (x.Text == "X" | x.Text == "O"))
                {
                    x.Enabled = true;
                    x.Text = "";
                    x.BackColor = Color.LightGray;
                }
            }
            // button1.Text = "";
            // button2.Text = "";
            // button3.Text = "";
            // button4.Text = "";
            // button5.Text = "";
            // button6.Text = "";
            // button7.Text = "";
            // button8.Text = "";
            // button9.Text = "";
            // button1.BackColor = System.Drawing.Color.LightGray;
            // button2.BackColor = System.Drawing.Color.LightGray;
            // button3.BackColor = System.Drawing.Color.LightGray;
            // button4.BackColor = System.Drawing.Color.LightGray;
            // button5.BackColor = System.Drawing.Color.LightGray;
            // button6.BackColor = System.Drawing.Color.LightGray;
            // button7.BackColor = System.Drawing.Color.LightGray;
            // button8.BackColor = System.Drawing.Color.LightGray;
            // button9.BackColor = System.Drawing.Color.LightGray;
            // button1.Enabled = true;
            // button2.Enabled = true;
            // button3.Enabled = true;
            // button4.Enabled = true;
            // button5.Enabled = true;
            // button6.Enabled = true;
            // button7.Enabled = true;
            // button8.Enabled = true;
            // button9.Enabled = true;
            gameBoard = new string[9];
            currentTurn = 0;
            currentRound++;
            notDraw = 0;
        }

        public void changeColor( int number)
        {
            switch (number)
            {
                case 0:
                    button1.BackColor = System.Drawing.Color.Red; 
                    break;
                case 1:
                    button2.BackColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    button3.BackColor = System.Drawing.Color.Red;
                    break;
                case 3:
                    button4.BackColor = System.Drawing.Color.Red;
                    break;
                case 4:
                    button5.BackColor = System.Drawing.Color.Red;
                    break;
                case 5:
                    button6.BackColor = System.Drawing.Color.Red;
                    break;
                case 6:
                    button7.BackColor = System.Drawing.Color.Red;
                    break;
                case 7:
                    button8.BackColor = System.Drawing.Color.Red;
                    break;
                case 8:
                    button9.BackColor = System.Drawing.Color.Red;
                    break;
            }
        }

        public void checkDraw()
        {
            int counter = 0;

            for(int i=0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] != null)
                {
                    counter++;
                }
                if (counter == 9 && notDraw == 0)
                {
                    // MessageBox.Show("It's a draw!", "We have no winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // history.Text = "Last game was a draw";
                    history.AppendText(Environment.NewLine);
                    history.AppendText($"Game {currentRound} was a Tie");
                }
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[0] = returnSymbol(currentTurn);
            button1.Text = gameBoard[0];
            button1.BackColor = determineColor(gameBoard[0]);
            checkForWinner();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[1] = returnSymbol(currentTurn);
            button2.Text = gameBoard[1];
            button2.BackColor = determineColor(gameBoard[1]);
            checkForWinner();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[2] = returnSymbol(currentTurn);
            button3.Text = gameBoard[2];
            button3.BackColor = determineColor(gameBoard[2]);
            checkForWinner();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[3] = returnSymbol(currentTurn);
            button4.Text = gameBoard[3];
            button4.BackColor = determineColor(gameBoard[3]);
            checkForWinner();
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[4] = returnSymbol(currentTurn);
            button5.Text = gameBoard[4];
            button5.BackColor = determineColor(gameBoard[4]);
            checkForWinner();
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[5] = returnSymbol(currentTurn);
            button6.Text = gameBoard[5];
            button6.BackColor = determineColor(gameBoard[5]);
            checkForWinner();
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[6] = returnSymbol(currentTurn);
            button7.Text = gameBoard[6];
            button7.BackColor = determineColor(gameBoard[6]);
            checkForWinner();
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[7] = returnSymbol(currentTurn);
            button8.Text = gameBoard[7];
            button8.BackColor = determineColor(gameBoard[7]);
            checkForWinner();
            button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[8] = returnSymbol(currentTurn);
            button9.Text = gameBoard[8];
            button9.BackColor = determineColor(gameBoard[8]);
            checkForWinner();
            button9.Enabled = false;
        }

        private void history_MouseHover(object sender, EventArgs e)
        {
            history.Size = new Size(464, 200);
        }

        private void history_MouseLeave(object sender, EventArgs e)
        {
            history.Size = new Size(464, 33);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currentRound = 1;
            scoreX = 0;
            scoreO = 0;
            scoreBox.Text = "Score: " + Environment.NewLine + $"({textBox1.Text}) {scoreX} - {scoreO} ({textBox2.Text})";
            history.Clear();
            history.Text = "History";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            currentRound = 1;
            scoreX = 0;
            scoreO = 0;
            scoreBox.Text = "Score: " + Environment.NewLine + $"({textBox1.Text}) {scoreX} - {scoreO} ({textBox2.Text})";
            history.Clear();
            history.Text = "History";
        }

        private void changeNameButton_Click(object sender, EventArgs e)
        { 
            string currentNamePlayer1 = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = currentNamePlayer1;
        }
    }
}
