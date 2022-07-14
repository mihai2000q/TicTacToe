using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Board : TableLayoutPanel
    {
        public bool Turn { get; private set; } = true;

        private readonly List<TicButton> _ticButtons;
        public Board()
        {
            _ticButtons = new List<TicButton>();
            InitializeComponent();
            InitButtons();
        }

        private void InitButtons()
        {
            for (var i = 0; i < 9; i++)
            {
                _ticButtons.Add(new TicButton(this.MinimumSize));
                this.Controls.Add(_ticButtons.Last());
                var ticButton = _ticButtons.Last();
                ticButton.Click += (sender, args) =>
                {
                    if (!ticButton.Shown)
                    {
                        ticButton.Turn = this.Turn;
                        ticButton.OnClick();
                        ticButton.Shown = true;
                        Turn = !Turn;
                    }
                };
            }
        }
    }
}