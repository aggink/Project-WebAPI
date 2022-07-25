using Company.WebAPI.Controllers.ProductControllers.Base;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;
using Company.WebAPI.ViewModels.ProductViewModels.ZipZipProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ProductControllers;

[Route("product/zipzip")]
public class ZipZipProductController : BaseProductController
    <CreateZipZipProductViewModel, UpdateZipZipProductViewModel, ZipZipProductViewModel>
{


    public ZipZipProductController(
        IProductManager<CreateZipZipProductViewModel, UpdateZipZipProductViewModel, ZipZipProductViewModel> manager) 
        : base(manager)
    {
    }

}