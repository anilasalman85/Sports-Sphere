using SportsSphere.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SportsSphere.DataAccessLayer
{
    // Data Access Layer for ProductCategory entities.
    public class DalProductCategories
    {
        // Saves product category information to the database.
        public static void SaveProductCategoryInfo(ProductCategory category)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CreateProductCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryImageReference", category.CategoryImageReference);
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes product category information from the database based on CategoryID.
        public static void DeleteProductCategoryInfo(int categoryId)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteProductCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.ExecuteNonQuery();
            }
        }

        // Updates product category information in the database.
        public static void UpdateProductCategoryInfo(ProductCategory category)
        {
            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateProductCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryImageReference", category.CategoryImageReference);
                cmd.ExecuteNonQuery();
            }
        }

        // Retrieves a list of all product categories from the database.
        public static List<ProductCategory> GetProductCategoryInfo()
        {
            List<ProductCategory> categories = new List<ProductCategory>();

            using (SqlConnection con = DbConnectionString.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetProductCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductCategory category = new ProductCategory
                        {
                            CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                            CategoryName = reader.GetString(reader.GetOrdinal("CategoryName")),
                            CategoryImageReference = reader.IsDBNull(reader.GetOrdinal("CategoryImageReference"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("CategoryImageReference"))
                        };

                        categories.Add(category);
                    }
                }
            }

            return categories;
        }
    }
}
