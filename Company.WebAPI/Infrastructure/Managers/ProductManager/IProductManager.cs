using Company.Base.Infractructure.Manager;
using Company.WebAPI.ViewModels.ProductViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers;

public interface IProductManager : IBaseManager<CreateProductViewModel, UpdateProductViewModel, ProductViewModel>
{
    
}