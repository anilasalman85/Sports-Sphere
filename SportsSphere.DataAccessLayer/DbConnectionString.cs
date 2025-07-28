using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSphere.DataAccessLayer
{
    // Utility class for managing database connections.
    public class DbConnectionString
    {
        // Gets a SqlConnection object with the connection string.
        public static SqlConnection GetConnection()
        {
            // Use a SqlConnectionStringBuilder for better connection string management.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "TALHA\\SQLEXPRESS",
                InitialCatalog = "SportsSphere",
                IntegratedSecurity = true
            };

            // Create and return the SqlConnection object.
            SqlConnection con = new SqlConnection(builder.ConnectionString);
            return con;
        }
    }
}
