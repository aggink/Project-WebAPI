using Company.Data.DbContexts;
using Company.Entity;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.ParseService.Interfaces;
using Company.Parser.Infrastructure.ParseService;

namespace Company.WebAPI.Infrastructure.Working;

/// <summary>
/// 
/// </summary>
public class ParserBackgroundWorker : ParserBackground<CatalogDbContext>
{
    public ParserBackgroundWorker(IServiceProvider serviceProvider, ILogger<ParserBackgroundWorker> logger) 
        : base(serviceProvider, logger) { }

    protected override async Task ExecuteParseAsync(IParserWorker parserWorker, InfoParser parser, CancellationToken token)
    {
        await parserWorker.RunParseAsync<ParseValuesProduct>(parser, token);
    }

    protected override async Task UpdateExecutedParseAsync(IParserWorker parserWorker, InfoParser parser, CancellationToken token)
    {
        await parserWorker.RunUpdateParseAsync<ParseValuesProduct>(parser, token);
    }
}