using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.Parser;
using Company.Parser.Interfaces;
using Company.WebAPI.Infrastructure.EventLogging;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.Infrastructure.Services.ParserService;
using Company.WebAPI.Infrastructure.Working.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Working;

/// <summary>
/// Фоновая задача парсера веб-сайтов
/// </summary>
public class BackgroundParser : IBackground
{
    private readonly ILogger<BackgroundParser> _logger;

    public BackgroundParser(ILogger<BackgroundParser> logger)
    {
        _logger = logger;
    }

    public async Task ExecuteAsync(IServiceProvider serviceProvider, CancellationToken token)
    {
        using var scope = serviceProvider.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork<ParserDbContext>>();

        var repository = scope.ServiceProvider.GetRequiredService<IRepository<ParserDbContext, WorkParser>>();

        try
        {
            var workParser = await unitOfWork.GetRepository<WorkParser>().GetFirstOrDefaultAsync(
                predicate: x => x.IsStart, 
                orderBy: x => x.OrderBy(i => i.UpdatedBy));
            if (workParser == null) throw new ArgumentNullException(nameof(workParser));

            var propertyParser = await unitOfWork.GetRepository<PropertyParser>().GetFirstOrDefaultAsync(
                predicate: x => x.Id.Equals(workParser.PropertyParserId), 
                include: i => i.Include(x => x.ParserParams));
            if (propertyParser == null) throw new ArgumentNullException(nameof(propertyParser));
            if(propertyParser.ParserParams == null) throw new ArgumentNullException(nameof(propertyParser.ParserParams));

            workParser.StartTime = DateTime.UtcNow;
            workParser.IsStart = true;

            var entity = await repository.UpdateAsync(workParser);
            if (!entity)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            #region ParserWork

            IParserWorker<PropertyParser>? parserWork = null;

            if (propertyParser.TypeName.Equals(nameof(BulatParserPage)))
                parserWork = scope.ServiceProvider.GetRequiredService<ParserWorker<BulatParserPage, PropertyParser>>();

            if (propertyParser.TypeName.Equals(nameof(RamisParserPage)))
                parserWork = scope.ServiceProvider.GetRequiredService<ParserWorker<RamisParserPage, PropertyParser>>();

            if (propertyParser.TypeName.Equals(nameof(ChipCartParserPage)))
                parserWork = scope.ServiceProvider.GetRequiredService<ParserWorker<ChipCartParserPage, PropertyParser>>();

            if (propertyParser.TypeName.Equals(nameof(ZipZipParserPage)))
                parserWork = scope.ServiceProvider.GetRequiredService<ParserWorker<ZipZipParserPage, PropertyParser>>();

            if (parserWork! == null) throw new ArgumentNullException(nameof(parserWork));
            parserWork.Worker(propertyParser);

            Events.BackgroundWorkCreated(_logger, WorkType.WebSiteParsing.ToString(), workParser.Id.ToString());

            #endregion

            workParser = await unitOfWork.GetRepository<WorkParser>().GetFirstOrDefaultAsync(
                predicate: x => x.IsStart, 
                orderBy: x => x.OrderBy(i => i.UpdatedBy));
            if (workParser == null) throw new ArgumentNullException(nameof(workParser));

            workParser.IsStart = false;
            workParser.IsCompleted = true;
            workParser.CompletionTime = DateTime.UtcNow;

            entity = await repository.UpdateAsync(workParser);
            if (!entity)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Events.BackgroundWorkComleted(_logger, WorkType.WebSiteParsing.ToString(), workParser.Id.ToString());
        }
        catch (Exception ex)
        {
            var workParser = await unitOfWork.GetRepository<WorkParser>().GetFirstOrDefaultAsync(
                predicate: x => x.IsStart, 
                orderBy: x => x.OrderBy(i => i.UpdatedBy));
            workParser!.IsStart = false;

            var entity = await repository.UpdateAsync(workParser);
            if (!entity)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Events.BackgroundWorkFailed(_logger, WorkType.WebSiteParsing.ToString(), workParser.Id.ToString(), ex);     
        }
    }
}
