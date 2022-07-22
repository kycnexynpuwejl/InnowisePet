using InnowisePet.Models.DTO.Category;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class CategoryCreateConsumer : IConsumer<CategoryCreateDto>
{
    private readonly ICategoryService _categoryService;

    public CategoryCreateConsumer(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task Consume(ConsumeContext<CategoryCreateDto> context)
    {
        await _categoryService.CreateCategoryAsync(context.Message);
    }
}