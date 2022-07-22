using InnowisePet.Services.Order.BLL.Consumers;
using MassTransit;

namespace InnowisePet.Services.Order.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderCreateConsumer>();
            x.AddConsumer<OrderUpdateConsumer>();
            x.AddConsumer<OrderUpdateListConsumer>();
            x.AddConsumer<OrderDeleteConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("OrderCreateQueue", e => { e.ConfigureConsumer<OrderCreateConsumer>(context); });
                cfg.ReceiveEndpoint("OrderUpdateQueue", e => { e.ConfigureConsumer<OrderUpdateConsumer>(context); });
                cfg.ReceiveEndpoint("OrderUpdateListQueue", e => { e.ConfigureConsumer<OrderUpdateListConsumer>(context); });
                cfg.ReceiveEndpoint("OrderDeleteQueue", e => { e.ConfigureConsumer<OrderDeleteConsumer>(context); });
            });
        });
    }
}