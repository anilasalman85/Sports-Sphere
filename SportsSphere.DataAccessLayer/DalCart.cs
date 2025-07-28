using SportsSphere.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportsSphere.DataAccessLayer
{
    // Data Access Layer for handling shopping cart items.
    public class CartItemsDal
    {
        // Adds a product to the shopping cart.
        public void AddToCart(int productId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertCartItem", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Retrieves a list of cart items for a specific user.
        public List<CartItemModel> GetCartItems(int userId)
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetCartItems", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Add parameter for user ID if needed

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartItemModel cartItem = new CartItemModel
                            {
                                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                // Add other properties as needed
                            };

                            cartItems.Add(cartItem);
                        }
                    }
                }
            }
            return cartItems;
        }

        // Deletes a specific cart item based on its product ID.
        public void DeleteCartItemByProductId(int productId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DeleteCartItemByProductId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine($"Deleted cart item with ProductId: {productId}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting cart item: {ex.Message}");
                    throw new Exception("Error deleting cart item.", ex);
                }
            }
        }

        // Additional methods for CRUD operations on cart items can be added here
    }
}
