using AutoMapper;
using InnowisePet.Models.DTO.Order;
using InnowisePet.Services.Order.BLL.Services;
using InnowisePet.Models.Enums;
using MassTransit;

namespace InnowisePet.Services.Order.BLL.Consumers;

public class OrderUpdateConsumer : IConsumer<OrderUpdateDto>
{
    private readonly IOrderService _orderService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public OrderUpdateConsumer(IOrderService orderService, IPublishEndpoint publishEndpoint, IMapper mapper)
    {
        _orderService = orderService;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }
 
    public async Task Consume(ConsumeContext<OrderUpdateDto> context)
    {
        await _orderService.UpdateOrderAsync(context.Message);

        if (context.Message.OrderStatus == OrderStatus.Accepted)
        {
            OrderAcceptedDto orderAcceptedDto = _mapper.Map<OrderAcceptedDto>(context.Message);
            await _publishEndpoint.Publish(orderAcceptedDto);
        }
    }
}