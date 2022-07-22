using InnowisePet.Models.DTO.Product;
using MassTransit;

namespace InnowisePet.HttpClients;

public class ProductClient
{
    private const string Url = "api/product/";

    private readonly IPublishEndpoint _publishEndpoint;
    private readonly HttpClient _httpClient;

    public ProductClient(HttpClient httpClient, IPublishEndpoint publishEndpoint)
    {
        _httpClient = httpClient;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<ProductGetDto>>(result);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(Guid productId)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + productId);

        return await CommonHttpClientExtensions.Deserialize<ProductGetDto>(result);
    }

    public async Task<IEnumerable<ProductGetDto>> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"category/{categoryId}");

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<ProductGetDto>>(result);
    }

    public async Task CreateProductAsync(ProductCreateDto productCreateDto)
    {
        await _publishEndpoint.Publish(productCreateDto);
    }

    public async Task UpdateProductAsync(ProductUpdateDto productUpdateDto)
    {
        await _publishEndpoint.Publish(productUpdateDto);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        ProductDeleteDto productDeleteDto = new() { Id = id };
        await _publishEndpoint.Publish(productDeleteDto);
    }
}