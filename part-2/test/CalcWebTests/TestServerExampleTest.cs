using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CalcWeb;
using CalcWeb.Models.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace CalcWebTests
{
    public class TestServerExampleTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestServerExampleTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task AddTest()
        {
            // Act
            var addRequest = new AddRequest() { lValue = 1, rValue = 2 };
            var response = await _client.PostAsJsonAsync<AddRequest>("api/calculator/add", addRequest);
            response.EnsureSuccessStatusCode();
            var addResponse = await response.Content.ReadFromJsonAsync<AddResponse>();

            // Assert
            Assert.Equal(3, addResponse.result);
        }
    }
}
