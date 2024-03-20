using System.Security.Cryptography.X509Certificates;

namespace TicTacToe
{
    public partial class PlayerVPlayer : Form
    {
        private string[,] Board = new string[3, 3];
        private string Player = "";
        private int Size = 3;
        private LineTotals lineTotals = new LineTotals();
        Player Player1 = new Player();
        Player Player2 = new Player();
        private int MovesTaken = 0;
        public string Difficulty { get; set; }

        public PlayerVPlayer()
        { 
            InitializeComponent();
            setBoard(Size, Board);
            if (this.Difficulty == "null")
                startPlayer(Player);
            else
            {
                Player1.IsPlayerTurn = true;
                Player2.IsPlayerTurn = false;
            }
            label1.Text = this.Difficulty;
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

        private void  startPlayer(string Player)
        {
            Random Random = new Random();
            int randint = Random.Next(0, 10);
            if (randint % 2 == 0)
            {
                Player = "1";
                Player1.IsPlayerTurn = true;
                Player2.IsPlayerTurn = false;
            }
            else
            {
                Player = "2";
                Player1.IsPlayerTurn = false;
                Player2.IsPlayerTurn = true;
            }

        }

        private bool isWin(LineTotals lineTotals)
        {

            MovesTaken++;

            string CurrentPlayer = Player1.IsPlayerTurn ? "1" : "2";

            if (lineTotals.Column1 == 3 || lineTotals.Column1 == -3 || lineTotals.Column2 == 3 || lineTotals.Column2 == -3 ||  lineTotals.Column3 == 3 || lineTotals.Column3 == -3)
            {
                if (CurrentPlayer == "1")
                {
                    Player1.Score++;
                    ScoreLabel1.Text = $"Player 1 Score: {Player1.Score}";
                }
                else
                {
                    Player2.Score++;
                    ScoreLabel2.Text = $"Player 2 Score: {Player2.Score}";
                }
                return true;
            }

            if (lineTotals.Row1 == 3 || lineTotals.Row1 == -3 || lineTotals.Row2 == 3 || lineTotals.Row2 == -3 || lineTotals.Row3 == 3 || lineTotals.Row3 == -3)
            {
                if (CurrentPlayer == "1")
                {
                    Player1.Score++;
                    ScoreLabel1.Text = $"Player 1 Score: {Player1.Score}";
                }
                else
                {
                    Player2.Score++;
                    ScoreLabel2.Text = $"Player 2 Score: {Player2.Score}";
                }
                return true;
            }

            if (lineTotals.Diag1 == 3 || lineTotals.Diag1 == -3 || lineTotals.Diag2 == 3 || lineTotals.Diag2 == -3)
            {
                if (CurrentPlayer == "1")
                {
                    Player1.Score++;
                    ScoreLabel1.Text = $"Player 1 Score: {Player1.Score}";
                }
                else
                {
                    Player2.Score++;
                    ScoreLabel2.Text = $"Player 2 Score: {Player2.Score}";
                }
                return true;
            }
            else if (MovesTaken == 9)
                return true;

            return false;
        }

        private void playerChange()
        {
            if (Player1.IsPlayerTurn)
            {
                Player1.IsPlayerTurn = false;
                Player2.IsPlayerTurn = true;
                label1.Text = "Player 2";
            }
            else
            {
                Player1.IsPlayerTurn = true;
                Player2.IsPlayerTurn = false;
                label1.Text = "Player 1";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) //top left
        {
            if (Board[0, 0] == " ")
            {
                Button7();


                button7.Text = Board[0, 0];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }

        private void Button7()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[0, 0] = "X";
                lineTotals.Row1 += 1;
                lineTotals.Column1 += 1;
                lineTotals.Diag1 += 1;

            }
            else
            {
                Board[0, 0] = "0";
                lineTotals.Row1 -= 1;
                lineTotals.Column1 -= 1;
                lineTotals.Diag1 -= 1;
            }
        }

        private void button8_Click(object sender, EventArgs e) //top mid
        {
            if (Board[0, 1] == " ")
            {
                Button8();


                button8.Text = Board[0, 1];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }

        private void Button8()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[0, 1] = "X";
                lineTotals.Row1 += 1;
                lineTotals.Column2 += 1;
            }
            else
            {
                Board[0, 1] = "0";
                lineTotals.Row1 -= 1;
                lineTotals.Column2 -= 1;
            }
        }

        private void button9_Click(object sender, EventArgs e) //top right
        {
            if (Board[0, 2] == " ")
            {
                Button9();


                button9.Text = Board[0, 2];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }

        private void Button9()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[0, 2] = "X";
                lineTotals.Row1 += 1;
                lineTotals.Column3 += 1;
                lineTotals.Diag2 += 1;
            }
            else
            {
                Board[0, 2] = "0";
                lineTotals.Row1 -= 1;
                lineTotals.Column3 -= 1;
                lineTotals.Diag2 -= 1;
            }
        }

