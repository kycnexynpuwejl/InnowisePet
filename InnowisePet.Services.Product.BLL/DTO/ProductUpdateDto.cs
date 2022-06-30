namespace InnowisePet.Services.Product.BLL.DTO;

public class ProductUpdateDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public string Category { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}