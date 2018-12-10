using System.Threading.Tasks;
using Xunit;

namespace SampleAspNetWithEfCore.Tests.Integration
{
    public class SystemControllerTests : IntegrationTests
    {
        public SystemControllerTests(CustomWebApplicationFactory factory) 
            : base(factory)
        { }

        [Fact]
        public async Task System_Ping_Returns_Dto()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/system/ping");
            var responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Contains("suffix-from-test-appsettings", responseBody);
        }
    }
}
