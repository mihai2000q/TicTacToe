using System.Windows.Forms;

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
            labelTurn.Text = _board.Turn ? "Player 1 Turn" : "Player 2 Turn";

            if (_board.GameOver)
                MessageBox.Show(_board.Winner == Constants.TicType.X ? "GG X" : "GG O");
        }
    }
}