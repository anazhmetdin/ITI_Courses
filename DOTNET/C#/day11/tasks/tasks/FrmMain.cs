namespace tasks
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnDialogs_Click(object sender, EventArgs e)
        {
            FrmRichTextEditor frmRichTextEditor = new();
            frmRichTextEditor.ShowDialog();
        }

        private void btnPain_Click(object sender, EventArgs e)
        {
            FrmPaint frmPaint = new FrmPaint();
            frmPaint.ShowDialog();
        }

        private void BtnDragable_Click(object sender, EventArgs e)
        {
            FrmDragable frmDragable = new FrmDragable();
            frmDragable.ShowDialog();
        }

        private void BtnMickey_Click(object sender, EventArgs e)
        {
            FrmMickey frmMickey = new FrmMickey();
            frmMickey.ShowDialog();
        }

        private void BtnBall_Click(object sender, EventArgs e)
        {
            FrmBall frmBall = new FrmBall();
            frmBall.ShowDialog();
        }
    }
}