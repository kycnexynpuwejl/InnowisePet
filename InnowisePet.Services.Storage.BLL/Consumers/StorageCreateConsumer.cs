using InnowisePet.Models.DTO.Storage;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class StorageCreateConsumer : IConsumer<StorageCreateDto>
{
    private readonly IStorageService _storageService;

    public StorageCreateConsumer(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<StorageCreateDto> context)
    {
        await _storageService.CreateStorageAsync(context.Message);
    }
}