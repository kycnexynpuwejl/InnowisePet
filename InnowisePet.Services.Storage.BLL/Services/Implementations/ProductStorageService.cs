using AutoMapper;
using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Models.Entities;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using InnowisePet.Services.Storage.DAL.Repo.Interfaces;

namespace InnowisePet.Services.Storage.BLL.Services.Implementations;

public class ProductStorageService : IProductStorageService
{
    private readonly IProductStorageRepository _productStorageRepository;
    private readonly IMapper _mapper;

    public ProductStorageService(IProductStorageRepository productStorageRepository, IMapper mapper)
    {
        _productStorageRepository = productStorageRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesAsync()
    {
        return _mapper.Map<IEnumerable<ProductStorageGetDto>>(await _productStorageRepository.GetProductStoragesAsync());
    }

    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return _mapper.Map<IEnumerable<ProductStorageGetDto>>(await _productStorageRepository.GetProductStoragesByStorageIdAsync(storageId));
    }
    
    public async Task<IEnumerable<ProductStorageGetDto>> GetProductStoragesByProductIdAsync(Guid productId)
    {
        return _mapper.Map<IEnumerable<ProductStorageGetDto>>(await _productStorageRepository.GetProductStoragesByProductIdAsync(productId));
    }
    
    public async Task CreateProductStorageAsync(ProductStorageCreateDto productStorageCreateDto)
    {
        ProductStorageModel productStorage = _mapper.Map<ProductStorageModel>(productStorageCreateDto);
        await _productStorageRepository.CreateProductStorageAsync(productStorage);
    }
    
    public async Task UpdateProductStorageAsync(ProductStorageUpdateDto productStorageUpdateDto)
    {
        ProductStorageModel productStorage = _mapper.Map<ProductStorageModel>(productStorageUpdateDto);
        await _productStorageRepository.UpdateProductStorageAsync(productStorage);
    }

    public async Task DeleteProductStorageAsync(Guid storageId, Guid productId)
    {
        await _productStorageRepository.DeleteProductStorageAsync(storageId, productId);
    }
}