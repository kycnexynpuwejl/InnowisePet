using InnowisePet.Models.DTO.Order;
using InnowisePet.Services.Report.DAL;
using IronPdf;

namespace InnowisePet.Services.Report.BLL.Services;

public class GeneratePdfService : IGeneratePdfService
{
    private readonly ReportPdfRepository _repository;

    public GeneratePdfService(ReportPdfRepository repository) => _repository = repository;

    public async Task GeneratePdf(OrderAcceptedDto order)
    {
        PdfDocument pdf = new HtmlToPdf().RenderHtmlAsPdf(
            $@"<h1>Thanks for ordering!
                <h1>{order.Firstname} {order.Lastname}</h1>
                <h2>{order.Address}</h2>"
        );
            
        pdf.SaveAs($"{DateTime.Now.ToFileTime()}.pdf");

        byte[] binaryPdf = pdf.BinaryData;
        
        await _repository.AddReportPdf(new ReportPdfModel { PdfFile = binaryPdf });
    }

    public async Task GeneratePdfFromList(IEnumerable<OrderAcceptedDto> orderList)
    {

        string productQuantity = @"<h1>Thanks for ordering!</h1>";
        string firstname = "";
        string lastname = "";
        foreach (OrderAcceptedDto order in orderList)
        {
            productQuantity += "<h2>Product: " + order.ProductName + "  Quantity: " + order.Quantity + "</h2>\n";
            firstname = order.Firstname;
            lastname = order.Lastname;
        }
        
        HtmlToPdf renderer = new();

        PdfDocument pdf = renderer
            .RenderHtmlAsPdf(@$"
                                {productQuantity}
                                <h1>{firstname} {lastname}</h1>"
                                );
        
        pdf.SaveAs($"{DateTime.Now.ToFileTime()}.pdf");
        
        byte[] binaryPdf = pdf.BinaryData;

        await _repository.AddReportPdf(new ReportPdfModel { PdfFile = binaryPdf });
    }
}