using AutoMapper;
using InnowisePet.IdentityServer4.Models;
using InnowisePet.IdentityServer4.Models.DTO;

namespace InnowisePet.IdentityServer4.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateUserMaps();
    }

    private void CreateUserMaps()
    {
        CreateMap<UserForCreationDto, AppUser>();
    }
}