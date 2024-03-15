using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms; // Adicione esta linha para acessar os controles do Form

namespace Prova
{
    public class DatabaseOperations
    {
        public static void GetAll(DataGridView gridView, string query)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BDFarinha.mdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    gridView.DataSource = dataTable; // Vincula os dados ao DataGridView
                }
            }
        }
    }
}
