using System.Net.Http.Headers;
using BuberDinner.Application.Authentication.Interfaces;
using BuberDinner.Domain.UserAggregates.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Api.Tests.Integration.Common;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    public HttpClient CreateClientWithBearerToken()
    {
        var services = Services;
        var tokenProvider = services.GetRequiredService<IJwtTokenGenerator>();

        var user = new User
        {
            FirstName = "test",
            LastName = "test",
            Email = "test@test.ca",
            Password = "test123"
        };

        var token = tokenProvider.GenerateToken(user);
        var client = CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        return client;
    }
}