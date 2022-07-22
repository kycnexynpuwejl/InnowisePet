using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
    Task<CategoryModel> GetCategoryByIdAsync(Guid id);
    Task CreateCategoryAsync(CategoryModel categoryModel);
    Task UpdateCategoryAsync(CategoryModel categoryModel);
    Task DeleteCategoryAsync(Guid id);
}