using AutoMapper;
using Calabonga.UnitOfWork;
using Company.Base.Enums;
using Company.Base.Infractructure.Repository;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.Infrastructure.ParseService;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.ViewModels.ParserViewModels;

namespace Company.Parser.Infrastructure.Managers;

public class ParserManager<TDbContext, TParserBackground> : IParserManager<TDbContext>
    where TDbContext : ParserDbContext
    where TParserBackground : ParserBackground<TDbContext>
{
    private readonly IBaseRepository<TDbContext, InfoParser> _repository;
    private readonly IParserProvider _provider;
    private readonly TParserBackground _parserBackground;
    private readonly IMapper _mapper;

    public ParserManager(
        IBaseRepository<TDbContext, InfoParser> repository,
        IParserProvider provider,
        TParserBackground parserBackground,
        IMapper mapper)

    {
        _repository = repository;
        _provider = provider;
        _parserBackground = parserBackground;
        _mapper = mapper;
    }

    private static string NotFoundMessageError(Guid id) => $"Entity with ID {id} not found.";
    private const string ActiveTaskMessageError = "The task is active. Changes are not possible.";

    public async Task CreateAsync(string userName)
    {
        var model = new InfoParser()
        {
            CreatedBy = userName,
            UpdatedBy = userName,
        };

        await _repository.CreateAsync(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        var parser = await _repository.GetByIdAsync(id);
        if (parser == null) throw new Exception(NotFoundMessageError(id));
        else if (parser.IsStart) throw new Exception(ActiveTaskMessageError);

        await _repository.DeleteAsync(parser);
    }

    public async Task<ParserViewModel> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception(NotFoundMessageError(id));

        return _mapper.Map<InfoParser, ParserViewModel>(entity);
    }

    public async Task<IPagedList<ParserViewModel>> GetPageAsync(int pageIndex = 0, int pageSize = 50, SortEnum typeSort = SortEnum.None)
    {
        var result = typeSort switch
        {
            SortEnum.OrderBy => await _repository.GetPageAsync(null, x => x.OrderBy(x => x.Id), null, pageIndex, pageSize),

            SortEnum.OrderByDescending => await _repository.GetPageAsync(null, x => x.OrderBy(x => x.Id), null, pageIndex, pageSize),

            _ => await _repository.GetPageAsync(null, null, null, pageIndex, pageSize)
        };

        return _mapper.Map<PagedList<InfoParser>, PagedList<ParserViewModel>>((PagedList<InfoParser>)result);
    }

    /// <summary>
    /// Добавть задачу в очередь на выполнение.
    /// </summary>
    /// <param name="id">Индентификатор задачи</param>
    /// <param name="userName">Имя пользователя внесшего последние изменения</param>
    /// <returns>Task.</returns>
    public async Task AddTaskQueueAsync(Guid id, string userName)
    {
        var parser = await _provider.GetByIdWithConfigurationsWithFieldsAsync(id);
        if (parser == null) throw new Exception(NotFoundMessageError(id));
        else if (parser.IsStart || parser.IsQueue) throw new Exception(ActiveTaskMessageError);
        else if (!parser.Configurations.Any()) throw new Exception($"The list of parser configurations is empty.The number of elements in the { nameof(parser.Configurations) } is zero.");
        foreach (var config in parser.Configurations)
        {
            if (!config.Fields.Any()) throw new Exception($"In this configuration ({config.Id}), there is no description of the fields for parsing.");
        }

        parser.IsQueue = true;
        parser.IsCompleted = false;
        parser.UpdatedBy = userName;

        await _repository.UpdateAsync(parser);
    }

    /// <summary>
    /// Удалить парсер из очереди.
    /// </summary>
    /// <param name="id">Индентификатор парсера.</param>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns>Task.</returns>
    /// <exception cref="Exception">Ошибка при проверки значений парсера.</exception>
    public async Task DeleteTaskQueueAsync(Guid id, string userName)
    {
        var parser = await _provider.GetByIdWithConfigurationsWithFieldsAsync(id);
        if (parser == null) throw new Exception(NotFoundMessageError(id));
        else if (parser.IsStart) throw new Exception(ActiveTaskMessageError);

        parser.IsQueue = false;
        parser.UpdatedBy = userName;

        await _repository.UpdateAsync(parser);
    }

    /// <summary>
    /// Остановить активную задачу.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns>Task.</returns>
    /// <exception cref="Exception">Активных задач нет.</exception>
    public async Task StopActiveTaskAsync(string userName)
    {
        var parser = await _provider.GetActiveBackgroundTaskAsync();
        if (parser == null) throw new Exception("There are no active tasks.");

        await _parserBackground.StopAsync(new CancellationToken());

        parser.IsStart = false;
        parser.IsCompleted = false;
        parser.IsStartUpdate = false;
        parser.CompletionTime = DateTime.UtcNow;
        await _repository.UpdateAsync(parser);

        await _parserBackground.StartAsync(new CancellationToken());
    }
}