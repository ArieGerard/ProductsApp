/*
 *Arie Gerard 
 * CST - 350
 * Nov 10, 2024
 * ProductsApp
 * Activity 5 Guide
 */
using ProductsApp.Models.DomainModels;
using ProductsApp.Models.ViewModels;
using ProductsApp.Services.DataAccessLayer;
using ProductsApp.Services.DataAccessLayer.Mappers;
using System.Reflection.Metadata.Ecma335;

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

        /// <summary>
        /// Get a list of all products in the databse
        /// </summary>
        /// <returns></returns>
        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductDomainModel> domainProducts = new List<ProductDomainModel>();
            List<ProductViewModel> viewProducts = new List<ProductViewModel>();
            // Get all products from the database
            domainProducts = _productDAO.GetAllProducts();
            // Map the domain products to view products
            viewProducts = ProductMapper.FromDomainModelList(domainProducts);
            // return the list of view products
            return viewProducts;

        }
    }
}
