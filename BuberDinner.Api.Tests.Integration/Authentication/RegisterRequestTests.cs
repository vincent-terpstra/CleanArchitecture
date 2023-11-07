using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Api.Tests.Integration.Authentication;

public class RegisterRequestTests : TestBase
{
    public RegisterRequestTests(TestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task ReturnsOK_OnValidRegisterRequest()
    {
        // Arrange
        var register = new RegisterRequest(
            "Vincent",
            "Terpstra",
            "register@test.com",
            "password"
        );

        // Act
        var response = await Client.PostAsJsonAsync("/auth/register", register);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();

        content.Should().BeEquivalentTo(register, options =>
            options.Excluding(cmd => cmd.Password));
    }

    [Fact]
    public async Task ReturnsConflict_OnDuplicateRegisterRequest()
    {
        // Arrange
        var register = new RegisterRequest(
            "Vincent",
            "Terpstra",
            "duplicate@test.com",
            "password"
        );

        // Act
        var response = await Client.PostAsJsonAsync("/auth/register", register);
        var duplicate = await Client.PostAsJsonAsync("/auth/register", register);

        // Assert
        duplicate.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }
}