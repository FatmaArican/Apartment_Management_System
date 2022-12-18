using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DatabaseDummyController : ControllerBase
    {
        private readonly ILogger<DatabaseDummyController> _logger;

        public DatabaseDummyController(ILogger<DatabaseDummyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}