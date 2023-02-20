using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tasks
{
    public partial class FrmBall : Form
    {
        public FrmBall()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }

        Graphics graphics;
        Point ballPos = new Point(173, 290);
        int direction = -1;
        Pen ballPen = new(Color.DarkGreen, 5);
        Pen stickPen = new(Color.Black, 3);
        int step = 0;

        private int ZeroOnNegative(int value)
        {
            return value < 0 ? 0 : value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // ball
            graphics.DrawEllipse(ballPen, ballPos.X, ballPos.Y, 100, 100);

            // man - head
            graphics.DrawEllipse(stickPen, 100, 40, 70, 70);
            // man - body
            graphics.DrawLine(stickPen, 135, 110, 135, 300);
            // man - hands
            graphics.DrawLine(stickPen, 135, 110, 100, 200);
            graphics.DrawLine(stickPen, 135, 110, 170, 200);
            // man - legs
            graphics.DrawLine(stickPen, 135, 300, 100, 400);
            graphics.DrawLine(stickPen, 135, 300,
                170 + ZeroOnNegative((int)(Math.Sin((step + 5) * Math.PI / 36) * 75)),
                400 - ZeroOnNegative((int)(Math.Sin((step + 5) * Math.PI / 36) * 50)));

            // woman - head
            graphics.DrawEllipse(stickPen, 600, 40, 70, 70);
            // woman - hair
            graphics.DrawLine(stickPen, 635, 40, 570, 110);
            graphics.DrawLine(stickPen, 635, 40, 700, 110);
            // woman - body
            graphics.DrawLine(stickPen, 635, 110, 635, 300);
            // woman - hands
            graphics.DrawLine(stickPen, 635, 110, 600, 200);
            graphics.DrawLine(stickPen, 635, 110, 670, 200);
            // woman - legs
            graphics.DrawLine(stickPen, 635, 300,
                600 - ZeroOnNegative((int)(Math.Sin((step + 5) * Math.PI / 36 + Math.PI) * 75)),
                400 - ZeroOnNegative((int)(Math.Sin((step + 5) * Math.PI / 36 + Math.PI) * 50)));
            graphics.DrawLine(stickPen, 635, 300, 670, 400);

            base.OnPaint(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ballPos.X == 497 || ballPos.X == 173) direction *= -1;
            ballPos.X += direction * 9;
            ballPos.Y = (int) (290 - Math.Sin((ballPos.X - 155) * Math.PI / 360) * 150);
            step = ++step % 72;

            this.Refresh();
        }
    }
}
