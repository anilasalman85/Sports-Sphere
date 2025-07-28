using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;

namespace SportsSphere.DataAccessLayer
{
    // Data Access Layer for User entities.
    public class DalUsers
    {
        // Saves user information to the database.
        public static void SaveUserInfo(User user)
        {
            SqlConnection con = DbConnectionString.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("CreateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            cmd.ExecuteNonQuery(); // To save and update
            con.Close();
        }

        // Deletes user information from the database based on UserID.
        public static void DeleteUserInfo(int userId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        // Updates user information in the database.
        public static void UpdateUserInfo(User user)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        // Retrieves a list of all users from the database.
        public static List<User> GetUserInfo()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetUsers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"))
                            };

                            users.Add(user); //add to our list
                        }
                    }
                }
                con.Close();
            }

            return users;
        }
    }
}
