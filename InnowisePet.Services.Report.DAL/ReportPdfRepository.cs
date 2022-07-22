using MongoDB.Driver;

namespace InnowisePet.Services.Report.DAL;

public class ReportPdfRepository
{
    private readonly IMongoCollection<ReportPdfModel> _mongoCollection;

    public ReportPdfRepository()
    {
        MongoClient client = new("mongodb://localhost:27017");
        IMongoDatabase reportDb = client.GetDatabase("report");
        _mongoCollection = reportDb.GetCollection<ReportPdfModel>("pdfcollection");
    }

    public async Task AddReportPdf(ReportPdfModel report)
    {
        await _mongoCollection.InsertOneAsync(report);
    }
}