using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.DAL.Repo.Interfaces;

public interface IStorageRepository
{
    Task<IEnumerable<StorageModel>> GetStoragesAsync();
    
    Task<StorageModel> GetStorageByIdAsync(Guid id);
    
    Task<bool> CreateStorageAsync(StorageModel storageModel);
    
    Task<bool> UpdateStorageAsync(StorageModel storageModel);
    
    Task<bool> DeleteStorageAsync(Guid id);
}