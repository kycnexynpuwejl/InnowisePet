using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class LocationCreateProfile : Profile
{
    public LocationCreateProfile()
    {
        CreateMap<LocationCreateDto, Location>()
            .ForMember(c => c.city, opt => opt.MapFrom(c => c.City))
            .ForMember(c => c.id, opt => opt.MapFrom(c => Guid.NewGuid()));
    }
}