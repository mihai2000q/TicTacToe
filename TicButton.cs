using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public class TicButton : Button
    {
        public bool Shown { get; private set; }
        
        public TicButton()
        {
            this.BackColor = DefaultBackColor;
            this.FlatStyle = FlatStyle.Standard;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        
        public void OnClick(bool turn)
        {
            /*this.Image = Turn
                ? Image.FromFile(Constants.X_ImageButton)
                : Image.FromFile(Constants.O_ImageButton);*/
            MessageBox.Show(turn ? "X clicked" : "O clicked");
            Shown = false;
        }
    }
}