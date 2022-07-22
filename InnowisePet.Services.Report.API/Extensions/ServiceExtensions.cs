using InnowisePet.Services.Report.BLL.Consumers;
using MassTransit;

namespace InnowisePet.Services.Report.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderAcceptedConsumer>();
            x.AddConsumer<OrderListAcceptedConsumer>();


            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("OrderAcceptedQueue", e => { e.ConfigureConsumer<OrderAcceptedConsumer>(context); });
                cfg.ReceiveEndpoint("OrderAcceptedListQueue", e => { e.ConfigureConsumer<OrderListAcceptedConsumer>(context); });
            });
        });
    }
}