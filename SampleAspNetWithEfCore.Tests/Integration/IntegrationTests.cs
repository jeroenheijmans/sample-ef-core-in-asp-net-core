using Xunit;

namespace SampleAspNetWithEfCore.Tests.Integration
{
    [Trait("Category", "Integration")]
    [Collection(ApiIntegrationTestsCollection.Name)]
    public abstract class IntegrationTests
        : IClassFixture<ApiIntegrationTestsFixture>
    {
        protected readonly ApiIntegrationTestsFixture _factory;

        protected IntegrationTests(ApiIntegrationTestsFixture factory)
        {
            _factory = factory;
        }
    }
}
