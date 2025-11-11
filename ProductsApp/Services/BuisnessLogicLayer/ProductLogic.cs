using ProductsApp.Services.DataAccessLayer;

namespace ProductsApp.Services.BuisnessLogicLayer
{

    /// <summary>
    /// Business logic class for products
    /// </summary>
    public class ProductLogic
    {
        // class level variables
        private ProductDAO _productDAO;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="productDAO"></param>
        public ProductLogic(ProductDAO productDAO)
        {
            // set the parameter to the class level variable
            _productDAO = productDAO;
        }
    }
}
