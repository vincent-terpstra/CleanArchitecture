namespace BuberDinner.Api.Tests.Integration.Common;

public abstract class TestBase : IClassFixture<TestWebApplicationFactory>
{
    protected readonly HttpClient Client;

    protected TestBase(TestWebApplicationFactory factory)
    {
        Client = factory.CreateClientWithBearerToken();
    }
}