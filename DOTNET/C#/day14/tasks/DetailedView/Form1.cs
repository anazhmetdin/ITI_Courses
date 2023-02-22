using DetailedView.Context;
using DetailedView.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace DetailedView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosed += (sender, e) => Context?.Dispose();
        }

        pubsContext Context = new();
        BindingNavigator bindingNavigator;
        BindingSource bs;

        private void Form1_Load(object sender, EventArgs e)
        {
            Context.titles.Load();
            Context.publishers.Load();

            bs = new(Context.titles.Local.ToBindingList(), "");


            ///Simple Data Binding
            lblID.DataBindings.Add("Text", bs, "title_id");
            txtTitle.DataBindings.Add("Text", bs, "title1");
            txtType.DataBindings.Add("Text", bs, "type");
            numPrice.DataBindings.Add("Text", bs, "price");
            numAdvance.DataBindings.Add("Text", bs, "advance");
            numRoyality.DataBindings.Add("Text", bs, "royalty");
            numSales.DataBindings.Add("Text", bs, "ytd_sales");
            txtNotes.DataBindings.Add("Text", bs, "notes");
            datePub.DataBindings.Add("Text", bs, "pubdate");

            bindingNavigator = new BindingNavigator(bs);
            this.Controls.Add(bindingNavigator);

            cmbPublisher.DataSource = Context.publishers.Local.ToBindingList();
            cmbPublisher.DisplayMember = "pub_name";
            cmbPublisher.ValueMember = "pub_id";
            cmbPublisher.DataBindings.Add("SelectedValue", bs, "pub_id");

            bs.AddingNew += (sender, e) =>
                e.NewObject = new title() { title_id = ""};

            bindingNavigator.DeleteItem.Click += (s, e) => BtnSave.PerformClick();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Couldn't save changes");
            }

        }
    }
}