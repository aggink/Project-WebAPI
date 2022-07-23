using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers.ParserControllers;

[ApiController]
[Route("parser/work")]
public class WorkParserController : Controller
{
    private readonly IWorkParserManager _manager;

    public WorkParserController(IWorkParserManager manager)
    {
        _manager = manager;
    }

    private readonly string _userName = "admin";

    [HttpGet]
    public async Task<IActionResult> GetAllBackgroundWorkAsync()
    {
        var result = await _manager.GetAllAsync();
        if (result == null) return BadRequest();

        return Json(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBackgroundWork(Guid id)
    {
        var result = await _manager.CreateAsync(id, _userName);
        if (!result) return BadRequest();
        
        return Json(result);
    }
}