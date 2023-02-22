using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProductsDetailedView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection SqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable DtPrds;

        SqlCommand sqlcmdSelectAllCat;
        SqlDataAdapter DACategorie;
        DataTable DTCategories;

        SqlCommand sqlcmdSelectAllSup;
        SqlDataAdapter DASuppliers;
        DataTable DTSuppliers;

        BindingSource PrdBindingSource;

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
            sqlCmd = new SqlCommand("SelectAllProducts", SqlCn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlDA = new SqlDataAdapter(sqlCmd);
            DtPrds = new DataTable();

            SqlCommandBuilder commandBuilder = new(sqlDA);

            sqlDA.Fill(DtPrds);

            PrdBindingSource = new BindingSource(DtPrds, "");

            ///Simple Data Binding
            lblPrdID.DataBindings.Add("Text", PrdBindingSource, "ProductID");
            txtPrdName.DataBindings.Add("Text", PrdBindingSource, "ProductName");
            txtQuantity.DataBindings.Add("Text", PrdBindingSource, "QuantityPerUnit");
            checkDiscontinued.DataBindings.Add("Text", PrdBindingSource, "Discontinued");
            numStock.DataBindings.Add("Text", PrdBindingSource, "UnitsInStock");
            numPrice.DataBindings.Add("Text", PrdBindingSource, "UnitPrice");
            numOrder.DataBindings.Add("Text", PrdBindingSource, "UnitsOnOrder");
            numReorder.DataBindings.Add("Text", PrdBindingSource, "ReorderLevel");

            BindingNavigator bindingNavigator = new BindingNavigator(PrdBindingSource);
            this.Controls.Add(bindingNavigator);

            sqlcmdSelectAllCat = new("select CategoryID as CID , CategoryName As CName from Categories", SqlCn);
            DACategorie = new(sqlcmdSelectAllCat);
            DTCategories = new();
            DACategorie.Fill(DTCategories);

            cmbCategory.DataSource = DTCategories;
            cmbCategory.DisplayMember = "CName";
            cmbCategory.ValueMember = "CID";
            cmbCategory.DataBindings.Add("SelectedValue", PrdBindingSource, "CategoryID");


            sqlcmdSelectAllSup = new("select SupplierID as SID , CompanyName As CoName from Suppliers", SqlCn);
            DASuppliers = new(sqlcmdSelectAllSup);
            DTSuppliers = new();
            DASuppliers.Fill(DTSuppliers);

            cmbSupplier.DataSource = DTSuppliers;
            cmbSupplier.DisplayMember = "CoName";
            cmbSupplier.ValueMember = "SID";
            cmbSupplier.DataBindings.Add("SelectedValue", PrdBindingSource, "SupplierID");

            bindingNavigator.DeleteItem.Click += DeleteItem_Click;
        }

        private void DeleteItem_Click(object? sender, EventArgs e)
        {
            try
            {
                sqlDA.Update(DtPrds);
            }
            catch
            {
                MessageBox.Show("Couldn't delete data");
                PrdBindingSource.ResetBindings(true);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PrdBindingSource.EndEdit();
                sqlDA.Update(DtPrds);
            }
            catch
            {
                MessageBox.Show("Couldn't save data");
                PrdBindingSource.ResetBindings(true);
            }
        }
    }
}