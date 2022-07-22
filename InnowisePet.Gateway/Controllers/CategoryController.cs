using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Category;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly CategoryClient _categoryClient;

    public CategoryController(CategoryClient categoryClient)
    {
        _categoryClient = categoryClient;
    }

    /// <summary>
    /// Gets all existing categories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        return Ok(await _categoryClient.GetCategoriesAsync());
    }

    /// <summary>
    /// Gets specified category with existing in this category products by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        return Ok(await _categoryClient.GetCategoryByIdAsync(id));
    }
    
    /// <summary>
    /// Creates category
    /// </summary>
    /// <param name="categoryCreateDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        await _categoryClient.CreateCategoryAsync(categoryCreateDto);

        return Ok();
    }
    
    /// <summary>
    /// Updates category by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] Guid id, [FromBody]CategoryUpdateDto dto)
    {
        dto.Id = id;
        await _categoryClient.UpdateCategoryAsync(dto);

        return Ok();
    }
    
    /// <summary>
    /// Deletes category by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryASync([FromRoute] Guid id)
    {
        await _categoryClient.DeleteCategoryAsync(id);

        return Ok();
    }
}