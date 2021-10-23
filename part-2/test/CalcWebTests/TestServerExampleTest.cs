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

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(4,4,8)]
        [InlineData(0,1,1)]
        [InlineData(1,0,1)]
        public async Task AddTest(int lValue, int rValue, int expectedResult)
        {
            // Act
            var addRequest = new AddRequest() { lValue = lValue, rValue = rValue };
            var response = await _client.PostAsJsonAsync<AddRequest>("api/calculator/add", addRequest);
            
            response.EnsureSuccessStatusCode();
            var addResponse = await response.Content.ReadFromJsonAsync<AddResponse>();

            // Assert
            Assert.Equal(expectedResult, addResponse.result);
        }


        [Theory]
        [InlineData(1,1,0)]
        [InlineData(2,2,0)]
        [InlineData(4,4,0)]
        [InlineData(0,1,-1)]
        [InlineData(1,0,1)]
        public async Task SubtractTest(int lValue, int rValue, int expectedResult)
        {
            // Act
            var subtractRequest = new SubtractRequest() { lValue = lValue, rValue = rValue };
            var response = await _client.PostAsJsonAsync<SubtractRequest>("api/calculator/subtract", subtractRequest);
            
            response.EnsureSuccessStatusCode();
            var subtractResponse = await response.Content.ReadFromJsonAsync<SubtractResponse>();

            // Assert
            Assert.Equal(expectedResult, subtractResponse.result);
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 3.14)]
        public async Task AreaOfCircle(decimal radius, decimal expectedResult)
        {
            // Act
            var radiusRequest = new AreaOfCircleRequest() { radius = radius };
            var response = await _client.PostAsJsonAsync<AreaOfCircleRequest>("api/calculator/areaOfCircle", radiusRequest);
            
            response.EnsureSuccessStatusCode();
            var areaOfCircleResponse = await response.Content.ReadFromJsonAsync<AreaOfCircleResponse>();

            // Assert
            Assert.Equal(expectedResult, areaOfCircleResponse.area);
        }
    }
}
