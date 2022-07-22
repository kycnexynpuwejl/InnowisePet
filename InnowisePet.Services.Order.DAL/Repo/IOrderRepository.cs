namespace InnowisePet.Services.Order.DAL.Repo;

public interface IOrderRepository
{
    Task<IEnumerable<Models.Entities.OrderModel>> GetOrdersAsync();
    Task<Models.Entities.OrderModel> GetOrderByIdAsync(Guid id);
    Task CreateOrderAsync(Models.Entities.OrderModel orderModel);
    Task UpdateOrderAsync(Models.Entities.OrderModel orderModel);
    Task DeleteOrderAsync(Guid id);
}