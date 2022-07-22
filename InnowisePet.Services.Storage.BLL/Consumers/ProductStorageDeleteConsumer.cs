using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class ProductStorageDeleteConsumer : IConsumer<ProductStorageDeleteDto>
{
    private readonly IProductStorageService _productStorageService;

    public ProductStorageDeleteConsumer(IProductStorageService productStorageService)
    {
        _productStorageService = productStorageService;
    }

    public async Task Consume(ConsumeContext<ProductStorageDeleteDto> context)
    {
        await _productStorageService.DeleteProductStorageAsync(context.Message.StorageId, context.Message.ProductId);
    }
}