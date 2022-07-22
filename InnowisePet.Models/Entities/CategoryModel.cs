using System.ComponentModel.DataAnnotations;

namespace InnowisePet.Models.Entities;

public class CategoryModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }
    
    public IEnumerable<ProductModel> Products { get; set; }
}