using AutoMapper;

namespace Company.WebAPI.Infrastructure.Mappers.Base;

/// <summary>
/// Базовый класс для Mapper Config. Все ViewModel, которые будут отображаться, должны реализовывать IAutoMapper.
/// </summary>
public abstract class BaseMapperConfig : Profile, IAutoMapper { }
