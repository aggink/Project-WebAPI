using Company.Base.Controllers;
using Company.Data.DbContexts;
using Company.Entity;
using Company.WebAPI.Infrastructure.Managers.ParseValuesProductManager;
using Company.WebAPI.ViewModels.ParseValuesProductViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers;

[Route("product/parsevalue")]
public class ParseValuesProductController : BaseController<CreateParseValuesProductViewModel, UpdateParseValuesProductViewModel, ParseValuesProductViewModel, ParseValuesProduct, CatalogDbContext>
{
    private new readonly IParseValuesProductManager _manager;
    public ParseValuesProductController(
        IParseValuesProductManager manager)
        : base(manager)
    {
        _manager = manager;
    }

    [NonAction]
    public override async Task<IActionResult> CreateAsync(CreateParseValuesProductViewModel model)
    {
        return await base.CreateAsync(model);
    }
}