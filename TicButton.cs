using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using static TicTacToe.Constants;

namespace TicTacToe
{
    public sealed class TicButton : Button
    {
        public bool Shown { get; private set; }
        public TicType Type { get; private set; }

        public TicButton()
        {
            this.BackColor = DefaultBackColor;
            this.FlatStyle = FlatStyle.Standard;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        
        public void OnClick(bool turn)
        {
            this.Image = turn
                ? ResizeImage(OImageButton, Size)
                : ResizeImage(XImageButton, Size);
            Type = turn ? TicType.O : TicType.X;
            Shown = true;
        }

        private static Image ResizeImage(string path, Size size)
        {
            var imageToResize = Image.FromFile(path);
            var b = new Bitmap(size.Width, size.Height);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imageToResize, 0, 0, size.Width, size.Height);
            g.Dispose();
            return b;
        }
    }
}