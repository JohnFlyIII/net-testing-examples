using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Devices;
using CalcWeb.Models.Api;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace CalcWeb.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalcApiController : ControllerBase
    {
        private readonly ILogger<CalcApiController> _logger;

        public CalcApiController(
            ILogger<CalcApiController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("add")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AddResponse), Status200OK)]
        public IActionResult Add([FromBody] AddRequest addRequest)
        {
            try
            {
               var calculator = new Calculator();
               var addResult = calculator.Add(addRequest.lValue, addRequest.rValue);

               var response = new AddResponse()
                                {
                                    lValue = addRequest.lValue,
                                    rValue = addRequest.rValue,
                                    result = addResult
                                };

                return Ok(response);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure Adding. {ex.ToString()}");

                return StatusCode(500, "Internal Failure");
            }
        }       
    }
}

