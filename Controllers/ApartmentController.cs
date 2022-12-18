using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Requests.Apartments;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("apartments")]
    public class ApartmentController : ControllerBase
    {
        private readonly ILogger<ApartmentController> _logger;
        private readonly IApartmentService _apartmentService;

        public ApartmentController(ILogger<ApartmentController> logger, IApartmentService apartmentService)
        {
            _logger = logger;
            _apartmentService = apartmentService;
        }

        [HttpGet("types")]
        public IActionResult ListOfApartmentTypes()
        {
            _logger.LogInformation("call apartment types");
            return Ok(_apartmentService.ListOfApartmentTypes());
        }

        [HttpGet]
        public IActionResult ListOfApartments()
        {
            return Ok(_apartmentService.ListOfApartments());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateApartmentRequest request)
        {
            _apartmentService.Create(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateApartmentRequest request)
        {
            _apartmentService.Update(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _apartmentService.Delete(id);
            return Ok();
        }
    }
}