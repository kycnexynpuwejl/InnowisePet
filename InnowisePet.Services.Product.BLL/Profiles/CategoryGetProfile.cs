using AutoMapper;
using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class CategoryGetProfile : Profile
{
    public CategoryGetProfile()
    {
        CreateMap<CategoryModel, CategoryGetDto>().ReverseMap();
        CreateMap<CategoryModel, CategoryGetDtoList>().ReverseMap();
    }
}