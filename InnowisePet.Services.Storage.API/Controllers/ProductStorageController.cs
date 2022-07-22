using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStorageController : Controller
{
    private readonly IProductStorageService _productStorageService;

    public ProductStorageController(IProductStorageService productStorageService)
    {
        _productStorageService = productStorageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductStoragesAsync()
    {
        return Ok(await _productStorageService.GetProductStoragesAsync());
    }

    [HttpGet("storage/{storageId}")]
    public async Task<IActionResult> GetProductStoragesByStorageIdAsync([FromRoute]Guid storageId)
    {
        return Ok(await _productStorageService.GetProductStoragesByStorageIdAsync(storageId));
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetProductCountFromAllStoragesByProductIdAsync([FromRoute] Guid productId)
    {
        return Ok(await _productStorageService.GetProductStoragesByProductIdAsync(productId));
    }
}