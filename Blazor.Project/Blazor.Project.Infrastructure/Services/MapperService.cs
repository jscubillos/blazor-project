using Blazor.Project.Application.Interfaces;
using Blazor.Project.Infrastructure.Profiles;
using AutoMapper;

namespace Blazor.Project.Infrastructure.Services;

public class MapperService : IMapperService
{
    private readonly IMapper _mapper;
    
    public MapperService()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfiles(LoadProfiles()));
        _mapper = config.CreateMapper();
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        try
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
        catch (Exception exception)
        {
            throw new Exception($"Mapping error: {exception.Message}");
        }
    }

    public IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
    {
        try
        {
            return _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }
        catch (Exception exception)
        {
            throw new Exception($"Mapping error: {exception.Message}");
        }
    }

    private IEnumerable<Profile> LoadProfiles()
    {
        return new List<Profile>
        {
            new UserProfile(),
            new JwtTokenProfile(),
            new SpecialityProfile(),
            new DoctorProfile(),
            new HospitalProfile(),
            new HospitalDoctorProfile()
        };
    }
}