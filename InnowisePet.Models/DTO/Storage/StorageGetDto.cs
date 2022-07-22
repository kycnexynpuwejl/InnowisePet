using InnowisePet.Models.DTO.ProductStorage;

namespace InnowisePet.Models.DTO.Storage;

public class StorageGetDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public IEnumerable<ProductStorageGetDto> ProductStorages { get; set; }
}