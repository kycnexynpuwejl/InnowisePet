using InnowisePet.Services.Product.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Product.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id)
    {
        return Ok(await _productService.GetProductByIdAsync(id));
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        var s = await _productService.GetProductsByCategoryIdAsync(categoryId);
        
        return Ok(await _productService.GetProductsByCategoryIdAsync(categoryId));
    }
}
