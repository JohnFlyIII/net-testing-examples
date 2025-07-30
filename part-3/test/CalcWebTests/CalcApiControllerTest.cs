using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using CalcWeb.Controllers;
using CalcWeb.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace CalcWebTests
{
    public class CalcApiControllerTest
    {
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(4,4,8)]
        [InlineData(0,1,1)]
        [InlineData(1,0,1)]
        public void Controler_Direct_Test_Add(int lValue, int rValue, int expectedResult)
        {
            // Arrange
            var nullLogger = new NullLogger<CalcApiController>();
            var calcApiController = new CalcApiController(nullLogger);

            var addRequest = new AddRequest(){lValue =lValue, rValue = rValue};

            // Act
            var iActionResult = calcApiController.Add(addRequest);
            var okObjectResult = iActionResult as OkObjectResult;
            var addResponse = okObjectResult?.Value as AddResponse;

            // Assert
            Assert.NotNull(okObjectResult);
            Assert.NotNull(addResponse);
            Assert.Equal(expectedResult, addResponse.result);
        }
    }
}
