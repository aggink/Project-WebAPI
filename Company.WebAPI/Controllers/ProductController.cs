using Company.Base.Controllers;
using Company.Data.DbContexts;
using Company.Entity;
using Company.WebAPI.Infrastructure.Managers.ProductManagers;
using Company.WebAPI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers;

[Route("product")]
public class ProductController : BaseController<CreateProductViewModel, UpdateProductViewModel, ProductViewModel, Product, CatalogDbContext>
{
    private new readonly IProductManager _manager;
    public ProductController(
        IProductManager manager)
        : base(manager)
    {
        _manager = manager;
    }

    [NonAction]
    public override async Task<IActionResult> CreateAsync(CreateProductViewModel model)
    {
        return await base.CreateAsync(model);
    }

}