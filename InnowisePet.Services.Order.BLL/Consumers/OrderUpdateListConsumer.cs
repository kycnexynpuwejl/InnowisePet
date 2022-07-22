using AutoMapper;
using InnowisePet.Models.DTO.Order;
using InnowisePet.Services.Order.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Order.BLL.Consumers;

public class OrderUpdateListConsumer : IConsumer<OrderUpdateDtoList>
{
    private readonly IOrderService _orderService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public OrderUpdateListConsumer(IOrderService orderService, IPublishEndpoint publishEndpoint, IMapper mapper)
    {
        _orderService = orderService;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<OrderUpdateDtoList> context)
    {
        foreach (OrderUpdateDto order in context.Message.List)
        {
            await _orderService.UpdateOrderAsync(order);
        }

        IEnumerable<OrderAcceptedDto> orderAcceptedDtoList = _mapper.Map<IEnumerable<OrderAcceptedDto>>(context.Message.List);
        OrderAcceptedDtoList orderAcceptedDtoListToPublish = new() {List = orderAcceptedDtoList};
        await _publishEndpoint.Publish(orderAcceptedDtoListToPublish);
    }
}