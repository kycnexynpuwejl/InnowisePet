using InnowisePet.Models.DTO.Category;
using InnowisePet.Services.Product.BLL.Services.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Product.BLL.Consumers;

public class CategoryDeleteConsumer : IConsumer<CategoryDeleteDto>
{
    private readonly ICategoryService _categoryService;

    public CategoryDeleteConsumer(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task Consume(ConsumeContext<CategoryDeleteDto> context)
    {
        await _categoryService.DeleteCategoryAsync(context.Message.Id);
    }
}