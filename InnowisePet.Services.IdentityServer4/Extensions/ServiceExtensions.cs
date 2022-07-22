using InnowisePet.IdentityServer4.Configurations;
using InnowisePet.IdentityServer4.Data;
using InnowisePet.IdentityServer4.Models;
using InnowisePet.IdentityServer4.Services.Implementations;
using InnowisePet.IdentityServer4.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InnowisePet.IdentityServer4.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequiredLength = 1;
            }).AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddAspNetIdentity<AppUser>()
            .AddInMemoryApiResources(IdentityConfiguration.ApiResources())
            .AddInMemoryClients(IdentityConfiguration.Clients())
            .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources())
            .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes())
            .AddDeveloperSigningCredential();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationManager, AuthenticationManager>();
        services.AddScoped<IAccountService, AccountService>();
    }
}