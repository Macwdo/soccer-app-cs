using AutoMapper;

namespace WebApiDotnet.Mappers;

public abstract class BaseProfile<TEntity, TRequest, TResponse>: Profile
{
    protected BaseProfile()
    {
        CreateMap<TEntity, TRequest>().ReverseMap();
        CreateMap<TEntity, TResponse>().ReverseMap();
    }
}

