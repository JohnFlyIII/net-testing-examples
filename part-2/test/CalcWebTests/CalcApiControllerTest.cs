using Xunit;
using Microsoft.Extensions.Logging.Abstractions;
using CalcWeb.Controllers;
using CalcWeb.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace CalcWebTests
{
    public class CalcApiControllerTest
    {
        [Fact]
        public void Controler_Direct_Test()
        {
            var nullLogger = new NullLogger<CalcApiController>();
            var calcApiController = new CalcApiController(nullLogger);

            var addRequest = new AddRequest(){lValue = 1, rValue = 2};

            var iActionResult = calcApiController.Add(addRequest);
            var okObjectResult = iActionResult as OkObjectResult;
            var addResponse = okObjectResult.Value as AddResponse;

            Assert.Equal(3, addResponse.result);

        }
    }
}
