using InnowisePet.Models.DTO.Storage;

namespace InnowisePet.Services.Storage.BLL.Services.Interfaces;

public interface IStorageService
{
    Task<IEnumerable<StorageGetDtoList>> GetStoragesAsync();
    
    Task<StorageGetDto> GetStorageByIdAsync(Guid id);
    
    Task CreateStorageAsync(StorageCreateDto storageCreateDto);
    
    Task UpdateStorageAsync(StorageUpdateDto storageUpdateDto);
    
    Task DeleteStorageAsync(Guid id);
}