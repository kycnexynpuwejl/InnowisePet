using AutoMapper;
using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class CategoryUpdateProfile : Profile
{
    public CategoryUpdateProfile()
    {
        CreateMap<CategoryUpdateDto, CategoryModel>().ReverseMap();
    }
}