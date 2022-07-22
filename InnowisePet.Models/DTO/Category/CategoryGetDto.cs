using InnowisePet.Models.DTO.Product;

namespace InnowisePet.Models.DTO.Category;

public class CategoryGetDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public IEnumerable<ProductGetDto> Products { get; set; }
}