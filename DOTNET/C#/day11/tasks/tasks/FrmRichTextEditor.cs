namespace tasks
{
    public partial class FrmRichTextEditor : Form
    {
        public FrmRichTextEditor()
        {
            InitializeComponent();
        }

        readonly OpenFileDialog openFileDialog = new();
        readonly SaveFileDialog saveFileDialog = new();
        readonly string fileFilter = "Rich Text Files|*.rtf|Text Files|*.txt";

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = fileFilter;
            openFileDialog.Title = "Select text file";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox.LoadFile(openFileDialog.FileName, (RichTextBoxStreamType)openFileDialog.FilterIndex-1);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = fileFilter;
            saveFileDialog.Title = "Save text file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveFileDialog.FileName, (RichTextBoxStreamType)saveFileDialog.FilterIndex-1);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => this.Close();

        private void FrmRichTextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to exit?", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        readonly FontDialog fontDialog = new();
        readonly ColorDialog colorDialog = new();

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = richTextBox.SelectionFont;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fontDialog.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = richTextBox.SelectionColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = colorDialog.Color;
            }
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            FrmAppend frmAppend = new();
            if (frmAppend.ShowDialog() == DialogResult.OK)
            {
                richTextBox.AppendText(frmAppend.UserText);
            }
        }
    }
}
