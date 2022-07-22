using InnowisePet.Models.DTO.Category;

namespace InnowisePet.Services.Product.BLL.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryGetDtoList>> GetCategoriesAsync();
    Task<CategoryGetDto> GetCategoryByIdAsync(Guid id);
    Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
    Task DeleteCategoryAsync(Guid id);
}