using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.Infrastructure.Working;
using Company.WebAPI.Infrastructure.Working.Base;
using Company.WebAPI.ViewModel.ParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers;

public class WorkParserManager : IWorkParserManager
{
    private readonly IRepository<ParserDbContext, WorkParser> _repository;
    private readonly IWorkParserProvider _provider;
    private readonly IMapper _mapper;

    private readonly BackgroundParser _backgroundParser;
    private readonly IBackgroundTaskQueue<BackgroundParser> _backgroundTaskQueue;

    public WorkParserManager(
        IRepository<ParserDbContext, WorkParser> repository,
        IWorkParserProvider provider,
        IMapper mapper, 
        BackgroundParser backgroundParser, 
        IBackgroundTaskQueue<BackgroundParser> backgroundTaskQueue)
    {
        _repository = repository;
        _provider = provider;
        _mapper = mapper;
        _backgroundParser = backgroundParser;
        _backgroundTaskQueue = backgroundTaskQueue;
    }

    public List<string> Errors { get; private set; } = new List<string>();

    public async Task<IList<WorkParserViewModel>?> GetAllAsync()
    {
        var entities = await _provider.GetAllWithDependencies();
        if (entities == null)
        {
            Errors.Add("The requested data was not found.");
            return null;
        }

        return _mapper.Map<IList<WorkParser>, IList<WorkParserViewModel>>(entities);
    }

    public async Task<bool> CreateAsync(Guid propertyParserId, string userName)
    {
        try
        {
            var entity = await _provider.GetByParserIdAsync(propertyParserId);
            if (entity != null) return false;

            entity = new WorkParser()
            {
                PropertyParserId = propertyParserId,
                CreatedBy = userName,
                UpdatedBy = userName
            };

            var result = await _repository.CreateAsync(entity);
            if (!result)
            {
                Errors.Add("An error occurred while registering a task.");
                return false;
            }

            _backgroundTaskQueue.QueueBackgroundWorkItem(token => _backgroundParser);

            return true;
        }
        catch
        {
            Errors.Add("An error occurred while registering a task.");
            return false;
        }
    }
}