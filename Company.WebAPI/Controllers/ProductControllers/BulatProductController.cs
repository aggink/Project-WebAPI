using Company.WebAPI.Controllers.ProductControllers.Base;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Interfaces;
using Company.WebAPI.ViewModels.ProductViewModels.BulatProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ProductControllers;

[Route("product/bulat")]
public class BulatProductController : BaseProductController
    <CreateBulatProductViewModel, UpdateBulatProductViewModel, BulatProductViewModel>
{
    
    
    public BulatProductController(
        IProductManager<CreateBulatProductViewModel, UpdateBulatProductViewModel, BulatProductViewModel> manager)
        : base(manager)
    {
        
    }

}