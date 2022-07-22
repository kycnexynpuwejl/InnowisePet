using AutoMapper;
using InnowisePet.Models.DTO.Order;
using InnowisePet.Services.Order.DAL.Repo;

namespace InnowisePet.Services.Order.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderGetDto>> GetOrdersAsync()
    {
        IEnumerable<Models.Entities.OrderModel> result = await _orderRepository.GetOrdersAsync();

        return _mapper.Map<IEnumerable<OrderGetDto>>(result);
    }

    public async Task<OrderGetDto> GetOrderByIdAsync(Guid id)
    {
        Models.Entities.OrderModel orderModel = await _orderRepository.GetOrderByIdAsync(id);

        return _mapper.Map<OrderGetDto>(orderModel);
    }

    public async Task CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        Models.Entities.OrderModel orderModel = _mapper.Map<Models.Entities.OrderModel>(orderCreateDto);

        await _orderRepository.CreateOrderAsync(orderModel);
    }

    public async Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
    {
        Models.Entities.OrderModel orderModel = _mapper.Map<Models.Entities.OrderModel>(orderUpdateDto);

        await _orderRepository.UpdateOrderAsync(orderModel);
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        await _orderRepository.DeleteOrderAsync(id);
    }
}