namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.theMenuStrip = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revealBoardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearWinLossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theStatusStrip = new System.Windows.Forms.StatusStrip();
            this.timerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.theMenuStrip.SuspendLayout();
            this.theStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // theMenuStrip
            // 
            this.theMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.theMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.theMenuStrip.Name = "theMenuStrip";
            this.theMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.theMenuStrip.TabIndex = 0;
            this.theMenuStrip.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revealBoardToolStripMenuItem1,
            this.clearWinLossToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // revealBoardToolStripMenuItem1
            // 
            this.revealBoardToolStripMenuItem1.Name = "revealBoardToolStripMenuItem1";
            this.revealBoardToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.revealBoardToolStripMenuItem1.Text = "Reveal Board";
            this.revealBoardToolStripMenuItem1.Click += new System.EventHandler(this.revealBoardToolStripMenuItem1_Click);
            // 
            // clearWinLossToolStripMenuItem
            // 
            this.clearWinLossToolStripMenuItem.Name = "clearWinLossToolStripMenuItem";
            this.clearWinLossToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.clearWinLossToolStripMenuItem.Text = "Clear Win/Loss";
            this.clearWinLossToolStripMenuItem.Click += new System.EventHandler(this.clearWinLossToolStripMenuItem_Click);
            // 
            // theStatusStrip
            // 
            this.theStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerLabel,
            this.timer_label,
            this.timeLabel});
            this.theStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.theStatusStrip.Name = "theStatusStrip";
            this.theStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.theStatusStrip.TabIndex = 1;
            this.theStatusStrip.Text = "statusStrip1";
            // 
            // timerLabel
            // 
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // timer_label
            // 
            this.timer_label.Name = "timer_label";
            this.timer_label.Size = new System.Drawing.Size(0, 17);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(45, 17);
            this.timeLabel.Text = "Time: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.theStatusStrip);
            this.Controls.Add(this.theMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.theMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.theMenuStrip.ResumeLayout(false);
            this.theMenuStrip.PerformLayout();
            this.theStatusStrip.ResumeLayout(false);
            this.theStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip theMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem revealBoardToolStripMenuItem1;
        private ToolStripMenuItem clearWinLossToolStripMenuItem;
        private StatusStrip theStatusStrip;
        private ToolStripStatusLabel timerLabel;
        private System.Windows.Forms.Timer gameTimer;
        private ToolStripStatusLabel timer_label;
        private ToolStripStatusLabel timeLabel;
    }
}