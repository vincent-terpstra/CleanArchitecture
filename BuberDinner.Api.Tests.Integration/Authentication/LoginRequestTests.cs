using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Api.Tests.Integration.Authentication;

public class LoginRequestTests : TestBase
{
    public LoginRequestTests(TestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task ReturnsUnauthorized_WhenNoUser()
    {
        // Arrange
        var login = new LoginRequest(
            "unknown@test.com",
            "password"
        );

        // Act
        var response = await Client.PostAsJsonAsync("/auth/login", login);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task ReturnsOk_WithRegisteredUser()
    {
        // Arrange
        var command = new RegisterRequest(
            "Vincent",
            "Terpstra",
            "login@test.com",
            "password"
        );

        // Act
        var registerResponse = await Client.PostAsJsonAsync("/auth/register", command);

        var login = new LoginRequest(
            command.Email,
            command.Password
        );

        var response = await Client.PostAsJsonAsync("/auth/login", login);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}