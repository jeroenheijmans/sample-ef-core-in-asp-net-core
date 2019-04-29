using SampleAspNetWithEfCore.Entities;
using System.Net.Http;
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

        [Fact]
        public async Task Post_returns_created_item()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsJsonAsync("/api/people", new
            {
                name = "John Doe",
                pet = new { name = "Miffy", animal = "Cat" }
            });

            var result = await response.DeserializeContentAs<Person>();

            Assert.Equal("John Doe", result.Name);
        }
    }
}
