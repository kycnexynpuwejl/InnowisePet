using OrderStatus = InnowisePet.Models.Enums.OrderStatus;

namespace InnowisePet.Models.DTO.Order;

public class OrderUpdateDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; }

    public OrderStatus OrderStatus { get; set; }
    
    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
}