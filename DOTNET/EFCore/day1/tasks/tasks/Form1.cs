using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows.Forms;
using tasks.Context;

namespace tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosed += (sender, e) => Context?.Dispose();
        }

        pubsContext Context = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            Context.titles.Load();

            dataGridView.DataSource =
                Context.titles.Local.ToBindingList();

            Context.publishers.Load();

            DataGridViewComboBoxColumn col = new();
            col.HeaderText = "Publisher";
            col.DataSource = Context.publishers.Local.ToBindingList();
            col.DisplayMember = "pub_name";
            col.ValueMember = "pub_id";
            col.DataPropertyName = "pub_id";

            ///Bind its Value Member with Grid Data Source [ColName]
            dataGridView.Columns.Add(col);

            dataGridView.Columns["pub_id"].Visible = false;
            dataGridView.Columns["pub"].Visible = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.EndEdit();
                Context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Couldn't update");
            }
        }
    }
}