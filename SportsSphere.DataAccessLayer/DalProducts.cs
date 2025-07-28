using SportsSphere.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportsSphere.DataAccessLayer
{
    // Data Access Layer for Product entities.
    public class DalProducts
    {
        // Saves product information to the database.
        public static void SaveProductInfo(Product product)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CreateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@ProductImageReference", product.ProductImageReference);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes product information from the database based on ProductID.
        public static void DeleteProductInfo(int productId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.ExecuteNonQuery();
            }
        }

        // Updates product information in the database.
        public static void UpdateProductInfo(Product product)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@ProductImageReference", product.ProductImageReference);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.ExecuteNonQuery();
            }
        }

        // Retrieves a list of all products from the database.
        public static List<Product> GetProductInfo()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                            ProductImageReference = reader.IsDBNull(reader.GetOrdinal("ProductImageReference"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("ProductImageReference")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("Description")),
                            Brand = reader.IsDBNull(reader.GetOrdinal("Brand"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("Brand"))
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        // Retrieves a list of products in a specific category from the database.
        public static List<Product> GetProductsInCategory(int categoryId)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetProductsByCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                ProductImageReference = reader.IsDBNull(reader.GetOrdinal("ProductImageReference"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("ProductImageReference")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Description")),
                                Brand = reader.IsDBNull(reader.GetOrdinal("Brand"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Brand"))
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        // Retrieves detailed information for a specific product by its identifier.
        public static Product GetProductDetailsById(int productId)
        {
            Product product = null;

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetProductById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity")),
                                ProductImageReference = reader.IsDBNull(reader.GetOrdinal("ProductImageReference"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("ProductImageReference")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Description")),
                                Brand = reader.IsDBNull(reader.GetOrdinal("Brand"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Brand"))
                            };
                        }
                    }
                }
            }

            return product;
        }
    }
}
