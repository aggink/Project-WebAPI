using Company.WebAPI.Controllers.ProductControllers.Base;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Interfaces;
using Company.WebAPI.ViewModels.ProductViewModels.ChipCartProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ProductControllers;

[Route("product/chipcart")]
public class ChipCartProductController : BaseProductController
    <CreateChipCartProductViewModel, UpdateChipCartProductViewModel, ChipCartProductViewModel>
{


    public ChipCartProductController(
        IProductManager<CreateChipCartProductViewModel, UpdateChipCartProductViewModel, ChipCartProductViewModel> manager) 
        : base(manager)
    {

    }

}