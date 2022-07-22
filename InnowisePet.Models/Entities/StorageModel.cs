namespace InnowisePet.Models.Entities;

public class StorageModel
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public IEnumerable<ProductStorageModel> ProductStorages { get; set; }
}