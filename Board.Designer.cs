using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    partial class Board
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.BackColor = Color.Khaki;
            this.Size = new Size(450, 450);
            this.MinimumSize = new Size(125, 125);
            this.Location = new Point(0, 0);
            this.ColumnCount = 3;
            this.RowCount = 3;
            this.Padding = new Padding(20,20,0,0);
        }

        #endregion

    }
}