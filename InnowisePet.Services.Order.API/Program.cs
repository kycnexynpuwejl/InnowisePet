using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Order.API;
using InnowisePet.Services.Order.BLL;
using InnowisePet.Services.Order.DAL;
using InnowisePet.Services.Order.DAL.Repo;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x => {
    x.AddConsumer<OrderCreateConsumer>();
    x.AddConsumer<OrderUpdateConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("OrderUpdateQueue", e =>
        {
            e.ConfigureConsumer<OrderUpdateConsumer>(context);
        });
        cfg.ReceiveEndpoint("OrderCreateQueue", e =>
        {
            e.ConfigureConsumer<OrderCreateConsumer>(context);
        });
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("OrderDBConnection"),
        b => b.MigrationsAssembly("InnowisePet.Services.Order.API")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();