        private void button4_Click(object sender, EventArgs e) //middle left
        {
            if (Board[1, 0] == " ")
            {
                Button4();


                button4.Text = Board[1, 0];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }

        private void Button4()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[1, 0] = "X";
                lineTotals.Row2 += 1;
                lineTotals.Column1 += 1;
            }
            else
            {
                Board[1, 0] = "0";
                lineTotals.Row2 -= 1;
                lineTotals.Column1 -= 1;
            }
        }

        private void button5_Click(object sender, EventArgs e) //middle middle
        {
            if (Board[1, 1] == " ")
            {
                Button5();

                button5.Text = Board[1, 1];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        
        }

        private void Button5()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[1, 1] = "X";
                lineTotals.Column2 += 1;
                lineTotals.Row2 += 1;
                lineTotals.Diag1 += 1;
                lineTotals.Diag2 += 1;
            }
            else
            {
                Board[1, 1] = "0";
                lineTotals.Column2 -= 1;
                lineTotals.Row2 -= 1;
                lineTotals.Diag1 -= 1;
                lineTotals.Diag2 -= 1;
            }
        }

        private void button6_Click(object sender, EventArgs e) //middle right
        {
            if (Board[1, 2] == " ")
            {
                Button6();

                button6.Text = Board[1, 2];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }

        private void Button6()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[1, 2] = "X";
                lineTotals.Column3 += 1;
                lineTotals.Row2 += 1;
            }
            else
            {
                Board[1, 2] = "0";
                lineTotals.Column3 -= 1;
                lineTotals.Row2 -= 1;
            }
        }

        private void button1_Click(object sender, EventArgs e) //bottom left
        {
            if (Board[2, 0] == " ")
            {
                Button1();

                button1.Text = Board[2, 0];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }


        private void Button1()
        {
            if (this.Difficulty == "null")
            {
                if (Player1.IsPlayerTurn == true)
                {
                    Board[2, 0] = "X";
                    lineTotals.Row3 += 1;
                    lineTotals.Column1 += 1;
                    lineTotals.Diag2 += 1;
                }
                else
                {
                    Board[2, 0] = "0";
                    lineTotals.Row3 -= 1;
                    lineTotals.Column1 -= 1;
                    lineTotals.Diag2 -= 1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //bottom middle
        {
            if (Board[2, 1] == " ")
            {
                Button2();

                button2.Text = Board[2, 1];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);

                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else
                    playerChange();
            }
        }

        private void Button2()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[2, 1] = "X";
                lineTotals.Column2 += 1;
                lineTotals.Row3 += 1;
            }
            else
            {
                Board[2, 1] = "0";
                lineTotals.Column2 -= 1;
                lineTotals.Row3 -= 1;
            }
        }

        private void button3_Click(object sender, EventArgs e) //bottom right
        {
            if (Board[2, 2] == " ")
            {
                Button3();

                button3.Text = Board[2, 2];

                if (isWin(lineTotals))
                {
                    setBoard(Size, Board);
                }

                if (this.Difficulty != "null")
                {
                    ComputerTurn();
                }
                else 
                    playerChange();
            }
        }

        private void Button3()
        {
            if (Player1.IsPlayerTurn == true)
            {
                Board[2, 2] = "X";
                lineTotals.Column3 += 1;
                lineTotals.Row3 += 1;
                lineTotals.Diag1 += 1;
            }
            else
            {
                Board[2, 2] = "0";
                lineTotals.Column3 -= 1;
                lineTotals.Row3 -= 1;
                lineTotals.Diag1 -= 1;
            }
        }

        private void ComputerTurn()
        {
            ComputerMoveEasy();
        }

        private void ComputerMoveEasy()
        {
            bool Complete = false;
            do
            {
                Random random = new Random();
                int randrow = random.Next(0, 2);
                int randcol = random.Next(0, 2);
                if (Board[randrow, randcol] == " ")
                {
                    switch (randrow)
                    {
                        case 0:
                            switch (randcol)
                            {
                                case 0:
                                    Button7();
                                    break;
                                case 1:
                                    Button8();
                                    break;
                                case 2:
                                    Button9();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 1:
                            switch (randcol)
                            {
                                case 0:
                                    Button4();
                                    break;
                                case 1:
                                    Button5();
                                    break;
                                case 2:
                                    Button6();
                                    break;
                                default:

                                    break;
                            }
                            break;
                        case 2:
                            switch (randcol)
                            {
                                case 0:
                                    Button1();
                                    break;
                                case 1:
                                    Button2();
                                    break;
                                case 2:
                                    Button3();
                                    break;
                                default:

                                    break;
                            }
                            break;

                        default:

                            break;
                    } //activate correct square logic 
                    Complete = true;
                }
            } while (Complete == false);
        }
    }
}
