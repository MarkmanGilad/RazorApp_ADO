using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;



namespace RazorApp_ADO.Model
{
    public class Helper
    {
        private string conString = "connection string";

        public Helper()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            conString = configuration.GetConnectionString("UsersDB");

        }
        public DataTable RetrieveTable(string SQLStr, string table)
        // Gets A table from the data base acording to the SELECT Command in SQLStr;
        // Returns DataTable with the Table.
        {
            // connect to DataBase
            SqlConnection con = new SqlConnection(conString);

            // Build SQL Query
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // Build DataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            // Build DataSet to store the data
            DataSet ds = new DataSet();

            // Get Data form DataBase into the DataSet
            ad.Fill(ds, table);


            return ds.Tables[table];
        }
    }
}
