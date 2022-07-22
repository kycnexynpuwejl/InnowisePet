using InnowisePet.Models.DTO.Product;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class ProductDeleteConsumer : IConsumer<ProductDeleteDto>
{
    private readonly IProductService _productService;

    public ProductDeleteConsumer(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Consume(ConsumeContext<ProductDeleteDto> context)
    {
        await _productService.DeleteProductAsync(context.Message.Id);
    }
}