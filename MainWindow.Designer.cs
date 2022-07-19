using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public sealed partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._board = new TicTacToe.Board();
            this._pausePanel = new TicTacToe.PausePanel();
            this.buttonPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _board
            // 
            this._board.BackColor = System.Drawing.Color.Khaki;
            this._board.ColumnCount = 3;
            this._board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._board.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this._board.Location = new System.Drawing.Point(0, 0);
            this._board.Margin = new System.Windows.Forms.Padding(0);
            this._board.MaximumSize = new System.Drawing.Size(450, 450);
            this._board.MinimumSize = new System.Drawing.Size(125, 125);
            this._board.Name = "_board";
            this._board.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this._board.RowCount = 3;
            this._board.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._board.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._board.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._board.Size = new System.Drawing.Size(450, 450);
            this._board.TabIndex = 0;
            // 
            // _pausePanel
            // 
            this._pausePanel.BackColor = System.Drawing.Color.Gainsboro;
            this._pausePanel.Location = new System.Drawing.Point(200, 112);
            this._pausePanel.Name = "_pausePanel";
            this._pausePanel.Size = new System.Drawing.Size(400, 225);
            this._pausePanel.TabIndex = 0;
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPause.Location = new System.Drawing.Point(687, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(101, 52);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._pausePanel);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this._board);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonPause;

        private TicTacToe.Board _board;
        private TicTacToe.PausePanel _pausePanel;

        #endregion

    }
}