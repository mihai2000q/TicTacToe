using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public sealed partial class MainWindow : Form
    {
        public enum State { Starting, Playing, Paused }

        public static State GameState { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            FadeIn();
            InitEvents();
        }

        private void InitEvents()
        {
            _board.TurnChanged += (turn) =>
            {
                if (GameState == State.Playing)
                    AnimateLabelRollingDown(this, new Label(), turn == Constants.TicType.O ? "Player O Turn" : "Player X Turn", 365);
            };
            _board.GameStarted += () =>
            {
                GameState = State.Playing;
                AnimateLabelRollingDown(this, new Label(), "Player X Turn", 365);
            };
            _board.GameFinished += (winner) =>
            {
                if (winner != Constants.TicType.Non) 
                    MessageBox.Show(winner == Constants.TicType.X ? "GG X" : "GG O");
                else
                    MessageBox.Show(@"DRAW");
                GameState = State.Starting;
            };
        }

        private void FadeIn()
        {
            this.Opacity = 0;
            var timer = new Timer();
            const float speed = 0.05F;
            timer.Interval = 1;
            timer.Tick += (sender, args) =>
            {
                if (this.Opacity >= 1)
                {
                    _board.SummonButtons();
                    timer.Stop();
                }
                else
                    this.Opacity += speed;
            };
            timer.Start();
        }

        private static void AnimateLabelRollingDown(Form form, Label label, string text, int x)
        {
            label.Font = new Font("MV Boli", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Size = new Size(16 * text.Length, 14 * 3);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = text;
            form.Controls.Add(label);
            const int initialSpeed = 10;
            const int laterSpeed = 1;
            int speed;
            var yPosition = 0;
            var maxY = form.Size.Height / 4;
            
            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (sender, args) =>
            {
                if (label.Location.Y >= form.Size.Height)
                {
                    timer.Stop();
                    label.Dispose();
                }

                if (label.Location.Y < maxY || label.Location.Y > maxY + maxY / 2)
                    speed = initialSpeed;
                else
                    speed = laterSpeed;
                
                label.Location = new Point(x, yPosition);
                yPosition += speed;
            };
            timer.Start();
        }
    }
}