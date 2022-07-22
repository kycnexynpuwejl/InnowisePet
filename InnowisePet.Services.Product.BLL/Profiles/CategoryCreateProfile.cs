using AutoMapper;
using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class CategoryCreateProfile : Profile
{
    public CategoryCreateProfile()
    {
        CreateMap<CategoryCreateDto, CategoryModel>()
            .ForMember(c => c.Id, opt => opt.MapFrom(c => Guid.NewGuid()));
    }
}