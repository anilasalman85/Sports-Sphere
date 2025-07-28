using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSphere.DataModels
{
    // The Admin class represents the data model for administrative users.
    public class Admin
    {
        // Unique identifier for each admin.
        public int AdminID { get; set; }

        // The username used by the admin for authentication.
        public string? Username { get; set; }

        // The password used by the admin for authentication.
        // Note: Consider using secure methods for password handling in a real-world scenario.
        public string? Password { get; set; }

        // The email address associated with the admin.
        public string? Email { get; set; }
    }
}
