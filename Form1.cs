using System.Security.Cryptography.X509Certificates;

namespace Minesweeper
{
    public partial class Form1 : Form
    {

        Cell[,] board = new Cell[10, 10];
        Random random = new Random();
        int numClicks = 0;
        int elapsedTime = 0;


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
                    board[col, row].Location = new Point(col * board[col, row].CellSize.Width, (row * board[col, row].CellSize.Height) + theMenuStrip.Size.Height);
                    this.Controls.Add(board[col, row]);
                    board[col, row].CellClick += OnCellClick;
                }
            }
        }

        public void OnCellClick(object ?sender, CellClickEventArgs e)
        {
            numClicks++;
            if (numClicks == 1)
            {
                //MessageBox.Show("FIRST CLICK");
                GenerateMines(e.X, e.Y);
                GenerateNumbers();
            }
            //ClickAll();
            Color targetColor = board[e.Y, e.X].Label.BackColor;
            CheckRight(e, targetColor);
            CheckLeft(e, targetColor);
            CheckRowAbove(e, targetColor);
            CheckRowBelow(e, targetColor);

        }

        public void GenerateMines(int clickedX, int clickedY)
        {
            int x;
            int y;
            for (int i = 0; i < 10; i++)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                while (board[x, y].Label.BackColor == Color.Red || (x == clickedX && y == clickedY))
                {
                    x = random.Next(0, 10);
                    y = random.Next(0, 10);
                }
                board[x, y].SetText('B');
                board[x, y].SetColor(Color.Red);
            }
        }

        public void GenerateNumbers()
        {
            int numBombs = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    // check right
                    if (col < board.GetLength(1) - 1)
                    {
                        if (board[col + 1, row].CellText == 'B')
                        {
                            board[col, row].SetText((char)numBombs);
                        }
                    }
                }
            }
        }

        public void ClickAll()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[col, row].PerformClick();
                }
            }
        }

        public void ClearBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[col, row].ResetCell();
                }
            }
            numClicks = 0;
        }

        



        #region Check Surrounding Tiles
        private void CheckRight(CellClickEventArgs e, Color targetColor)
        {
            // check right
            if (e.X < board.GetLength(1) - 1)
            {
                if (board[e.X + 1, e.Y].Label.BackColor == targetColor)
                {
                    board[e.X + 1, e.Y].PerformClick();
                }
            }
        }

        private void CheckLeft(CellClickEventArgs e, Color targetColor)
        {
            // check left
            if (e.X > 0)
            {
                if (board[e.X - 1, e.Y].Label.BackColor == targetColor)
                {
                    board[e.X - 1, e.Y].PerformClick();
                }
            }
        }

        private void CheckRowBelow(CellClickEventArgs e, Color targetColor)
        {
            // check down
            if (e.Y < board.GetLength(0) - 1)
            {
                CheckLeft(e, targetColor);
                if (board[e.X, e.Y + 1].Label.BackColor == targetColor)
                {
                    board[e.X, e.Y + 1].PerformClick();
                }
                CheckRight(e, targetColor);
            }
        }

        private void CheckRowAbove(CellClickEventArgs e, Color targetColor)
        {
            // check up
            CheckLeft(e, targetColor);
            if (e.Y > 0)
            {
                if (board[e.X, e.Y - 1].Label.BackColor == targetColor)
                {
                    board[e.X, e.Y - 1].PerformClick();
                }
            }
            CheckRight(e, targetColor);
        }

        #endregion

        #region Menu Buttons
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearBoard();
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