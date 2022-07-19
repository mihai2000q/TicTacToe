using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using static TicTacToe.Constants;

namespace TicTacToe
{
    public sealed class TicButton : Button
    {
        private readonly Image _imageX;
        private readonly Image _imageO;
        
        public bool Shown { get; private set; }
        public TicType Type { get; private set; }

        public TicButton()
        {
            this.BackColor = DefaultBackColor;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        
        public void OnClick(bool turn)
        {
            this.Image = turn ? DrawO() : DrawX();
            Type = turn ? TicType.O : TicType.X;
            Shown = true;
        }

        private Image DrawX()
        {
            var width = this.Size.Width / 2;
            var height = this.Size.Height / 2;

            var b = new Bitmap(width, height);
            var g = Graphics.FromImage(b);

            var blackPen = new Pen(Color.Black, 3);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawLine(blackPen, 0, 0, width,height);
            g.DrawLine(blackPen, width, 0, 0, height);
            g.Dispose();

            return b;
        }
        
        private Image DrawO()
        {
            var width = this.Size.Width / 2;
            var height = this.Size.Height / 2;

            var b = new Bitmap(width + 50, height + 50);
            var g = Graphics.FromImage(b);

            var pen = new Pen(Color.Red, 3);
            
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawEllipse(pen, 25, 25, width,height);
            g.Dispose();

            return b;
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