using InnowisePet.DTO.Product;
using InnowisePet.Services.Product.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class ProductUpdateConsumer : IConsumer<ProductUpdateDto>
{
    private readonly IProductService _productService;

    public ProductUpdateConsumer(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Consume(ConsumeContext<ProductUpdateDto> context)
    {
        await _productService.UpdateProductAsync(context.Message);
    }
}