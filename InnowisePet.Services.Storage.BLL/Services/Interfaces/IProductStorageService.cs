using InnowisePet.Models.DTO.ProductStorage;

namespace InnowisePet.Services.Storage.BLL.Services.Interfaces;

public interface IProductStorageService
{
    Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync();
    
    Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByStorageIdAsync(Guid storageId);

    Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByProductIdAsync(Guid productId);
    
    Task CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto);
    
    Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto);
    
    Task DeleteProductStorageAsync(Guid storageId, Guid productId);
}