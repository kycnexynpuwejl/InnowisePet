using InnowisePet.Models.DTO.Order;
using InnowisePet.Services.Report.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Report.BLL.Consumers;

public class OrderListAcceptedConsumer : IConsumer<OrderAcceptedDtoList>
{
    private readonly IGeneratePdfService _generatePdfService;

    public OrderListAcceptedConsumer(IGeneratePdfService generatePdfService)
    {
        _generatePdfService = generatePdfService;
    }

    public Task Consume(ConsumeContext<OrderAcceptedDtoList> context)
    {
        _generatePdfService.GeneratePdfFromList(context.Message.List);
        return Task.CompletedTask;
    }
}