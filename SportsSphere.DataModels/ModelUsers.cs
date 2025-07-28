using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsSphere.DataModels
{
    // Represents a user in the system.
    public class User
    {
        // Unique identifier for each user.
        public int UserID { get; set; }

        // The username used by the user for authentication.
        public string? Username { get; set; }

        // The password used by the user for authentication.
        // Note: Consider using secure methods for password handling in a real-world scenario.
        public string? Password { get; set; }

        // The email address associated with the user.
        public string? Email { get; set; }

        // Indicates whether the user has administrative privileges.
        public bool IsAdmin { get; set; }
    }
}
