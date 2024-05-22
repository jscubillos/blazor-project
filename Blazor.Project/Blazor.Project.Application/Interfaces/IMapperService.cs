namespace Blazor.Project.Application.Interfaces;

public interface IMapperService
{
    TDestination Map<TSource, TDestination>(TSource source);

    IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source);
}