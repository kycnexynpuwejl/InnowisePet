using AutoMapper;
using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class ProductStorageGetProfile : Profile
{
    public ProductStorageGetProfile()
    {
        CreateMap<ProductStorageModel, ProductStorageGetDto>().ReverseMap();
    }
}