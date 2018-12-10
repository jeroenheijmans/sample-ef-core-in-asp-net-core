using System.Threading.Tasks;
using Xunit;

namespace SampleAspNetWithEfCore.Tests.Integration
{
    public class PeopleControllerTests : IntegrationTests
    {
        public PeopleControllerTests(CustomWebApplicationFactory factory) 
            : base(factory)
        { }

        [Fact]
        public async Task Get_returns_success_result()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/people");
            response.EnsureSuccessStatusCode();
        }
    }
}
