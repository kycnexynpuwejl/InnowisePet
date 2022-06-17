using InnowisePet.Shared.Enums;

namespace InnowisePet.Services.Order.DAL;

public class Order
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public int Quantity { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
    
    public Guid ProductId { get; set; }

    public string ProductName { get; set; }

    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
}