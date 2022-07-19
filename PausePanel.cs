using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public sealed class PausePanel : Panel
    {
        public Button ButtonBack { get; private set; }

        public PausePanel(Size size)
        {
            Size = new Size(size.Width / 2, size.Height / 2);
            Init();
        }

        private void Init()
        {
            this.BackColor = Color.Gainsboro;

            ButtonBack = new Button();
            ButtonBack.BackColor = DefaultBackColor;
            ButtonBack.Size = new Size(75, 50);
            ButtonBack.Location = new Point(
                Size.Width / 2 - ButtonBack.Size.Width / 2,
                Size.Height / 2 - ButtonBack.Size.Height / 2);
            ButtonBack.Text = @"Back";
            
            this.Controls.Add(ButtonBack);
        }
    }
}