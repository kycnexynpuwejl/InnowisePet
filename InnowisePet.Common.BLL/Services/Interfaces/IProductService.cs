using InnowisePet.DTO.DTO.Product;

namespace InnowisePet.Common.BLL.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ProductGetDto> GetProductByIdAsync(Guid id);
    Task<bool> CreateProductAsync(ProductCreateDto productCreateDto);
    Task<bool> UpdateProductAsync(Guid id, ProductUpdateDto productUpdateDto);
    Task<bool> DeleteProductAsync(Guid id);
}