using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Models.ViewModels
{
    /// <summary>
    /// View Model for Product
    /// </summary>
    public class ProductViewModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "unknown";
        public string Description { get; set; } = " unknown";

        // Specify that the data type is currency 
        [DataType(DataType.Currency)]
        // Customize the display name for the header 
        [DisplayName("Cost to Customer")] 
        public decimal Price { get; set; } = 0.0M;
    }
}
