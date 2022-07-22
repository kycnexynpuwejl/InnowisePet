using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.ProductStorage;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStorageController : Controller
{
    private readonly ProductStorageClient _productStorageClient;

    public ProductStorageController(ProductStorageClient productStorageClient)
    {
        _productStorageClient = productStorageClient;
    }

    /// <summary>
    /// Gets all productStorages
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _productStorageClient.GetProductStoragesAsync());
    }

    /// <summary>
    /// Gets all productStorages in specified storage by storageId
    /// </summary>
    /// <param name="storageId"></param>
    /// <returns></returns>
    [HttpGet("storage/{storageId}")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync(Guid storageId)
    {
        return Ok(await _productStorageClient.GetProductStoragesByStorageIdAsync(storageId));
    }
    
    /// <summary>
    /// Get count of specified product from all storages by productId
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetProductCountFromAllStoragesByProductIdAsync(Guid productId)
    {
        return Ok(await _productStorageClient.GetProductStoragesByProductIdAsync(productId));
    }
    
    /// <summary>
    /// Creates productStorage in specified storage by storageId
    /// </summary>
    /// <param name="storageId"></param>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    [HttpPost("{storageId}/{productId}")]
    public async Task<IActionResult> CreateProductStorageAsync(
        [FromRoute] Guid storageId,
        [FromRoute] Guid productId,
        [FromBody] int quantity)
    {
        await _productStorageClient.CreateProductStorageAsync(new ProductStorageCreateDto()
        {
            StorageId = storageId,
            ProductId = productId,
            Quantity = quantity
        });
        
        return Ok();
    }

    /// <summary>
    /// Updates specified productStorage in specified storage by both productId and storageId
    /// </summary>
    /// <param name="storageId"></param>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    [HttpPut("{storageId}/{productId}")]
    public async Task<IActionResult> UpdateProductStorageAsync(
        [FromRoute]Guid storageId,
        [FromRoute]Guid productId,
        [FromBody]int quantity)
    {
        await _productStorageClient.UpdateProductStorageAsync(storageId, productId, quantity);

        return Ok();
    }

    /// <summary>
    /// Deletes productStorage by both specified productId and storageId
    /// </summary>
    /// <param name="storageId"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpDelete("{storageId}/{productId}")]
    public async Task<IActionResult> DeleteProductStorageAsync([FromRoute] Guid storageId, [FromRoute] Guid productId)
    {
        await _productStorageClient.DeleteProductStorageAsync(storageId, productId);

        return Ok();
    }
}