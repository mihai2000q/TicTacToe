using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicButton : Button
    {
        public bool Shown { get; set; }
        
        public bool Turn { get; set; }
        
        public TicButton()
        {
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