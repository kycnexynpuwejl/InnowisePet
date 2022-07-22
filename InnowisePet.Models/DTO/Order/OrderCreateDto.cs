namespace InnowisePet.Models.DTO.Order;

public class OrderCreateDto
{
    public Guid UserId { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }
    
    public string ProductName { get; set; }
}