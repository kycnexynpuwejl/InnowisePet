namespace InnowisePet.Models.DTO.ProductStorage;

public class ProductStorageUpdateDto
{
    public Guid ProductId { get; set; }
    
    public Guid StorageId { get; set; }
    
    public int Quantity { get; set; }
}