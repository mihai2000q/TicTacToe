using System.Windows.Forms;

namespace TicTacToe
{
    public sealed partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            _board.TurnChanged += BoardOnTurnChanged;
            
        }

        private void BoardOnTurnChanged()
        {
            labelTurn.Text = _board.Turn ? "Player 2 Turn" : "Player 1 Turn";

            if (!_board.GameOver) return;
            if (_board.Winner != Constants.TicType.Non)
                MessageBox.Show(_board.Winner == Constants.TicType.X ? "GG X" : "GG O");
            else
                MessageBox.Show(@"DRAW");
            labelTurn.Text = @"Player 1 Turn";
        }
    }
}