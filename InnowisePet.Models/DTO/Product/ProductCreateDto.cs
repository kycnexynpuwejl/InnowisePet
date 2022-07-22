using System.ComponentModel.DataAnnotations;

namespace InnowisePet.Models.DTO.Product;

public class ProductCreateDto
{
    [Required]
    public Guid CategoryId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}