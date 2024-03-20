namespace TicTacToe
{
    
    public partial class Menu : Form
    {
        public string Difficulty;
        
        public Menu()
        {
            
            
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Player Vs Player
        {
            PlayerVPlayer form1 = new PlayerVPlayer();
            form1.Difficulty = "null";
            form1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) //View Lifetime Stats
        {

        }

        private void button2_Click(object sender, EventArgs e) // AI Easy
        {
            Difficulty = "Easy";
            PlayerVComputerEasy form1 = new PlayerVComputerEasy();
            form1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) //AI Medium
        {

        }

        private void button5_Click(object sender, EventArgs e) //AI Hard
        {

        }
    }
}
