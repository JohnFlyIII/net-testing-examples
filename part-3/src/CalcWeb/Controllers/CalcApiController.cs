using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator;
using CalcWeb.Models.Api;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Calculator.Data.Repositories.Interfaces;

namespace CalcWeb.Controllers
{
    [Route("api/calculator")]
    [ApiController]
    public class CalcApiController : ControllerBase
    {
        private readonly ILogger<CalcApiController> _logger;
        private readonly IConstantsRepository _constantsRepository;

        public CalcApiController(
            ILogger<CalcApiController> logger,
            IConstantsRepository constantsRepository)
        {
            _logger = logger;
            _constantsRepository = constantsRepository;

            
        }

        [HttpPost]
        [Route("add")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AddResponse), Status200OK)]
        public IActionResult Add([FromBody] AddRequest addRequest)
        {
            try
            {
               var calculator = new SimpleCalculator();
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

        [HttpPost]
        [Route("subtract")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SubtractResponse), Status200OK)]
        public IActionResult Subtract([FromBody] SubtractRequest subtractRequest)
        {
            try
            {
               var calculator = new SimpleCalculator();
               var subtractResult = calculator.Subtract(subtractRequest.lValue, subtractRequest.rValue);

               var response = new SubtractResponse()
                                {
                                    lValue = subtractRequest.lValue,
                                    rValue = subtractRequest.rValue,
                                    result = subtractResult
                                };

                return Ok(response);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure Subtracting. {ex.ToString()}");

                return StatusCode(500, "Internal Failure");
            }
        }


        [HttpPost]
        [Route("areaOfCircle")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AreaOfCircleResponse), Status200OK)]
        public IActionResult AreaOfCircle([FromBody] AreaOfCircleRequest areaOfCircleRequest)
        {
            try
            {
               var calculator = new SimpleCalculator();
               var areaOfCircleResult = calculator.AreaOfACircle(areaOfCircleRequest.radius);

               var response = new AreaOfCircleResponse()
                                {
                                    radius = areaOfCircleRequest.radius,
                                    area = areaOfCircleResult
                                };

                return Ok(response);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure calculating area of circle with radius {areaOfCircleRequest.radius}. {ex.ToString()}");

                return StatusCode(500, "Internal Failure");
            }
        }       
    }
}

