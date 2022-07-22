using AutoMapper;
using InnowisePet.Models.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDto, ProductModel>().ReverseMap();
    }
}