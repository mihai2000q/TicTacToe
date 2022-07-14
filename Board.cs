using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Board : TableLayoutPanel
    {
        public event Action TurnChanged;
        
        private readonly List<TicButton> _ticButtons;

        public bool Turn { get; private set; } = true;

        public Board()
        {
            _ticButtons = new List<TicButton>();
        }

        public void InitButtons()
        {
            for (var i = 0; i < 9; i++)
            {
                _ticButtons.Add(new TicButton { Size = this.MinimumSize });
                var ticButton = _ticButtons.Last();
                this.Controls.Add(ticButton);
                ticButton.Click += (sender, args) =>
                {
                    if (!ticButton.Shown)
                    {
                        ticButton.OnClick(Turn);
                        Turn = !Turn;
                    }
                    TurnChanged?.Invoke();
                };
            }
        }
    }
}