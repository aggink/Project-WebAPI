using Company.Base.Mapper;
using Company.Parser.Entities;
using Company.Parser.ViewModels.URLViewModels;

namespace Company.Parser.Infrastructure.Mappers;

public class URLMapperConfig : MapperConfig
{
    public URLMapperConfig()
    {
        #region CreateMap ViewModel

        CreateMap<InfoURL, URLViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(x => x.ParserId))
            .ForMember(x => x.Url, o => o.MapFrom(x => x.Url))
            .ForMember(x => x.HasBeenProcessed, o => o.MapFrom(x => x.HasBeenProcessed))
            .ForMember(x => x.IsSuccess, o => o.MapFrom(x => x.IsSuccess))
            .ForMember(x => x.ElapsedMilliseconds, o => o.MapFrom(x => x.ElapsedMilliseconds))
            .ForMember(x => x.ExceptionMessage, o => o.MapFrom(x => x.ExceptionMessage));

        CreateMap<URLViewModel, InfoURL>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(x => x.ParserId))
            .ForMember(x => x.Url, o => o.MapFrom(x => x.Url))
            .ForMember(x => x.HasBeenProcessed, o => o.MapFrom(x => x.HasBeenProcessed))
            .ForMember(x => x.IsSuccess, o => o.MapFrom(x => x.IsSuccess))
            .ForMember(x => x.ElapsedMilliseconds, o => o.MapFrom(x => x.ElapsedMilliseconds))
            .ForMember(x => x.ExceptionMessage, o => o.MapFrom(x => x.ExceptionMessage))
            .ForMember(x => x.Parser, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap CreateViewModel

        CreateMap<InfoURL, CreateURLViewModel>()
            .ForMember(x => x.ParserId, o => o.MapFrom(x => x.ParserId))
            .ForMember(x => x.Url, o => o.MapFrom(x => x.Url));

        CreateMap<CreateURLViewModel, InfoURL>()
            .ForMember(x => x.ParserId, o => o.MapFrom(x => x.ParserId))
            .ForMember(x => x.Url, o => o.MapFrom(x => x.Url))
            .ForMember(x => x.Id, o => o.Ignore())
            .ForMember(x => x.HasBeenProcessed, o => o.Ignore())
            .ForMember(x => x.IsSuccess, o => o.Ignore())
            .ForMember(x => x.ElapsedMilliseconds, o => o.Ignore())
            .ForMember(x => x.ExceptionMessage, o => o.Ignore())
            .ForMember(x => x.Parser, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        #region CreateMap UpdateViewModel

        CreateMap<InfoURL, UpdateURLViewModel>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(x => x.ParserId))
            .ForMember(x => x.Url, o => o.MapFrom(x => x.Url));

        CreateMap<UpdateURLViewModel, InfoURL>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.ParserId, o => o.MapFrom(x => x.ParserId))
            .ForMember(x => x.Url, o => o.MapFrom(x => x.Url))
            .ForMember(x => x.HasBeenProcessed, o => o.Ignore())
            .ForMember(x => x.IsSuccess, o => o.Ignore())
            .ForMember(x => x.ElapsedMilliseconds, o => o.Ignore())
            .ForMember(x => x.ExceptionMessage, o => o.Ignore())
            .ForMember(x => x.Parser, o => o.Ignore())
            .ForMember(x => x.CreatedAt, o => o.Ignore())
            .ForMember(x => x.CreatedBy, o => o.Ignore())
            .ForMember(x => x.UpdatedAt, o => o.Ignore())
            .ForMember(x => x.UpdatedBy, o => o.Ignore());

        #endregion

        AddPagedListMapperConfig<InfoURL, URLViewModel>();
    }
}