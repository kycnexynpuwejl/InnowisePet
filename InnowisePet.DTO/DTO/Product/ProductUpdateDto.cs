namespace InnowisePet.DTO.DTO.Product;

public class ProductUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
}