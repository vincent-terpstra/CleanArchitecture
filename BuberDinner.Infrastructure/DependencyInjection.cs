using System.Text;
using BuberDinner.Application.Authentication.Interfaces;
using BuberDinner.Application.Common;
using BuberDinner.Application.Menus.Interfaces;
using BuberDinner.Application.Users;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Common;
using BuberDinner.Infrastructure.Common.Interceptors;
using BuberDinner.Infrastructure.Menus;
using BuberDinner.Infrastructure.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services
            .AddAuth(builderConfiguration)
            .AddPersistence(builderConfiguration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<BuberDinnerDbContext>(
            options => options.UseSqlServer(config.GetConnectionString("SqlDatabase")
            ));
        services.AddScoped<PublishDomainEventsInterceptor>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        var jwtSettings = new JwtSettings();
        builderConfiguration.GetSection(nameof(JwtSettings))
            .Bind(jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            });

        return services;
    }
}