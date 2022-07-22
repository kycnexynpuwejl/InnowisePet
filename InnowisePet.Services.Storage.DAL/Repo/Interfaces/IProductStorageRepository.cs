using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo.Interfaces;

public interface IProductStorageRepository
{
    Task<IEnumerable<ProductStorageModel>> GetProductStoragesAsync();
    
    Task<IEnumerable<ProductStorageModel>> GetProductStoragesByStorageIdAsync(Guid storageId);

    Task<IEnumerable<ProductStorageModel>> GetProductStoragesByProductIdAsync(Guid productId);
    
    Task<bool> CreateProductStorageAsync(ProductStorageModel productStorageModel);
    
    Task<bool> UpdateProductStorageAsync(ProductStorageModel productStorageModel);
    
    Task<bool> DeleteProductStorageAsync(Guid storageId, Guid productId);
}