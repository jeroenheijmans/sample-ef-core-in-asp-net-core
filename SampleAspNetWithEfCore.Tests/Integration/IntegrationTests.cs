using Xunit;

namespace SampleAspNetWithEfCore.Tests.Integration
{
    [Trait("Category", "Integration")]
    public abstract class IntegrationTests
        : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly CustomWebApplicationFactory _factory;

        protected IntegrationTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }
    }
}
