using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tasks
{
    public partial class FrmPaint : Form
    {
        public FrmPaint()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }

        protected override void OnLoad(EventArgs e)
        {
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            base.OnLoad(e);
        }

        Graphics graphics;
        readonly ColorDialog colorDialog = new();

        readonly Pen pen = new(Color.Black, 5);
        readonly Pen eraser = new(Color.White, 5);

        bool painting = false;
        readonly List<List<Point>> strokes = new();
        readonly List<Color> colors = new();

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pen.Color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
            }
        }

        private void Paint_MouseDown(object sender, MouseEventArgs e)
        {
            strokes.Add(new List<Point>());

            if (e.Button == MouseButtons.Left) colors.Add(pen.Color);
            else if (e.Button == MouseButtons.Right) colors.Add(eraser.Color);

            strokes[^1].Add(new Point(e.X, e.Y));

            painting = true;
        }

        private void Paint_MouseMove(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        strokes[^1].Add(new Point(e.X, e.Y));
                        graphics.DrawLine(pen, strokes[^1][^2], strokes[^1][^1]);
                        break;

                    case MouseButtons.Right:
                        strokes[^1].Add(new Point(e.X, e.Y));
                        graphics.DrawLine(eraser, strokes[^1][^2], strokes[^1][^1]);
                        break;
                }
            }
        }

        private void FrmPaint_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < strokes.Count; i++)
            {
                pen.Color = colors[i];
                for (int j = 1; j < strokes[i].Count; j++)
                {
                    graphics.DrawLine(pen, strokes[i][j-1], strokes[i][j]);
                }
                pen.Color = colorDialog.Color;
            }
        }
    }
}
