using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class PlayerVComputerEasy : Form
    {
        Random random = new Random();
        private string[,] Board = new string[3, 3];
        private int Size = 3;
        private string Player = "";
        private LineTotals lineTotals = new LineTotals();
        Player Player1 = new Player();
        Player Player2 = new Player();
        private int MovesTaken = 0;
        public PlayerVComputerEasy()
        {
            InitializeComponent();
        }
        private bool isWin(LineTotals lineTotals)
        {

            MovesTaken++;

            string CurrentPlayer = Player1.IsPlayerTurn ? "1" : "2";

            if (lineTotals.Column1 == 3 || lineTotals.Column2 == 3 || lineTotals.Column3 == 3)
            {
                Player1.Score++;
                ScoreLabel1.Text = "Player 1 Score: " + Player1.Score;
                return true;
                setBoard(Size, Board);
            }
            else if (lineTotals.Row1 == 3 || lineTotals.Row2 == 3 || lineTotals.Row3 == 3)
            {
                Player1.Score++;
                ScoreLabel1.Text = "Player 1 Score: " + Player1.Score;
                return true;
                setBoard(Size, Board);
            }
            else if (lineTotals.Diag1 == 3 || lineTotals.Diag2 == 3)
            {
                Player1.Score++;
                ScoreLabel1.Text = "Player 1 Score: " + Player1.Score;
                return true;
                setBoard(Size, Board);
            }
            else if (lineTotals.Column1 == -3 || lineTotals.Column2 == -3 || lineTotals.Column3 == -3)
            {
                Player2.Score++;
                ScoreLabel2.Text = "Player 2 Score: " + Player2.Score;
                return true;
                setBoard(Size, Board);
            }
            else if (lineTotals.Row1 == -3 || lineTotals.Row2 == -3 || lineTotals.Row3 == -3)
            {
                Player2.Score++;
                ScoreLabel2.Text = "Player 2 Score: " + Player2.Score;
                return true;
                setBoard(Size, Board);
            }
            else if (lineTotals.Diag1 == -3 || lineTotals.Diag2 == -3)
            {
                Player2.Score++;
                ScoreLabel2.Text = "Player 2 Score: " + Player2.Score;
                return true;
                setBoard(Size, Board);
            }
            else if (MovesTaken == 9)
            {
                return true;
                setBoard(Size, Board);
            }
            else
                return false;
            
        }
        private void setBoard(int Size, string[,] board)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j] = " ";
                }
            }

            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
            button4.Text = " ";
            button5.Text = " ";
            button6.Text = " ";
            button7.Text = " ";
            button8.Text = " ";
            button9.Text = " ";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            lineTotals.Row1 = 0;
            lineTotals.Row2 = 0;
            lineTotals.Row3 = 0;
            lineTotals.Column1 = 0;
            lineTotals.Column2 = 0;
            lineTotals.Column3 = 0;
            lineTotals.Diag1 = 0;
            lineTotals.Diag2 = 0;
            MovesTaken = 0;
        }
        private Button GetButtonByNumber(int buttonNumber)
        {
            switch (buttonNumber)
            {
                case 1:
                    return button1;
                case 2:
                    return button2;
                case 3:
                    return button3;
                case 4:
                    return button4;
                case 5:
                    return button5;
                case 6:
                    return button6;
                case 7:
                    return button7;
                case 8:
                    return button8;
                case 9:
                    return button9;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buttonNumber), "Invalid button number.");
            }
        }

        private void ComputerMove()
        {
            int randbutton;
            do
            {
                randbutton = random.Next(1, 10);
            } while (!GetButtonByNumber(randbutton).Enabled);

            switch (randbutton)
                {
                    case 1:
                        Board[2, 0] = "0";
                        lineTotals.Row3 -= 1;
                        lineTotals.Column1 -= 1;
                        lineTotals.Diag2 -= 1;
                        button1.Enabled = false;
                        button1.Text = "0";
                        break;

                    case 2:
                        Board[2, 1] = "0";
                        lineTotals.Column2 -= 1;
                        lineTotals.Row3 -= 1;
                        button2.Enabled = false;
                        button2.Text = "0";
                        break;

                    case 3:
                        Board[2, 2] = "0";
                        lineTotals.Column3 -= 1;
                        lineTotals.Row3 -= 1;
                        lineTotals.Diag1 -= 1;
                        button3.Enabled = false;
                        button3.Text = "0";
                        break;

                    case 4:
                        Board[1, 0] = "0";
                        lineTotals.Row2 -= 1;
                        lineTotals.Column1 -= 1;
                        button4.Enabled = false;
                        button4.Text = "0";
                        break;

                    case 5:
                        Board[1, 1] = "0";
                        lineTotals.Column2 -= 1;
                        lineTotals.Row2 -= 1;
                        lineTotals.Diag1 -= 1;
                        lineTotals.Diag2 -= 1;
                        button5.Enabled = false;
                        button5.Text = "0";
                        break;

                    case 6:
                        Board[1, 2] = "0";
                        lineTotals.Column3 -= 1;
                        lineTotals.Row2 -= 1;
                        button6.Enabled = false;
                        button6.Text = "0";
                        break;

                     case 7:
                        Board[0, 0] = "0";
                        lineTotals.Row1 -= 1;
                        lineTotals.Column1 -= 1;
                        lineTotals.Diag1 -= 1;
                        button7.Enabled = false;
                        button7.Text = "0";
                        break;

                     case 8:
                        Board[0, 1] = "0";
                        lineTotals.Row1 -= 1;
                        lineTotals.Column2 -= 1;
                        button8.Enabled = false;
                        button8.Text = "0";
                        break;

                    case 9:
                        Board[0, 2] = "0";
                        lineTotals.Row1 -= 1;
                        lineTotals.Column3 -= 1;
                        lineTotals.Diag2 -= 1;
                        button9.Enabled = false;
                        button9.Text = "0";
                        break;

                    default:
                        break;
                }
            if (isWin(lineTotals))
                setBoard(Size, Board);

        }

        private void PlayerMove(string Row, string Column)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Board[2, 0] = "X";
            lineTotals.Row3 += 1;
            lineTotals.Column1 += 1;
            lineTotals.Diag2 += 1;
            button1.Enabled = false;
            button1.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);


                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Board[2, 1] = "X";
            lineTotals.Column2 += 1;
            lineTotals.Row3 += 1;
            button2.Enabled = false;
            button2.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Board[2, 2] = "X";
            lineTotals.Column3 += 1;
            lineTotals.Row3 += 1;
            lineTotals.Diag1 += 1;
            button3.Enabled = false;
            button3.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Board[1, 0] = "X";
            lineTotals.Row2 += 1;
            lineTotals.Column1 += 1;
            button4.Enabled = false;
            button4.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Board[1, 1] = "X";
            lineTotals.Column2 += 1;
            lineTotals.Row2 += 1;
            lineTotals.Diag1 += 1;
            lineTotals.Diag2 += 1;
            button5.Enabled = false;
            button5.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Board[1, 2] = "X";
            lineTotals.Column3 += 1;
            lineTotals.Row2 += 1;
            button6.Enabled = false;
            button6.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Board[0, 0] = "X";
            lineTotals.Row1 += 1;
            lineTotals.Column1 += 1;
            lineTotals.Diag1 += 1;
            button7.Enabled = false;
            button7.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Board[0, 1] = "X";
            lineTotals.Row1 += 1;
            lineTotals.Column2 += 1;
            button8.Enabled = false;
            button8.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Board[0, 2] = "X";
            lineTotals.Row1 += 1;
            lineTotals.Column3 += 1;
            lineTotals.Diag2 += 1;
            button9.Enabled = false;
            button9.Text = "X";
            if (!isWin(lineTotals))
                ComputerMove();
            else
                setBoard(Size, Board);
        }
    }
}
