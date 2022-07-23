using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Mappers.Base;
using Company.WebAPI.ViewModel.ParserViewModels;

namespace Company.WebAPI.Infrastructure.Mappers.ParserMappers;

public class WorkParserMapperConfig : BaseMapperConfig
{
    public WorkParserMapperConfig()
    {
        CreateMap<WorkParser, WorkParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.IsStarted, o => o.MapFrom(m => m.IsStart))
            .ForMember(x => x.IsCompleted, o => o.MapFrom(m => m.IsCompleted))
            .ForMember(x => x.StartTime, o => o.MapFrom(m => m.StartTime))
            .ForMember(x => x.CompletionTime, o => o.MapFrom(m => m.CompletionTime))
            .ForMember(x => x.PropertyParser, o => o.MapFrom(m => m.PropertyParser));

        CreateMap<WorkParserViewModel, WorkParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.PropertyParserId, o => o.MapFrom(m => m.PropertyParserId))
            .ForMember(x => x.IsStart, o => o.MapFrom(m => m.IsStarted))
            .ForMember(x => x.IsCompleted, o => o.MapFrom(m => m.IsCompleted))
            .ForMember(x => x.StartTime, o => o.MapFrom(m => m.StartTime))
            .ForMember(x => x.CompletionTime, o => o.MapFrom(m => m.CompletionTime))
            .ForMember(x => x.PropertyParser, o => o.MapFrom(m => m.PropertyParser))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());
    }
}