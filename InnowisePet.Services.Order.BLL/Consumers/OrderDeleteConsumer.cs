using InnowisePet.DTO.DTO.Order;
using MassTransit;

namespace InnowisePet.Services.Order.BLL.Consumers;

public class OrderDeleteConsumer : IConsumer<OrderDeleteDto>
{
    private readonly IOrderService _orderService;

    public OrderDeleteConsumer(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Consume(ConsumeContext<OrderDeleteDto> context)
    {
        await _orderService.DeleteOrderAsync(context.Message.Id);
    }
}