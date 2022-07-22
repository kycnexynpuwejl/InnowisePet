namespace InnowisePet.Models.DTO.Order;

public class OrderAcceptedDto
{
    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; }

    public string Firstname { get; set; }
    
    public string Lastname { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
}