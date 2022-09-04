using Company.Base.Mapper;
using Company.Parser.Entities;
using Company.Parser.ViewModels.ParserViewModels;

namespace Company.Parser.Infrastructure.Mappers;

public class ParserMapperConfig : MapperConfig
{
    public ParserMapperConfig()
    {
        CreateMap<ParserViewModel, InfoParser>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.IsStart, o => o.MapFrom(m => m.IsStarted))
            .ForMember(x => x.IsStartUpdate, o => o.MapFrom(m => m.IsStartUpdate))
            .ForMember(x => x.IsQueue, o => o.MapFrom(m => m.IsQueue))
            .ForMember(x => x.IsCompleted, o => o.MapFrom(m => m.IsCompleted))
            .ForMember(x => x.StartTime, o => o.MapFrom(m => m.StartTime))
            .ForMember(x => x.CompletionTime, o => o.MapFrom(m => m.CompletionTime))
            .ForMember(x => x.Configurations, o => o.MapFrom(m => m.Configurations))
            .ForMember(x => x.ExceptionMessage, o => o.MapFrom(m => m.ExceptionMessage))
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        CreateMap<InfoParser, ParserViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(m => m.Id))
            .ForMember(x => x.IsStarted, o => o.MapFrom(m => m.IsStart))
            .ForMember(x => x.IsQueue, o => o.MapFrom(m => m.IsQueue))
            .ForMember(x => x.IsCompleted, o => o.MapFrom(m => m.IsCompleted))
            .ForMember(x => x.StartTime, o => o.MapFrom(m => m.StartTime))
            .ForMember(x => x.CompletionTime, o => o.MapFrom(m => m.CompletionTime))
            .ForMember(x => x.Configurations, o => o.MapFrom(m => m.Configurations))
            .ForMember(x => x.ExceptionMessage, o => o.MapFrom(m => m.ExceptionMessage));

        AddPagedListMapperConfig<InfoParser, ParserViewModel>();
    }
}