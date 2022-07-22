using InnowisePet.Models.DTO.Order;
using InnowisePet.Services.Report.BLL.Services;
using MassTransit;

namespace InnowisePet.Services.Report.BLL.Consumers;

public class OrderAcceptedConsumer : IConsumer<OrderAcceptedDto>
{
    private readonly IGeneratePdfService _generatePdfService;

    public OrderAcceptedConsumer(IGeneratePdfService generatePdfService)
    {
        _generatePdfService = generatePdfService;
    }

    public Task Consume(ConsumeContext<OrderAcceptedDto> context)
    {
        _generatePdfService.GeneratePdf(context.Message);
        
        return Task.CompletedTask;
    }
}