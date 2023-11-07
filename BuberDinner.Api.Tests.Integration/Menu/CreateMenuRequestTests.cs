using BuberDinner.Contracts.Menu;

namespace BuberDinner.Api.Tests.Integration.Menu;

public class CreateMenuRequestTests : TestBase
{
    public CreateMenuRequestTests(TestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task ShouldReturnOk()
    {
        // Arrange
        var createMenu = new CreateMenuRequest("test", "test", new List<MenuSection>());
        var hostId = Guid.NewGuid();
        // Act
        var createMenuResponse = await Client.PostAsJsonAsync($"/hosts/{hostId}/menus", createMenu);

        // Assert
        createMenuResponse.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}