using InnowisePet.Models.Entities;
using InnowisePet.Services.Order.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Order.DAL.Repo;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<OrderModel> GetOrderByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task CreateOrderAsync(OrderModel orderModel)
    {
        await _context.Orders.AddAsync(orderModel);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(OrderModel orderModel)
    {
        OrderModel orderModelFromDb = await _context.Orders.FindAsync(orderModel.Id);

        if (orderModelFromDb == null) return;

        orderModelFromDb.ProductId = orderModel.ProductId;
        orderModelFromDb.Quantity = orderModel.Quantity;
        orderModelFromDb.OrderStatus = orderModel.OrderStatus;
        orderModelFromDb.Firstname = orderModel.Firstname;
        orderModelFromDb.Lastname = orderModel.Lastname;
        orderModelFromDb.Address = orderModel.Address;
        orderModelFromDb.City = orderModel.City;
        orderModelFromDb.Country = orderModel.Country;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        OrderModel orderModelFromDb = await _context.Orders.FindAsync(id);

        if (orderModelFromDb == null) return;

        _context.Orders.Remove(orderModelFromDb);
        await _context.SaveChangesAsync();
    }
}