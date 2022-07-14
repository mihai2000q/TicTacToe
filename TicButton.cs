using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicButton : Button
    {
        private readonly Size _size;

        public bool Shown { get; set; } = false;
        
        public bool Turn { get; set; }
        
        public TicButton(Size size)
        {
            _size = size;
            InitializeComponent();
        }
        
        public void OnClick()
        {
            /*this.Image = Turn
                ? Image.FromFile(Constants.X_ImageButton)
                : Image.FromFile(Constants.O_ImageButton);*/
            MessageBox.Show(Turn ? "X clicked" : "O clicked");
        }
    }
}