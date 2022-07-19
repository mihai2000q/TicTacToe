using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public sealed class PausePanel : Panel
    {
        public Button ButtonBack { get; private set; }

        public PausePanel()
        {
            Init();
        }

        private void Init()
        {
            ButtonBack = new Button();
            ButtonBack.BackColor = DefaultBackColor;
            ButtonBack.Size = new Size(75, 50);
            ButtonBack.Location = new Point(
                400 / 2 - ButtonBack.Size.Width / 2,
                225 / 2 - ButtonBack.Size.Height / 2);
            ButtonBack.Text = @"Back";
            
            this.Controls.Add(ButtonBack);
        }
    }
}