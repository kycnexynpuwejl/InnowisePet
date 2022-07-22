using InnowisePet.Models.DTO.Order;

namespace InnowisePet.Services.Order.BLL.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderGetDto>> GetOrdersAsync();
    Task<OrderGetDto> GetOrderByIdAsync(Guid id);
    Task CreateOrderAsync(OrderCreateDto orderCreateDto);
    Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto);
    Task DeleteOrderAsync(Guid id);
}