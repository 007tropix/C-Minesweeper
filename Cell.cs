using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Cell : UserControl
    {
        public event EventHandler<CellClickEventArgs> CellClick;
        Label label = new Label();
        Button button = new Button();
        Size cellSize = new Size(24, 24);
        int x;
        int y;
        char cellText;


        public Cell()
        {
            InitializeComponent();
            
            this.Size = cellSize;

            button.Size = this.Size;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(255, 255, 255);
            


            label.Size = this.Size;
            label.BackColor = Color.FromArgb(192, 192, 192);

            this.Controls.Add(button);
            this.Controls.Add(label);

            button.Click += ButtonClick_EventHandler;            
            
        }

        public void ButtonClick_EventHandler(object ?sender, EventArgs e)
        {
            button.Visible = false;
            CellClickEventArgs args = new CellClickEventArgs(X, Y);
            OnCellClick(this, args);
        }

        protected virtual void OnCellClick(object sender, CellClickEventArgs e)
        {
            CellClick?.Invoke(sender, e);
        }

        public void SetText(char text)
        {
            label.Text = text.ToString();
        }

        public void SetColor(Color color)
        {
            label.BackColor = color;
        }

        public void ResetCell()
        {
            button.BackColor = Color.FromArgb(255, 255, 255);
            label.BackColor = Color.FromArgb(192, 192, 192);
            SetText(' ');
            button.Visible = true;
        }

        public void PerformClick()
        {
            button.PerformClick();
        }
        public Size CellSize { get => cellSize; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Label Label { get => label; }
        public char CellText { get => cellText; }
    }
}
