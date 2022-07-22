using InnowisePet.Models.DTO.Order;

namespace InnowisePet.Services.Report.BLL.Services;

public interface IGeneratePdfService
{
    Task GeneratePdf(OrderAcceptedDto order);
    Task GeneratePdfFromList(IEnumerable<OrderAcceptedDto> orderList);
}