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
        }
    }
}