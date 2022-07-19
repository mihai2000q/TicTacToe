using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public sealed class Board : TableLayoutPanel
    {
        public event Action<Constants.TicType> TurnChanged;
        public event Action GameStarted;
        public event Action<Constants.TicType> GameFinished;
        
        private readonly List<TicButton> _ticButtons;

        private bool _turn;
        private bool _gameOver;
        private Constants.TicType Winner { get; set; }

        public Board()
        {
            _ticButtons = new List<TicButton>(9);
        }
        
        public void SummonButtons()
        {
            var i = 0;
            const int max = 9;
            var timer = new Timer();
            timer.Interval = 250;
            timer.Tick += (sender, args) =>
            {
                i++;
                _ticButtons.Add(new TicButton(this.MinimumSize));
                InitButtons(_ticButtons.Last());
                if (i == max)
                {
                    timer.Stop();
                    GameStarted?.Invoke();
                }
            };
            timer.Start();
        }

        private void InitButtons(TicButton ticButton)
        {
            this.Controls.Add(ticButton);
            ticButton.Click += (sender, args) =>
            {
                if (ticButton.Shown || MainWindow.GameState != MainWindow.State.Playing) return;
                ticButton.OnClick(_turn);
                _turn = !_turn;
                if (IsEnd(out var type, out var ticButtons))
                {
                    _gameOver = true;
                    _turn = false;
                    Winner = type;
                    if(Winner != Constants.TicType.Non)
                        ticButtons.ForEach(tic =>
                        {
                            tic.FlatAppearance.BorderSize = 3;
                            tic.FlatAppearance.BorderColor = Color.LimeGreen;
                        });
                }

                if (_gameOver)
                {
                    GameFinished?.Invoke(Winner);
                    Reset();
                }

                TurnChanged?.Invoke(_turn ? Constants.TicType.O : Constants.TicType.X);
            };
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
            _gameOver = false;
            Winner = Constants.TicType.Non;
            this.Controls.Clear();
            _ticButtons.Clear();
            SummonButtons();
        }
    }
}