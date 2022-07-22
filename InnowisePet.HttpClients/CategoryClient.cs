using InnowisePet.Models.DTO.Category;
using MassTransit;

namespace InnowisePet.HttpClients;

public class CategoryClient
{
    private const string Url = "api/category/";
    
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly HttpClient _httpClient;

    public CategoryClient(IPublishEndpoint publishEndpoint, HttpClient httpClient)
    {
        _publishEndpoint = publishEndpoint;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CategoryGetDtoList>> GetCategoriesAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<CategoryGetDtoList>>(result);
    }

    public async Task<CategoryGetDto> GetCategoryByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + id);

        return await CommonHttpClientExtensions.Deserialize<CategoryGetDto>(result);
    }
    
    public async Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _publishEndpoint.Publish(categoryCreateDto);
    }
    
    public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
    {
        await _publishEndpoint.Publish(categoryUpdateDto);
    }
    
    public async Task DeleteCategoryAsync(Guid id)
    {
        CategoryDeleteDto categoryDeleteDto = new() { Id = id };
        await _publishEndpoint.Publish(categoryDeleteDto);
    }
}