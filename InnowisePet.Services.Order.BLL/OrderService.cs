using AutoMapper;
using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Order.DAL.Repo;

namespace InnowisePet.Services.Order.BLL;

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
        IEnumerable<DAL.Order> result = await _orderRepository.GetOrdersAsync();

        return _mapper.Map<IEnumerable<OrderGetDto>>(result);
    }

    public async Task<OrderGetDto> GetOrderByIdAsync(Guid id)
    {
        DAL.Order order = await _orderRepository.GetOrderByIdAsync(id);

        return _mapper.Map<OrderGetDto>(order);
    }

    public async Task CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        DAL.Order order = _mapper.Map<DAL.Order>(orderCreateDto);

        await _orderRepository.CreateOrderAsync(order);
    }

    public async Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
    {
        DAL.Order order = _mapper.Map<DAL.Order>(orderUpdateDto);

        await _orderRepository.UpdateOrderAsync(order);
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        await _orderRepository.DeleteOrderAsync(id);
    }
}