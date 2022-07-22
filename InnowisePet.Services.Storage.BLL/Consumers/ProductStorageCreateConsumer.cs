using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class ProductStorageCreateConsumer : IConsumer<ProductStorageCreateDto>
{
    private readonly IProductStorageService _productStorageService;

    public ProductStorageCreateConsumer(IProductStorageService productStorageService)
    {
        _productStorageService = productStorageService;
    }

    public async Task Consume(ConsumeContext<ProductStorageCreateDto> context)
    {
        await _productStorageService.CreateProductStorageAsync(context.Message);
    }
}