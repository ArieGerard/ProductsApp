/*
 *Arie Gerard 
 * CST - 350
 * Nov 10, 2024
 * ProductsApp
 * Activity 5 Guide
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProductsApp.Models.ViewModels;
using ProductsApp.Services.BuisnessLogicLayer;

namespace ProductsApp.Controllers
{
    /// <summary>
    /// Controller for Products
    /// </summary>
    public class ProductsController : Controller
    {
        private ProductLogic _productLogic;

        /// <summary>
        /// Constructor for ProductsController
        /// </summary>
        /// <param name="productLogic"></param>
        public ProductsController(ProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        /// <summary>
        /// Constructor for ProductsController
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(new List<ProductViewModel>());
        }
        
        /// <summary>
        /// Get a list of products to display 
        /// </summary>
        /// <returns></returns>
        public IActionResult GetProducts()
        {
            // Get the list of products from the BLL
            List<ProductViewModel> products = _productLogic.GetAllProducts();
            // Retun the Index View with the products list
            return View("Index", products); 
        }
    }
}
