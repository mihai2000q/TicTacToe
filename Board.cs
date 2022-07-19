using System;
using System.Collections.Generic;
using System.Drawing;
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
                    if (IsEnd(out var type, out var ticButtons))
                    {
                        GameOver = true;
                        Winner = type;
                        if(Winner != Constants.TicType.Non)
                            ticButtons.ForEach(tic =>
                            {
                                tic.FlatAppearance.BorderSize = 3;
                                tic.FlatAppearance.BorderColor = Color.LimeGreen;
                            });
                    }
                    TurnChanged?.Invoke();
                    
                    if(GameOver)
                        Reset();
                };
            }
        }

        private bool IsEnd(out Constants.TicType type, out List<TicButton> ticButtons)
        {
            return IsPattern(1, 2, 3, out type, out ticButtons) ||
                   IsPattern(4, 5, 6, out type, out ticButtons) ||
                   IsPattern(7, 8, 9, out type, out ticButtons) ||
                   IsPattern(1, 4, 7, out type, out ticButtons) ||
                   IsPattern(2, 5, 8, out type, out ticButtons) ||
                   IsPattern(3, 6, 9, out type, out ticButtons) ||
                   IsPattern(1, 5, 9, out type, out ticButtons) ||
                   IsPattern(3, 5, 7, out type, out ticButtons) ||
                   IsDraw(out type, out ticButtons);
        }

        private bool IsPattern(int a, int b, int c, out Constants.TicType type, out List<TicButton> ticButtons)
        {
            type = _ticButtons[a - 1].Type;
            ticButtons = new List<TicButton>(3)
            {
                _ticButtons[a - 1],
                _ticButtons[b - 1],
                _ticButtons[c - 1]
            };
            return _ticButtons[a - 1].Type != Constants.TicType.Non &&
                   (_ticButtons[a - 1].Type == _ticButtons[b - 1].Type && _ticButtons[b - 1].Type == _ticButtons[c - 1].Type);
        }

        private bool IsDraw(out Constants.TicType type, out List<TicButton> ticButtons)
        {
            ticButtons = new List<TicButton>(0);
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