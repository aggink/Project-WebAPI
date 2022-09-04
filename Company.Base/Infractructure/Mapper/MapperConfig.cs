using AutoMapper;
using Calabonga.UnitOfWork;

namespace Company.Base.Mapper;

/// <summary>
/// Базовый класс для Mapper Config. Все ViewModel, которые будут отображаться, должны реализовывать IAutoMapper.
/// </summary>
public abstract class MapperConfig : Profile, IAutoMapper
{
    protected void AddPagedListMapperConfig<TSource, TDestination>()
    {
        CreateMap<PagedList<TSource>, PagedList<TDestination>> ()
            .ForMember(x => x.IndexFrom, o => o.MapFrom(x => x.IndexFrom))
            .ForMember(x => x.PageIndex, o => o.MapFrom(x => x.PageIndex))
            .ForMember(x => x.PageSize, o => o.MapFrom(x => x.PageSize))
            .ForMember(x => x.TotalCount, o => o.MapFrom(x => x.TotalCount))
            .ForMember(x => x.TotalPages, o => o.MapFrom(x => x.TotalPages))
            .ForMember(x => x.Items, o => o.MapFrom(x => x.Items))
            .ForMember(x => x.HasPreviousPage, o => o.MapFrom(x => x.HasPreviousPage))
            .ForMember(x => x.HasNextPage, o => o.MapFrom(x => x.HasNextPage));

        CreateMap<PagedList<TDestination>, PagedList<TSource>>()
            .ForMember(x => x.IndexFrom, o => o.MapFrom(x => x.IndexFrom))
            .ForMember(x => x.PageIndex, o => o.MapFrom(x => x.PageIndex))
            .ForMember(x => x.PageSize, o => o.MapFrom(x => x.PageSize))
            .ForMember(x => x.TotalCount, o => o.MapFrom(x => x.TotalCount))
            .ForMember(x => x.TotalPages, o => o.MapFrom(x => x.TotalPages))
            .ForMember(x => x.Items, o => o.MapFrom(x => x.Items))
            .ForMember(x => x.HasPreviousPage, o => o.MapFrom(x => x.HasPreviousPage))
            .ForMember(x => x.HasNextPage, o => o.MapFrom(x => x.HasNextPage));
    }
}