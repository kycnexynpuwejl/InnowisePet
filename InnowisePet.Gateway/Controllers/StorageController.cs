using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Storage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : Controller
{
    private readonly StorageClient _storageClient;

    public StorageController(StorageClient storageClient)
    {
        _storageClient = storageClient;
    }

    /// <summary>
    /// Gets all storages
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetStoragesAsync()
    {
        return Ok(await _storageClient.GetStoragesAsync());
    }

    /// <summary>
    /// Gets specified storage by Id
    /// </summary>
    /// <param name="storageId"></param>
    /// <returns></returns>
    [HttpGet("{storageId}")]
    public async Task<IActionResult> GetStorageByIdAsync([FromRoute] Guid storageId)
    {
        return Ok(await _storageClient.GetStorageByIdAsync(storageId));
    }

    /// <summary>
    /// Creates storage
    /// </summary>
    /// <param name="storageCreateDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateStorageAsync([FromBody]StorageCreateDto storageCreateDto)
    {
        await _storageClient.CreateStorageAsync(storageCreateDto);
        
        return Ok();
    }

    /// <summary>
    /// Updates storage
    /// </summary>
    /// <param name="storageId"></param>
    /// <param name="storageUpdateDto"></param>
    /// <returns></returns>
    [HttpPut("{storageId}")]
    public async Task<IActionResult> UpdateStorageAsync(
        [FromRoute] Guid storageId,
        [FromBody] StorageUpdateDto storageUpdateDto)
    {
        storageUpdateDto.Id = storageId;
        await _storageClient.UpdateStorageAsync(storageUpdateDto);
        
        return Ok();
    }

    /// <summary>
    /// Deletes storage
    /// </summary>
    /// <param name="storageId"></param>
    /// <returns></returns>
    [HttpDelete("{storageId}")]
    public async Task<IActionResult> DeleteStorageAsync([FromRoute] Guid storageId)
    {
        await _storageClient.DeleteStorageAsync(new StorageDeleteDto() { Id = storageId });
        
        return Ok();
    }
}