using System.Drawing.Text;

namespace Minesweeper
{
    public partial class Form1 : Form
    {

        Cell[,] board = new Cell[10, 10];
        Random random = new Random();
        int numClicks = 0;
        int elapsedTime = 0;
        int wins;
        int losses;
        Label winLabel = new Label();
        Label lossLabel = new Label();
        string dataFile = "data.txt";
        bool gameEnded = false;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Minesweeper";
            InitGame();
        }

        #region Game Setup
        private void InitGame()
        {
            LoadScore(); // Load Scores From Files
            CreateScoreLabels(); // Create Score Labels
            InitBoard(); // Initialize Board
        }

        public void LoadScore()
        {
            if (File.Exists(dataFile))
            {
                using (StreamReader sr = new StreamReader(dataFile))
                {
                    string? winsString = sr.ReadLine();
                    if (winsString != null)
                    {
                        wins = Int32.Parse(winsString);
                    }

                    string? lossesString = sr.ReadLine();
                    if (lossesString != null)
                    {
                        losses = Int32.Parse(lossesString);
                    }
                }
            }
            else
            {
                MessageBox.Show("data.txt not found");
            }
        }

        public void CreateScoreLabels()
        {
            

            // Win Label Setup
            winLabel.Location = new Point(250, 24);
            winLabel.Size = new Size(60, 24);
            winLabel.BackColor = Color.FromArgb(192, 192, 192);
            winLabel.Text = "Wins: " + wins;
            this.Controls.Add(winLabel);

            // Loss Label Setup
            lossLabel.Location = new Point(250, 48);
            lossLabel.Size = new Size(60, 24);
            lossLabel.BackColor = Color.FromArgb(192, 192, 192);
            lossLabel.Text = "Losses: " + losses;
            this.Controls.Add(lossLabel);
        }

