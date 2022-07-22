using InnowisePet.Models.DTO.Category;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class CategoryUpdateConsumer : IConsumer<CategoryUpdateDto>
{
    private readonly ICategoryService _categoryService;

    public CategoryUpdateConsumer(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task Consume(ConsumeContext<CategoryUpdateDto> context)
    {
        await _categoryService.UpdateCategoryAsync(context.Message);
    }
}