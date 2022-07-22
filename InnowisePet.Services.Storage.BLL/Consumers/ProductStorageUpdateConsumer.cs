using InnowisePet.Models.DTO.ProductStorage;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class ProductStorageUpdateConsumer : IConsumer<ProductStorageUpdateDto>
{
    private readonly IProductStorageService _productStorageService;

    public ProductStorageUpdateConsumer(IProductStorageService productStorageService)
    {
        _productStorageService = productStorageService;
    }

    public async Task Consume(ConsumeContext<ProductStorageUpdateDto> context)
    {
        await _productStorageService.UpdateProductStorageAsync(context.Message);
    }
}