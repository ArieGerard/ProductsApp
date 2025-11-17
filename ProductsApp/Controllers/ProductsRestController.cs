/*
 * Arie Gerard 
 * CST - 250 
 * 09=8/01/2025
 * Activity  7 
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProductsApp.Models.ViewModels;
using ProductsApp.Services.BuisnessLogicLayer;

namespace ProductsApp.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsRestController : ControllerBase
    {
        // Class level varibles 
        private ProductLogic _productLogic;

        /// <summary>
        /// Constructor for ProductsRestController
        /// </summary>
        /// <param name="productLogic"></param>
        public ProductsRestController(ProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            //  Get the full list of products from the business logic layer
            List<ProductViewModel> products = _productLogic.GetAllProducts();

            // Return an Ok result
            return Ok(products);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductViewModel product)
        {
            // Call the CreateProduct method  in product Logic 
            // I think this was a challange that we did not have to do 
            // _productLogic.CreateProduct(product);

            // Return an Ok result
            return Ok();

        }
    }
}
