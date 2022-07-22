using InnowisePet.Services.Report.API.Extensions;
using InnowisePet.Services.Report.BLL.Services;
using InnowisePet.Services.Report.DAL;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureMassTransit();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ReportPdfRepository>();
builder.Services.AddScoped<IGeneratePdfService, GeneratePdfService>();


WebApplication app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
