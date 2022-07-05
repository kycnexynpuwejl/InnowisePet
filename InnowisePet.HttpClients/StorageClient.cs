using InnowisePet.Models.DTO.Storage;
using MassTransit;

namespace InnowisePet.HttpClients;

public class StorageClient
{
    private const string Url = "api/storage/";

    private readonly HttpClient _httpClient;
    private readonly IPublishEndpoint _publishEndpoint;

    public StorageClient(HttpClient httpClient, IPublishEndpoint publishEndpoint)
    {
        _httpClient = httpClient;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<StorageGetDto>> GetStoragesAsync()
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url);

        return await CommonHttpClientExtensions.Deserialize<IEnumerable<StorageGetDto>>(result);
    }

    public async Task<StorageGetDto> GetStorageByIdAsync(Guid id)
    {
        HttpResponseMessage result = await _httpClient.GetAsync(Url + $"{id}");

        return await CommonHttpClientExtensions.Deserialize<StorageGetDto>(result);
    }

    public async Task CreateStorageAsync(StorageCreateDto storageCreateDto)
    {
        await _publishEndpoint.Publish(storageCreateDto);
    }
}