        public void InitBoard()
        {
            for (int row = 0; row < board.GetLength(1); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
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

        #endregion

        #region Gameplay Methods
        public void OnCellClick(object ?sender, CellClickEventArgs e)
        {
            numClicks++;

            // Check for first click
            if (numClicks == 1)
            {
                gameTimer.Enabled = true;
                gameTimer.Start();
                GenerateMines(e.X, e.Y);
                GenerateNumbers();
            }

            // Check if tile clicked is mine
            if (board[e.X, e.Y].Label.BackColor == Color.Red)
            {
                losses++;
                DeactivateButtons();
                UpdateFile();
                UpdateWinLossLabels();
                gameEnded = true;
                gameTimer.Stop();
            }

            // Check for win
            CheckIfWon();

            // Check if tile clicked on is blank
            if (board[e.X, e.Y].GetText() == '0')
            {
                CheckRight(e.X, e.Y);
                CheckLeft(e.X, e.Y);
                CheckRowBelow(e);
                CheckRowAbove(e);
            }
            else
            {
                board[e.X, e.Y].ClearButton();
            }
            
            

        }

        public void GenerateNumbers()
        {
            int numBombs = 0;
            for (int row = 0; row < board.GetLength(1); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {

                    // check right
                    if (CheckRightBombs(row, col))
                    {
                        numBombs++;
                    }

                    // check left
                    if (CheckLeftBombs(row, col))
                    {
                        numBombs++;
                    }

                    // check row below
                    int bombsBelow = CheckRowBelowBombs(row, col);
                    if (bombsBelow > 0)
                    {
                        numBombs = numBombs + bombsBelow;
                    }

                    // check row above
                    int bombsAbove = CheckRowAboveBombs(row, col);
                    if (bombsAbove > 0)
                    {
                        numBombs = numBombs + bombsAbove;
                    }

                    // check if current tile is bomb
                    if (board[col, row].Label.BackColor != Color.Red)
                    {
                        board[col, row].SetText(numBombs.ToString()[0]);
                    }

                    numBombs = 0;
                }

            }

            
        }

        public void RevealBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[col, row].ClearButton();
                }
            }
        }

        public void ResetBoard()
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

        public void DeactivateButtons()
        {
            foreach (Cell cell in board)
            {
                cell.DeactivateButton();
            }
        }

        public void ActivateButtons()
        {
            foreach (Cell cell in board)
            {
                cell.ActivateButton();
            }
        }

        public void UpdateFile()
        {
            StreamWriter wr = new StreamWriter(dataFile);
            wr.WriteLine(wins.ToString());
            wr.WriteLine(losses.ToString());
            wr.Close();
        }

        public void UpdateWinLossLabels()
        {
            winLabel.Text = "Wins: " + wins;
            lossLabel.Text = "Losses: " + losses;
        }

        public void CheckIfWon()
        {
            int tilesClicked = 0;
            foreach (Cell cell in board)
            {
                if (cell.IsClicked())
                {
                    tilesClicked++;
                }
            }

            if (tilesClicked == 90)
            {
                DeactivateButtons();
                gameTimer.Stop();
                gameEnded = true;
                wins++;
                UpdateFile();
                UpdateWinLossLabels();
                MessageBox.Show("You win!\nTime Elapsed: " + elapsedTime);
            }
        }

        #endregion

        #region Number Generation Checks
        private bool CheckRightBombs(int row, int col)
        {
            // check right
            if (col < board.GetLength(0) - 1)
            {
                if (board[col + 1, row].GetText().Equals('B'))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckLeftBombs(int row, int col)
        {
            // check left
            if (col > 0)
            {
                if (board[col - 1, row].GetText().Equals('B'))
                {
                    return true;
                }
            }
            return false;
        }

        private int CheckRowBelowBombs(int row, int col)
        {

            int rowBombTotal = 0;
            // check row below
            if (row < board.GetLength(1) - 1)
            {
                // check row below left
                if (CheckLeftBombs(row + 1, col) == true)
                {
                    rowBombTotal = rowBombTotal + 1;
                }

                // check row below middle
                if (board[col, row + 1].GetText().Equals('B') && board[col, row].Label.BackColor != Color.Red)
                {
                    rowBombTotal = rowBombTotal + 1;
                }

                // check row below right
                if (CheckRightBombs(row + 1, col) == true)
                {
                    rowBombTotal = rowBombTotal + 1;
                }
            }
            return rowBombTotal;
        }

        private int CheckRowAboveBombs(int row, int col)
        {

            int rowBombTotal = 0;
            // check row below
            if (row > 0)
            {
                // check row below left
                if (CheckLeftBombs(row - 1, col))
                {
                    rowBombTotal++;
                }

                // check row below middle
                if (board[col, row - 1].GetText().Equals('B') && board[col, row].Label.BackColor != Color.Red)
                {
                    rowBombTotal++;
                }

                // check row below right
                if (CheckRightBombs(row - 1, col))
                {
                    rowBombTotal++;
                }
            }
            return rowBombTotal;
        }
        #endregion

        #region Check Surrounding Tiles
        private void CheckRight(int x, int y)
        {
            // check right
            if (x < board.GetLength(1) - 1)
            {
                if (board[x + 1, y].GetText() == '0')
                {
                    board[x + 1, y].PerformClick();
                }
                else if (board[x + 1, y].GetText() != 'B')
                {
                    board[x + 1, y].ClearButton();
                    CheckIfWon();
                }
            }
        }

        private void CheckLeft(int x, int y)
        {
            // check left
            if (x > 0)
            {
                if (board[x - 1, y].GetText() == '0')
                {
                    board[x - 1, y].PerformClick();
                }
                else if (board[x - 1, y].GetText() != 'B')
                {
                    board[x - 1, y].ClearButton();
                    CheckIfWon();
                }
            }
        }

        private void CheckRowBelow(CellClickEventArgs e)
        {
            // check down
            if (e.Y < board.GetLength(0) - 1)
            {
                CheckLeft(e.X, e.Y + 1);
                if (board[e.X, e.Y + 1].GetText() == ('0'))
                {
                    board[e.X, e.Y + 1].PerformClick();
                }
                else if (board[e.X, e.Y + 1].GetText() != 'B')
                {
                    board[e.X, e.Y + 1].ClearButton();
                    CheckIfWon();
                }
                CheckRight(e.X, e.Y + 1);
            }
        }

        private void CheckRowAbove(CellClickEventArgs e)
        {
            // check up
            if (e.Y > 0)
            {
                CheckLeft(e.X, e.Y - 1);
                if (board[e.X, e.Y - 1].GetText() == ('0'))
                {
                    board[e.X, e.Y - 1].PerformClick();
                }
                else if (board[e.X, e.Y - 1].GetText() != 'B')
                {
                    board[e.X, e.Y - 1].ClearButton();
                    CheckIfWon();
                }
                CheckRight(e.X, e.Y - 1);
            }
        }

        #endregion

        #region Menu Strip Buttons / Status Strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                UpdateFile();
                UpdateWinLossLabels();
                ResetBoard();
                ActivateButtons();
                gameEnded = false;
                elapsedTime = 0;
                timeLabel.Text = "Time: " + elapsedTime;
            }
            else
            {
                losses++;
                UpdateFile();
                UpdateWinLossLabels();
                ResetBoard();
                ActivateButtons();
                gameEnded = false;
                elapsedTime = 0;
                timeLabel.Text = "Time: " + elapsedTime;
                gameTimer.Stop();
            }

            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click a tile to begin.\nEach number on a tile represents the number of mines in its surrounding 8 tiles.\nUse this information to click all tiles that aren't mines to win.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game was coded by Ryan Du Plooy for CS 3020");
        }

        private void revealBoardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (numClicks == 0)
            {
                MessageBox.Show("Error: game has not been started");
            }
            else
            {
                gameEnded = true;
                losses++;
                RevealBoard();
                UpdateFile();
                UpdateWinLossLabels();
            }
        }

        private void clearWinLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wins = 0;
            losses = 0;
            UpdateFile();
            UpdateWinLossLabels();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            timeLabel.Text = "Time: " + elapsedTime;
        }

        #endregion


    }
}