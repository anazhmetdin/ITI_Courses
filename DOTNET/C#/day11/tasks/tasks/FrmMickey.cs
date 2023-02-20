using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tasks
{
    public partial class FrmMickey : Form
    {
        public FrmMickey()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            graphics = CreateGraphics();
        }

        readonly Graphics graphics;
        const int radius = 500;
        GraphicsPath path = new GraphicsPath();

        /*Point pos = new();
        bool dragging = false;*/

        protected override void OnLoad(EventArgs e)
        {
            path.AddEllipse(radius / 5, radius / 5, radius, radius);
            path.AddEllipse(0, 0, radius / 2, radius / 2);
            path.AddEllipse(9 * radius / 10, 0, radius / 2, radius / 2);
            path.FillMode = FillMode.Winding;

            Region = new(path);

            BtnMove.Location = new Point(radius / 4 - BtnMove.Size.Width / 2, radius / 4 - BtnMove.Size.Width / 2);
            BtnClose.Location = new Point(23 * radius / 20 - BtnMove.Size.Width / 2, radius / 4 - BtnMove.Size.Width / 2);

            base.OnLoad(e);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void BtnMove_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                pos = new(e.X, e.Y);
            }*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /*private void BtnMove_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }*/

        /*private void BtnMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                //Location = new(Location.X + e.X - pos.X, Location.Y + e.Y - pos.Y);
                this.Left += e.X - pos.X;
                this.Top += e.Y - pos.Y;
                pos = new(e.X, e.Y);
            }
        }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            graphics.FillRectangle(Brushes.CadetBlue, new Rectangle(7 * radius / 10 - 100, 9 * radius / 10 - 25, 200, 50));
            graphics.FillRectangle(Brushes.CadetBlue, new Rectangle(5 * radius / 10 - 75, 6 * radius / 10 - 25, 150, 50));
            graphics.FillRectangle(Brushes.CadetBlue, new Rectangle(9 * radius / 10 - 75, 6 * radius / 10 - 25, 150, 50));
            base.OnPaint(e);
        }
    }
}
