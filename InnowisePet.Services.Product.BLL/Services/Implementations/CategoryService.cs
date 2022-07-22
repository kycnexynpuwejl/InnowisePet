using AutoMapper;
using InnowisePet.Models.DTO.Category;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using InnowisePet.Services.Product.DAL.Repository.Interfaces;

namespace InnowisePet.Services.Product.BLL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CategoryGetDtoList>> GetCategoriesAsync()
    {
        return _mapper.Map<IEnumerable<CategoryGetDtoList>>(await _categoryRepository.GetCategoriesAsync());
    }

    public async Task<CategoryGetDto> GetCategoryByIdAsync(Guid id)
    {
        return _mapper.Map<CategoryGetDto>(await _categoryRepository.GetCategoryByIdAsync(id));
    }

    public async Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _categoryRepository.CreateCategoryAsync(_mapper.Map<CategoryModel>(categoryCreateDto));
    }

    public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
    {
        await _categoryRepository.UpdateCategoryAsync(_mapper.Map<CategoryModel>(categoryUpdateDto));
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await _categoryRepository.DeleteCategoryAsync(id);
    }
}