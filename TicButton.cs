using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using static TicTacToe.Constants;
using Timer = System.Windows.Forms.Timer;

namespace TicTacToe
{
    public sealed class TicButton : Button
    {
        public bool Shown { get; private set; }
        public TicType Type { get; private set; }
        
        public TicButton(Size size)
        {
            this.Size = size;
            this.BackColor = DefaultBackColor;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.SetStyle(ControlStyles.Selectable, false);
            this.Enabled = false;
            this.EnabledChanged += (sender, args) =>
            {
                BackColor = !Enabled 
                    ? Color.FromArgb(255 / 2, DefaultBackColor) 
                    : DefaultBackColor;
            };
            AnimateButton(this);
        }

        private static void AnimateButton(TicButton ticButton)
        {
            var maxSize = ticButton.Size;
            ticButton.Size = new Size(0, 0);
            const int speed = 5;

            var timer = new Timer();
            timer.Interval = 1;
            timer.Tick += (sender, args) =>
            {
                if(MainWindow.GameState == MainWindow.State.Paused) return;
                if(ticButton.Width >= maxSize.Width && ticButton.Height >= maxSize.Height)
                    timer.Stop();
                else if (ticButton.Width >= maxSize.Width)
                    ticButton.Size = new Size(ticButton.Width, ticButton.Height + speed);
                else if (ticButton.Height >= maxSize.Height)
                    ticButton.Size = new Size(ticButton.Width + speed, ticButton.Height);
                else
                    ticButton.Size = new Size(ticButton.Width + speed, ticButton.Height + speed);
            };
            timer.Start();
        }
        
        public void OnClick(bool turn)
        {
            if (turn)
                StartAnimatingO();
            else
                StartAnimatingX(0,0,this.Size.Width / 2,this.Size.Height / 2, true);
            Type = turn ? TicType.O : TicType.X;
            Shown = true;
        }

        private void StartAnimatingX(int initWidth, int initHeight, int maxWidth, int maxHeight, bool isLeft)
        {
            var timer = new Timer();
            timer.Interval = 1;
            const int speed = 5;
            timer.Tick += (sender, args) =>
            {
                if (isLeft)
                {
                    this.Image = DrawX(initWidth, initHeight, true);

                    if (initWidth >= maxWidth && initHeight >= maxHeight)
                    {
                        isLeft = false;
                        initWidth = maxWidth;
                        maxWidth = 0;
                        initHeight = 0;
                    }
                    else if (initHeight >= maxHeight)
                        initWidth += speed;
                    else if (initWidth >= maxWidth)
                        initHeight += speed;
                    else
                    {
                        initHeight += speed;
                        initWidth += speed;
                    }
                }
                else
                {
                    this.Image = DrawX(initWidth, initHeight, false);

                    if (initWidth <= maxWidth && initHeight >= maxHeight)
                        timer.Stop();
                    else if (initHeight >= maxHeight)
                        initWidth -= speed;
                    else if (initWidth <= maxWidth)
                        initHeight += speed;
                    else
                    {
                        initHeight += speed;
                        initWidth -= speed;
                    }
                }
            };
            timer.Start();
        }
        private Image DrawX(int w, int h, bool isLeft)
        {
            var width = this.Size.Width / 2;
            var height = this.Size.Height / 2;

            var b = new Bitmap(width, height);
            var g = Graphics.FromImage(b);

            var blackPen = new Pen(Color.Black, 3);

            g.SmoothingMode = SmoothingMode.HighQuality;
            if(isLeft)
                g.DrawLine(blackPen, 0, 0, w,h);
            else
            {
                g.DrawLine(blackPen, 0, 0, width,height);
                g.DrawLine(blackPen, width, 0, w, h);
            }
            g.Dispose();

            return b;
        }
        private void StartAnimatingO()
        {
            var timer = new Timer();
            timer.Interval = 1;
            const int speed = 18;
            const int maxAngle = 360;
            var initAngle = 0;
            timer.Tick += (sender, args) =>
            {
                this.Image = DrawO(initAngle);

                if (initAngle >= maxAngle)
                    timer.Stop();
                else
                    initAngle += speed;
            };
            timer.Start();
        }
        private Image DrawO(int angle)
        {
            var width = this.Size.Width / 2;
            var height = this.Size.Height / 2;

            var b = new Bitmap(width + 50, height + 50);
            var g = Graphics.FromImage(b);

            var pen = new Pen(Color.Red, 3);
            
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawArc(pen,25,25,width,height,0,angle);
            g.Dispose();

            return b;
        }
    }
}