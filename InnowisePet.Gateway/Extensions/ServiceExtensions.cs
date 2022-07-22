using System.Reflection;
using InnowisePet.HttpClients;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace InnowisePet.Gateway.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<OrderClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["OrderServiceUri"]);
        });
        services.AddHttpClient<ProductClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["ProductServiceUri"]);
        });
        services.AddHttpClient<CategoryClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["ProductServiceUri"]);
        });
        services.AddHttpClient<StorageClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["StorageServiceUri"]);
        });
        services.AddHttpClient<ProductStorageClient>(c =>
        {
            c.BaseAddress = new Uri(configuration["StorageServiceUri"]);
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        { 
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
            
            // configure SwaggerDoc and others

            // add JWT Authentication
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer", // must be lower case
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, new string[] { }}
            });

            // add Basic Authentication
            OpenApiSecurityScheme basicSecurityScheme = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
            };
            c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {basicSecurityScheme, new string[] { }}
            });
        });
    }
}