using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.DAL.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProductsAsync();
    
    Task<ProductModel> GetProductByIdAsync(Guid productId);

    Task<IEnumerable<ProductModel>> GetProductsByCategoryIdAsync(Guid categoryId);
    
    Task<Guid> CreateProductAsync(ProductModel productModel);
    
    Task UpdateProductAsync(ProductModel productModel);
    
    Task DeleteProductAsync(Guid id);
}