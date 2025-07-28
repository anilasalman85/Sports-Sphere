using SportsSphere.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportsSphere.DataAccessLayer
{
    // Data Access Layer for StockRefill entities.
    public class DalStockRefills
    {
        // Saves stock refill information to the database.
        public static void SaveStockRefillInfo(StockRefill stockRefill)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Step 1: Update the product's stock quantity
                        SqlCommand updateProductCmd = new SqlCommand("UpdateProductStockQuantity", con, transaction);
                        updateProductCmd.CommandType = CommandType.StoredProcedure;
                        updateProductCmd.Parameters.AddWithValue("@ProductID", stockRefill.ProductID);
                        updateProductCmd.Parameters.AddWithValue("@QuantityAdded", stockRefill.QuantityAdded);
                        updateProductCmd.ExecuteNonQuery();

                        // Step 2: Save stock refill info
                        SqlCommand saveStockRefillCmd = new SqlCommand("CreateStockRefill", con, transaction);
                        saveStockRefillCmd.CommandType = CommandType.StoredProcedure;
                        saveStockRefillCmd.Parameters.AddWithValue("@ProductID", stockRefill.ProductID);
                        saveStockRefillCmd.Parameters.AddWithValue("@QuantityAdded", stockRefill.QuantityAdded);
                        saveStockRefillCmd.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Rollback the transaction in case of an exception
                        transaction.Rollback();
                        throw; // Re-throw the exception
                    }
                }
            }
        }

        // Deletes stock refill information from the database based on RefillID.
        public static void DeleteStockRefillInfo(int refillId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteStockRefill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RefillID", refillId);
                cmd.ExecuteNonQuery();
            }
        }

        // Updates stock refill information in the database.
        public static void UpdateStockRefillInfo(StockRefill stockRefill)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateStockRefill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RefillID", stockRefill.RefillID);
                cmd.Parameters.AddWithValue("@ProductID", stockRefill.ProductID);
                cmd.Parameters.AddWithValue("@QuantityAdded", stockRefill.QuantityAdded);
                cmd.ExecuteNonQuery();
            }
        }

        // Retrieves a list of all stock refills from the database.
        public static List<StockRefill> GetStockRefillInfo()
        {
            List<StockRefill> stockRefills = new List<StockRefill>();

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetStockRefills", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StockRefill stockRefill = new StockRefill
                        {
                            RefillID = reader.GetInt32(reader.GetOrdinal("RefillID")),
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            QuantityAdded = reader.GetInt32(reader.GetOrdinal("QuantityAdded"))
                        };

                        stockRefills.Add(stockRefill);
                    }
                }
            }

            return stockRefills;
        }
    }
}
