using AutoMapper;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using InnowisePet.Services.Storage.DAL.Repo.Interfaces;

namespace InnowisePet.Services.Storage.BLL.Services.Implementations;

public class StorageService : IStorageService
{
    private readonly IStorageRepository _storageRepository;
    private readonly IMapper _mapper;

    public StorageService(IStorageRepository storageRepository, IMapper mapper)
    {
        _storageRepository = storageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StorageGetDtoList>> GetStoragesAsync()
    {
        return _mapper.Map<IEnumerable<StorageGetDtoList>>(await _storageRepository.GetStoragesAsync());
    }

    public async Task<StorageGetDto> GetStorageByIdAsync(Guid id)
    {
        return _mapper.Map<StorageGetDto>(await _storageRepository.GetStorageByIdAsync(id));
    }

    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        await _storageRepository.CreateStorageAsync(_mapper.Map<StorageModel>(storageCreateDto));
    }

    public async Task UpdateStorageAsync(StorageUpdateDto storageUpdateDto)
    {
        await _storageRepository.UpdateStorageAsync(_mapper.Map<StorageModel>(storageUpdateDto));
    }

    public async Task DeleteStorageAsync(Guid id)
    {
        await _storageRepository.DeleteStorageAsync(id);
    }
}