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
    }
}
