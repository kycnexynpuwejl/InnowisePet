using InnowisePet.DTO.DTO.ProductStorage;

namespace InnowisePet.Common.BLL.Services.Interfaces;

public interface IProductStorageService
{
    Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync();
    Task<ProductStorageGetDto> GetProductStorageByIdAsync(Guid id);
    Task<bool> CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    Task<bool> UpdateProductStorageAsync(Guid id, ProductStorageUpdateDto productStorageUpdateDto);
    Task<bool> DeleteProductStorageAsync(Guid id);
}