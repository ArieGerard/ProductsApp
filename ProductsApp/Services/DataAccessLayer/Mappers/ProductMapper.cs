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

    }
}
