/*
 *Arie Gerard 
 * CST - 350
 * Nov 10, 2024
 * ProductsApp
 * Activity 5 Guide
 */

namespace ProductsApp.Models.DomainModels
{
    /// <summary>
    /// Domain Model for Product
    /// </summary>
    public class ProductDomainModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "unknown";
        public string Description { get; set; } = " unknown";
        public decimal Price { get; set; } = 0.0M;
    }
}
