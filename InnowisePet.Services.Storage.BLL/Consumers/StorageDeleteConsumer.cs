using InnowisePet.Models.DTO.Storage;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class StorageDeleteConsumer : IConsumer<StorageDeleteDto>
{
    private readonly IStorageService _storageService;

    public StorageDeleteConsumer(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<StorageDeleteDto> context)
    {
        await _storageService.DeleteStorageAsync(context.Message.Id);
    }
}