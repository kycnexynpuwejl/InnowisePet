using AutoMapper;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, ProductModel>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()));
    }
}