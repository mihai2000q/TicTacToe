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
            this.labelTurn = new System.Windows.Forms.Label();
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
            _board.InitButtons();
            // 
            // labelTurn
            // 
            this.labelTurn.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurn.Location = new System.Drawing.Point(520, 188);
            this.labelTurn.Name = "labelTurn";
            this.labelTurn.Size = new System.Drawing.Size(200, 49);
            this.labelTurn.TabIndex = 1;
            this.labelTurn.Text = "Player 1 Turn";
            this.labelTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTurn);
            this.Controls.Add(this._board);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
        }

        private TicTacToe.Board _board;
        private System.Windows.Forms.Label labelTurn;
        
        #endregion

    }
}