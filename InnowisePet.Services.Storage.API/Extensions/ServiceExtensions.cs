using InnowisePet.Services.Storage.BLL.Consumers;
using InnowisePet.Services.Storage.BLL.Services.Implementations;
using InnowisePet.Services.Storage.BLL.Services.Interfaces;
using InnowisePet.Services.Storage.DAL.Repo.Implementations;
using InnowisePet.Services.Storage.DAL.Repo.Interfaces;
using MassTransit;

namespace InnowisePet.Services.Storage.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<StorageCreateConsumer>();
            x.AddConsumer<StorageUpdateConsumer>();
            x.AddConsumer<StorageDeleteConsumer>();
            x.AddConsumer<ProductStorageCreateConsumer>();
            x.AddConsumer<ProductStorageUpdateConsumer>();
            x.AddConsumer<ProductStorageDeleteConsumer>();
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("StorageCreateQueue", e =>  e.ConfigureConsumer<StorageCreateConsumer>(context));
                cfg.ReceiveEndpoint("StorageUpdateQueue", c => c.ConfigureConsumer<StorageUpdateConsumer>(context));
                cfg.ReceiveEndpoint("StorageDeleteQueue", c => c.ConfigureConsumer<StorageDeleteConsumer>(context));
                cfg.ReceiveEndpoint("ProductStorageCreateQueue", c => c.ConfigureConsumer<ProductStorageCreateConsumer>(context));
                cfg.ReceiveEndpoint("ProductStorageUpdateQueue", c => c.ConfigureConsumer<ProductStorageUpdateConsumer>(context));
                cfg.ReceiveEndpoint("ProductStorageDeleteQueue", c => c.ConfigureConsumer<ProductStorageDeleteConsumer>(context));
            });
        });
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<IStorageService, StorageService>();

        services.AddScoped<IProductStorageRepository, ProductStorageRepository>();
        services.AddScoped<IProductStorageService, ProductStorageService>();
    }
}