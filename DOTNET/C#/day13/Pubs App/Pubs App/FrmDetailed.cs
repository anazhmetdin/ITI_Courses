using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pubs_App
{
    public partial class FrmDetailed : Form
    {
        public FrmDetailed()
        {
            InitializeComponent();
        }

        TitleList titles;
        TitleList titlesTemp;
        PublisherList publishers;
        BindingNavigator bindingNavigator;

        private void FrmDetailed_Load(object sender, EventArgs e)
        {
            titles = TitleManager.SelectAllTitles();
            titlesTemp = new();
            publishers = PublisherManager.SelectAllPublishers();

            titlesBindingSource.DataSource = titles;
            publishersBindingSource.DataSource = publishers;

            bindingNavigator = new BindingNavigator(titlesBindingSource);
            this.Controls.Add(bindingNavigator);

            ///Simple Data Binding
            lblID.DataBindings.Add("Text", titlesBindingSource, "TitleID");
            txtTitle.DataBindings.Add("Text", titlesBindingSource, "BookTitle");
            txtType.DataBindings.Add("Text", titlesBindingSource, "Type");
            numPrice.DataBindings.Add("Value", titlesBindingSource, "price", true, DataSourceUpdateMode.OnPropertyChanged);
            numAdvance.DataBindings.Add("Value", titlesBindingSource, "Advance", true, DataSourceUpdateMode.OnPropertyChanged);
            numRoyality.DataBindings.Add("Value", titlesBindingSource, "Royalty", true, DataSourceUpdateMode.OnPropertyChanged);
            numSales.DataBindings.Add("Value", titlesBindingSource, "Sales", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNotes.DataBindings.Add("Text", titlesBindingSource, "Notes");
            datePub.DataBindings.Add("Value", titlesBindingSource, "PubDate", true, DataSourceUpdateMode.OnPropertyChanged);

            cmbPublisher.DataSource = publishers;
            cmbPublisher.DisplayMember = "Name";
            cmbPublisher.ValueMember = "PubID";
            cmbPublisher.DataBindings.Add("SelectedValue", titlesBindingSource, "PubID");

            bindingNavigator.DeleteItem.MouseDown += DeleteItem_Click;

            titlesBindingSource.AllowNew = true;
            titlesBindingSource.AddingNew += TitlesBindingSource_AddingNew;

        }

        private void TitlesBindingSource_AddingNew(object? sender, AddingNewEventArgs e)
        {
            e.NewObject = TitleManager.AddTitle("", "", DateTime.Now);
        }

        private void AddNewItem_Click(object? sender, EventArgs e)
        {
            Title? title = TitleManager.AddTitle("", "", DateTime.Now);
            
            if (title != null)
            {
                titles.Add(title);
            }
        }

        private void DeleteItem_Click(object? sender, EventArgs e)
        {
            if (titlesBindingSource.Current is Title title)
            {
                TitleManager.DeleteTitle(title);
                titlesTemp.Add(title);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            titlesBindingSource.EndEdit();
            if (TitleManager.UpdateTitles(titles) && TitleManager.DeleteTitles(titlesTemp))
                MessageBox.Show("Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Some Data Failed to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                titles = TitleManager.SelectAllTitles();
                titlesBindingSource.DataSource = titles;
                titlesTemp = new();
            }
        }
    }
}
