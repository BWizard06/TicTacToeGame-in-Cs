using System;
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
                return System.Drawing.Color.Chartreuse;
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
                    scoreO++;
                    changeColor(one);
                    changeColor(two);
                    changeColor(three);
                    // MessageBox.Show($"{textBox2.Text} has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // title.Text = $"\n{textBox2.Text} won the last game";
                    history.AppendText(Environment.NewLine);
                    history.AppendText($"{textBox2.Text} won the {currentRound}. game");
                }
                else if(combination.Equals("XXX"))
                {
                    scoreX++;
                    changeColor(one);
                    changeColor(two);
                    changeColor(three);
                    // MessageBox.Show($"{textBox1.Text} has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // title.Text = $"\n{textBox1.Text} won the last game";
                    history.AppendText(Environment.NewLine);
                    history.AppendText($"{textBox1.Text} won the {currentRound}. game");
                }

                checkDraw();

                scoreBox.Text = "Score: " + Environment.NewLine + $"({textBox1.Text}) {scoreX} - {scoreO} ({textBox2.Text})";
            }
        }

        public void reset()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button1.BackColor = System.Drawing.Color.LightGray;
            button2.BackColor = System.Drawing.Color.LightGray;
            button3.BackColor = System.Drawing.Color.LightGray;
            button4.BackColor = System.Drawing.Color.LightGray;
            button5.BackColor = System.Drawing.Color.LightGray;
            button6.BackColor = System.Drawing.Color.LightGray;
            button7.BackColor = System.Drawing.Color.LightGray;
            button8.BackColor = System.Drawing.Color.LightGray;
            button9.BackColor = System.Drawing.Color.LightGray;
            gameBoard = new string[9];
            currentTurn = 0;
            currentRound++;
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

                if(counter == 9)
                {
                    // MessageBox.Show("It's a draw!", "We have no winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // history.Text = "Last game was a draw";
                    history.AppendText(Environment.NewLine);
                    history.AppendText($"\nGame {currentRound} was a Tie");
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[1] = returnSymbol(currentTurn);
            button2.Text = gameBoard[1];
            button2.BackColor = determineColor(gameBoard[1]);
            checkForWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[2] = returnSymbol(currentTurn);
            button3.Text = gameBoard[2];
            button3.BackColor = determineColor(gameBoard[2]);
            checkForWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[3] = returnSymbol(currentTurn);
            button4.Text = gameBoard[3];
            button4.BackColor = determineColor(gameBoard[3]);
            checkForWinner();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[4] = returnSymbol(currentTurn);
            button5.Text = gameBoard[4];
            button5.BackColor = determineColor(gameBoard[4]);
            checkForWinner();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[5] = returnSymbol(currentTurn);
            button6.Text = gameBoard[5];
            button6.BackColor = determineColor(gameBoard[5]);
            checkForWinner();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[6] = returnSymbol(currentTurn);
            button7.Text = gameBoard[6];
            button7.BackColor = determineColor(gameBoard[6]);
            checkForWinner();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[7] = returnSymbol(currentTurn);
            button8.Text = gameBoard[7];
            button8.BackColor = determineColor(gameBoard[7]);
            checkForWinner();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentTurn++;
            gameBoard[8] = returnSymbol(currentTurn);
            button9.Text = gameBoard[8];
            button9.BackColor = determineColor(gameBoard[8]);
            checkForWinner();
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
    }
}
