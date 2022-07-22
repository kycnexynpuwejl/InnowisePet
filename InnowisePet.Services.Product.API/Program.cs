using System.Reflection;
using InnowisePet.Services.Product.API.Extensions;
using InnowisePet.Services.Product.DAL.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.Load("InnowisePet.Services.Product.BLL"));

builder.Services.ConfigureMassTransit();
builder.Services.ConfigureServices();

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDBConnection"),
        b => b.MigrationsAssembly("InnowisePet.Services.Product.API")));

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