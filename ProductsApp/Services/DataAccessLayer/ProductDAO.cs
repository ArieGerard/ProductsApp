/*
 *Arie Gerard 
 * CST - 350
 * Nov 10, 2024
 * ProductsApp
 * Activity 5 Guide
 */
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProductsApp.Models.DomainModels;

namespace ProductsApp.Services.DataAccessLayer
{
    /// <summary>
    /// Data Acess Object for Product
    /// </summary>
    public class ProductDAO
    {
        private readonly string _connectionString;
        string? query;

        public ProductDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        /// <summary>
        /// Method to get all products
        /// </summary>
        /// <returns></returns>
        public List<ProductDomainModel> GetAllProducts()
        {
            // Declare and Init
            List<ProductDomainModel> products = new List<ProductDomainModel>();
            ProductDomainModel product;

            // Define the query 
            query = "SELECT * FROM dbo.Product";
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

        /// <summary>
        /// Method to create a new product
        /// </summary>
        /// <param name="product">The product domain model to create</param>
        /// <returns>The created product with its generated ID</returns>
        public ProductDomainModel CreateProduct(ProductDomainModel product)
        {
            // Define the query to insert a new product and return the generated ID
            query = @"INSERT INTO dbo.Product (Name, Description, Price) 
                      OUTPUT INSERTED.Id, INSERTED.Name, INSERTED.Description, INSERTED.Price
                      VALUES (@Name, @Description, @Price)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", product.Price);

                    // Execute the command and get the inserted product
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ProductDomainModel()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) 
                                    ? string.Empty 
                                    : reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price"))
                            };
                        }
                    }
                }
            }

            // If we get here, something went wrong
            throw new InvalidOperationException("Failed to create product.");
        }

    }
}
