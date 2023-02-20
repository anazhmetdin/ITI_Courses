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
    public partial class FrmDragable : Form
    {
        public FrmDragable()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            rect = new Rectangle(new Point(50, 50), size);
        }

        Point pos;
        Size size = new(200, 100);
        bool dragging = false;
        Rectangle rect;
        Graphics graphics;

        protected override void OnPaint(PaintEventArgs e)
        {
            graphics.FillRectangle(Brushes.Blue, rect);
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }

        private void FrmDragable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= rect.X && e.X <= rect.X + size.Width && e.Y >= rect.Y && e.Y <= rect.Y + size.Height)
                {
                    pos = new Point(e.X, e.Y);
                    dragging = true;
                }
            }
        }

        private void FrmDragable_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void FrmDragable_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                //pos = new(rect.X + e.X - pos.X, rect.Y + e.Y - pos.Y);
                rect.X = rect.X + e.X - pos.X;
                rect.Y = rect.Y + e.Y - pos.Y;

                pos = new Point(e.X, e.Y);

                Invalidate();
            }
        }
    }
}
