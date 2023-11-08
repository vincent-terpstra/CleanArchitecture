using System.Text;
using BuberDinner.Application.Authentication.Interfaces;
using BuberDinner.Application.Common;
using BuberDinner.Application.Menus.Interfaces;
using BuberDinner.Application.Users;
using BuberDinner.Domain.UserAggregates.Entities;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Common;
using BuberDinner.Infrastructure.Common.Interceptors;
using BuberDinner.Infrastructure.Menus;
using BuberDinner.Infrastructure.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services
            .AddAuth(config)
            .AddPersistence(config);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<BuberDinnerDbContext>(
            options => options.UseSqlServer(config.GetConnectionString("SqlDatabase")
            ));
        services.AddIdentity<User, IdentityRole>(
            options =>
            {
                options.Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequireNonAlphanumeric = true
                };

                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<BuberDinnerDbContext>();
        services.AddScoped<PublishDomainEventsInterceptor>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services,
        IConfiguration config)
    {
        var jwtSettings = new JwtSettings();
        config.GetSection(nameof(JwtSettings))
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