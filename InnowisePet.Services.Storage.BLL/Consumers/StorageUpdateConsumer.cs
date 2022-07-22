using InnowisePet.Models.DTO.Storage;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.BLL.Consumers;

public class StorageUpdateConsumer : IConsumer<StorageUpdateDto>
{
    private readonly IStorageService _storageService;

    public StorageUpdateConsumer(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<StorageUpdateDto> context)
    {
       await _storageService.UpdateStorageAsync(context.Message);
    }
}