using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public sealed class Board : TableLayoutPanel
    {
        public event Action TurnChanged;
        
        private readonly List<TicButton> _ticButtons;

        public bool Turn { get; private set; }
        public bool GameOver { get; private set; }
        public Constants.TicType Winner { get; private set; }

        public Board()
        {
            _ticButtons = new List<TicButton>(9);
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
                    if (ticButton.Shown) return;
                    ticButton.OnClick(Turn);
                    Turn = !Turn;
                    if (CheckEnd(out var type))
                    {
                        GameOver = true;
                        Winner = type;
                    }
                    TurnChanged?.Invoke();
                    
                    if(GameOver)
                        Reset();
                };
            }
        }

        private bool CheckEnd(out Constants.TicType type)
        {
            return IsPattern(0, 1, 2, out type) ||
                   IsPattern(3, 4, 5, out type) ||
                   IsPattern(6, 7, 8, out type) ||
                   IsPattern(0, 3, 6, out type) ||
                   IsPattern(1, 4, 7, out type) ||
                   IsPattern(2, 5, 8, out type) ||
                   IsPattern(0, 4, 8, out type) ||
                   IsPattern(2, 4, 6, out type) ||
                   IsDraw(out type);
        }

        private bool IsPattern(int a, int b, int c, out Constants.TicType type)
        {
            type = _ticButtons[a].Type;
            return _ticButtons[a].Type != Constants.TicType.Non &&
                   (_ticButtons[a].Type == _ticButtons[b].Type && _ticButtons[b].Type == _ticButtons[c].Type);
        }

        private bool IsDraw(out Constants.TicType type)
        {
            type = Constants.TicType.Non;
            return _ticButtons.All(tic => tic.Type != Constants.TicType.Non);
        }

        private void Reset()
        {
            GameOver = false;
            Winner = Constants.TicType.Non;
            this.Controls.Clear();
            _ticButtons.Clear();
            InitButtons();
        }
    }
}