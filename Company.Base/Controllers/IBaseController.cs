using Company.Base.Entities;
using Company.Base.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Company.Base.Controllers;

/// <summary>
/// Интерфейс базового контроллера.
/// </summary>
/// <typeparam name="CreateViewModel">Тип для создания.</typeparam>
/// <typeparam name="UpdateViewModel">Тип для обновления.</typeparam>
/// <typeparam name="ViewModel">Тип для отображения.</typeparam>
public interface IBaseController<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class, IPrimaryKey
    where ViewModel : class, IPrimaryKey
{
    const string CreateMethodName = "Create";
    const string UpdateMethodName = "Update";
    const string DeleteMethodName = "Delete";
    const string GetByIdMethodName = "GetById";
    const string GetPageMethodName = "GetPage";

    Task<IActionResult> CreateAsync([FromBody] CreateViewModel model);
    Task<IActionResult> UpdateAsync([FromBody] UpdateViewModel model);
    Task<IActionResult> DeleteAsync([FromQuery] Guid id);
    Task<IActionResult> GetByIdAsync([FromQuery] Guid id);
    Task<IActionResult> GetPageAsync([FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] SortEnum typeSort);
}