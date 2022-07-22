namespace InnowisePet.Models.DTO.ProductStorage;

public class ProductStorageGetDto
{
    public Guid Id { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Guid StorageId { get; set; }
    
    public int Quantity { get; set; }
    
    public string StorageTitle { get; set; }
}