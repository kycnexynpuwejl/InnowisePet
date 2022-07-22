using AutoMapper;
using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class ProductStorageCreateProfile : Profile
{
    public ProductStorageCreateProfile()
    {
        CreateMap<ProductStorageCreateDto, ProductStorageModel>()
            .ForMember(ps => ps.Id, opt => opt.MapFrom(ps => Guid.NewGuid()));
    }
}