using InnowisePet.Models.Entities;
using InnowisePet.Services.Product.DAL.Data;
using InnowisePet.Services.Product.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Product.DAL.Repository.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductDbContext _context;
    
    public CategoryRepository(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<CategoryModel> GetCategoryByIdAsync(Guid id)
    {
        return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task CreateCategoryAsync(CategoryModel categoryModel)
    {
        if(categoryModel == null) return;

        await _context.Categories.AddAsync(categoryModel);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateCategoryAsync(CategoryModel categoryModel)
    {
        if(categoryModel == null) return;

        CategoryModel categoryFromDb = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryModel.Id);

        if (categoryFromDb != null) categoryFromDb.Title = categoryModel.Title;

        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteCategoryAsync(Guid id)
    {
        CategoryModel category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        if (category != null) _context.Categories.Remove(category);

        await _context.SaveChangesAsync();
    }
}