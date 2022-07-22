using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnowisePet.Models.Entities;

public class ProductModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey("CategoryModel")]
    public Guid CategoryId { get; set; }
    
    public CategoryModel Category { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
}