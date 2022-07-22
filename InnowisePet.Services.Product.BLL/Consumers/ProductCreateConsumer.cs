using InnowisePet.Models.DTO.Product;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class ProductCreateConsumer : IConsumer<ProductCreateDto>
{
    private readonly IProductService _productService;

    public ProductCreateConsumer(IProductService productService) => _productService = productService;

    public async Task Consume(ConsumeContext<ProductCreateDto> context)
    {
        await _productService.CreateProductAsync(context.Message);
    }
}