using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System.Security.Policy;
using System.Windows.Forms;

namespace Pubs_App
{
    public partial class FrmGrid : Form
    {
        public FrmGrid()
        {
            InitializeComponent();
        }

        TitleList titles;
        TitleList titlesTemp;
        PublisherList publishers;

        private void FrmGrid_Load(object sender, EventArgs e)
        {
            titles = TitleManager.SelectAllTitles();
            titlesTemp = new();
            publishers = PublisherManager.SelectAllPublishers();

            dataGridView.DataSource = titles;
            dataGridView.Columns["State"].Visible = false;

            DataGridViewComboBoxColumn col = new();
            col.HeaderText = "Publisher";
            col.DataSource = publishers;
            col.DisplayMember = "Name";
            col.ValueMember = "PubID";
            col.DataPropertyName = "pubID";

            ///Bind its Value Member with Grid Data Source [ColName]
            dataGridView.Columns.Add(col);

            dataGridView.Columns["pubID"].Visible = false;

            ClientSize = new (dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)+100, ClientSize.Height);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.EndEdit();
            if (TitleManager.UpdateTitles(titles) && TitleManager.DeleteTitles(titlesTemp))
                MessageBox.Show("Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Some Data Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                titles = TitleManager.SelectAllTitles();
                dataGridView.DataSource = titles;
                titlesTemp = new();
            }
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row is DataGridViewRow row && row != null)
            {
                TitleManager.DeleteTitle(titles[row.Index]);
                titlesTemp.Add(titles[row.Index]);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Title? title = TitleManager.AddTitle("", "", DateTime.Now);
            
            if (title != null)
            {
                titles.Insert(dataGridView.CurrentRow.Index, title);
                dataGridView.CurrentCell = dataGridView.Rows[dataGridView.CurrentRow.Index - 1].Cells[0];
            }
        }
    }
}