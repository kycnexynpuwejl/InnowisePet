using InnowisePet.DTO.DTO.Order;

namespace InnowisePet.Services.Order.BLL;

public interface IOrderService
{
    Task<IEnumerable<OrderGetDto>> GetOrdersAsync();
    Task<OrderGetDto> GetOrderByIdAsync(Guid id);
    Task CreateOrderAsync(OrderCreateDto orderCreateDto);
    Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto);
    Task DeleteOrderAsync(Guid id);
}