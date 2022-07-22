using AutoMapper;
using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class ProductStorageUpdateProfile : Profile
{
    public ProductStorageUpdateProfile()
    {
        CreateMap<ProductStorageUpdateDto, ProductStorageModel>().ReverseMap();
    }
}