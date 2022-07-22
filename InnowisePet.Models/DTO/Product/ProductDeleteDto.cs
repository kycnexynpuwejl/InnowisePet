using System.ComponentModel.DataAnnotations;

namespace InnowisePet.Models.DTO.Product;

public class ProductDeleteDto
{
    [Required]
    public Guid Id { get; set; }
}