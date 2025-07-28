using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;

namespace SportsSphere.DataAccessLayer
{
    // Data Access Layer for Admin entities.
    public class DalAdmins
    {
        // Saves admin information to the database.
        public static void SaveAdminInfo(Admin admin)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CreateAdmin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", admin.Username);
                    cmd.Parameters.AddWithValue("@Password", admin.Password);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Deletes admin information from the database based on AdminID.
        public static void DeleteAdminInfo(int adminId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteAdmin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminID", adminId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Updates admin information in the database.
        public static void UpdateAdminInfo(Admin admin)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateAdmin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);
                    cmd.Parameters.AddWithValue("@Username", admin.Username);
                    cmd.Parameters.AddWithValue("@Password", admin.Password);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Retrieves a list of all admins from the database.
        public static List<Admin> GetAdminInfo()
        {
            List<Admin> admins = new List<Admin>();

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetAdmins", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Admin admin = new Admin
                            {
                                AdminID = reader.GetInt32(reader.GetOrdinal("AdminID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };

                            admins.Add(admin);
                        }
                    }
                }
            }

            return admins;
        }
    }
}
