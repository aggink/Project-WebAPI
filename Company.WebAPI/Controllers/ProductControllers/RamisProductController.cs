using Company.WebAPI.Controllers.ProductControllers.Base;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.ViewModels.ProductViewModels.RamisProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ProductControllers;

[Route("product/ramis")]
public class RamisProductController : BaseProductController
    <CreateRamisProductViewModel, UpdateRamisProductViewModel, RamisProductViewModel>
{


    public RamisProductController(
        IProductManager<CreateRamisProductViewModel, UpdateRamisProductViewModel, RamisProductViewModel> manager) 
        : base(manager)
    {

    }

}