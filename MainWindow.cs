﻿using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            _board.TurnChanged += BoardOnTurnChanged;
        }

        private void BoardOnTurnChanged()
        {
            
        }
    }
}