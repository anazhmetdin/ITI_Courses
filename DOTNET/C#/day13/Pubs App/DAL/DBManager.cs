using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public class DBManager
    {
        SqlConnection sqlCN;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable Dt;

        public DBManager()
        {
            try
            {
                sqlCN = new SqlConnection(ConfigurationManager.ConnectionStrings["Pubs"].ConnectionString);
                sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlCN;
                sqlDA = new(sqlCmd);
                Dt = new();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public int ExecuteNonQuery(string SPName, Dictionary<String, object> ParmLst)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public object ExecuteScalar(string SPName)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteScalar();

            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public object ExecuteScalar(string SPName, Dictionary<String, object> ParmLst)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteScalar();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                Dt.Clear();
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                sqlDA.Fill(Dt);

                return Dt;
            }
            catch
            {
                return new();
            }
        }

        public DataTable ExecuteDataTable(string SPName, Dictionary<String, object> ParmLst)
        {
            try
            {
                Dt.Clear();
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;
                
                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                sqlDA.Fill(Dt);

                return Dt;
            }
            catch
            {
                return new();
            }
        }
    }
}