
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using ProductsApp.Models.DomainModels;

namespace ProductsApp.Services.DataAccessLayer
{
    /// <summary>
    /// Data Acess Object for Product
    /// </summary>
    public class ProductDAO
    {
        private readonly string _connectionString = @"Data Source=np:\\\\.\\pipe\\LOCALDB#1370C7B9\\tsql\\query;Initial Catalog=ShopTillYouDrop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        string query;

        public List<ProductDomainModel> GetAllProducts()
        {
            // Declare and Init
            List<ProductDomainModel> products = new List<ProductDomainModel>();
            ProductDomainModel product;

            // Define the query 
            query = "SELECT * FROM dbo.Products";
            // Set up a SQL command
           using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // Create a reader and execute the command
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the reader
                        while (reader.Read())
                        {
                            // Create a new product object
                            product = new ProductDomainModel()
                            {
                               Id = reader.GetInt32(reader.GetOrdinal("Id")),
                               Name = reader.GetString(reader.GetOrdinal("Name")),
                               Description = reader.GetString(reader.GetOrdinal("Description")),
                               Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                            };
                            // Add the product to the list
                            products.Add(product);
                        }
                    }
                }
            }

                // Return the list of products
                return products;
        }

    }
}
