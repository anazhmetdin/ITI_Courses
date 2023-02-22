using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProductsView
{
    public partial class FrmGridView : Form
    {
        public FrmGridView()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        SqlCommand sqlcmdSelectAllCat;
        SqlDataAdapter DACategorie;
        DataTable DTCategories;

        SqlCommand sqlcmdSelectAllSup;
        SqlDataAdapter DASuppliers;
        DataTable DTSuppliers;

        private void FrmGridView_Load(object sender, EventArgs e)
        {
            sqlConnection = new(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
            sqlCommand = new("Select * from Products", sqlConnection);
            sqlDataAdapter = new(sqlCommand);
            dataTable = new();

            SqlCommandBuilder commandBuilder = new(sqlDataAdapter);

            sqlDataAdapter.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.Columns[0].ReadOnly = true;

            sqlcmdSelectAllCat = new("select CategoryID as CID , CategoryName As CName from Categories", sqlConnection);
            DACategorie = new(sqlcmdSelectAllCat);
            DTCategories = new();
            DACategorie.Fill(DTCategories);

            DataGridViewComboBoxColumn col = new();
            col.HeaderText = "Category";
            col.DataSource = DTCategories;
            col.DisplayMember = "CName";
            col.ValueMember = "CID";
            col.DataPropertyName = "CategoryID";
            
            ///Bind its Value Member with Grid Data Source [ColName]
            GridView.Columns.Add(col);
            GridView.Columns["CategoryID"].Visible = false;

            sqlcmdSelectAllSup = new("select SupplierID as SID , CompanyName As CoName from Suppliers", sqlConnection);
            DASuppliers = new(sqlcmdSelectAllSup);
            DTSuppliers = new();
            DASuppliers.Fill(DTSuppliers);

            DataGridViewComboBoxColumn colS = new();
            colS.HeaderText = "Supplier";
            colS.DataSource = DTSuppliers;
            colS.DisplayMember = "CoName";
            colS.ValueMember = "SID";
            colS.DataPropertyName = "SupplierID";

            ///Bind its Value Member with Grid Data Source [ColName]
            GridView.Columns.Add(colS);

            GridView.Columns["SupplierID"].Visible = false;
        }

        private void GridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sqlDataAdapter.Update(dataTable);
        }
    }
}