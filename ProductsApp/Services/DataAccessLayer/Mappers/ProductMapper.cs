/*
 *Arie Gerard 
 * CST - 350
 * Nov 10, 2024
 * ProductsApp
 * Activity 5 Guide
 */
using ProductsApp.Models.DomainModels;
using ProductsApp.Models.ViewModels;

namespace ProductsApp.Services.DataAccessLayer.Mappers
{
    /// <summary>
    /// Static class for mapping Product 
    /// </summary>
    public class ProductMapper
    {
        public static List<ProductViewModel> FromDomainModelList(List<ProductDomainModel> domainModels)
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            ProductViewModel viewModel;
            foreach (ProductDomainModel domainModel in domainModels)
            {
                viewModel = new ProductViewModel() 
                {  
                    Id = domainModel.Id,
                    Name = domainModel.Name,
                    Description = domainModel.Description,
                    Price = domainModel.Price
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        /// <summary>
        /// Maps a single ViewModel to a DomainModel
        /// </summary>
        /// <param name="viewModel">The view model to map</param>
        /// <returns>A domain model</returns>
        public static ProductDomainModel ToDomainModel(ProductViewModel viewModel)
        {
            return new ProductDomainModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price
            };
        }

        /// <summary>
        /// Maps a single DomainModel to a ViewModel
        /// </summary>
        /// <param name="domainModel">The domain model to map</param>
        /// <returns>A view model</returns>
        public static ProductViewModel ToViewModel(ProductDomainModel domainModel)
        {
            return new ProductViewModel()
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Description = domainModel.Description,
                Price = domainModel.Price
            };
        }

    }
}
