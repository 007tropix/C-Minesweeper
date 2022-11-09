using System.Security.Cryptography.X509Certificates;

namespace Minesweeper
{
    public partial class Form1 : Form
    {

        Cell[,] board = new Cell[10, 10];


        public Form1()
        {
            InitializeComponent();
            this.Text = "Minesweeper";
            InitBoard();
        }

       

        public void InitBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[col, row] = new Cell();
                    board[col, row].X = col;
                    board[col, row].Y = row;
                    board[col, row].Location = new Point(col * board[col, row].CellSize.Width, row * board[col, row].CellSize.Height);
                    this.Controls.Add(board[col, row]);
                    board[col, row].CellClick += OnCellClick;
                }
            }
        }

        public void OnCellClick(object ?sender, CellClickEventArgs e)
        {
            Color targetColor = board[e.Y, e.X].BackColor;
            if (e.X < board.GetLength(1) - 1)
            {
                if (board[e.X + 1, e.Y].BackColor == targetColor)
                {
                    board[e.X + 1, e.Y].PerformClick();
                }
            }
        }
        #region Menu Buttons
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELP HELP HELP");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game was coded by Ryan Du Plooy for CS 3020");
        }

        #endregion
    }
}