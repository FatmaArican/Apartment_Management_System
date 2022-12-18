using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Requests.Users;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequest request)
        {
            _userService.Create(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserRequest request)
        {
            _userService.Update(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            return Ok(_userService.ListOfUser());
        }

        [HttpGet("types")]
        public IActionResult ListOfTypes()
        {
            return Ok(_userService.ListOfUserTypes());
        }

        [HttpPost("pay-mine-due")]
        public IActionResult PayMineApartmentDue([FromBody] PayMineDueRequest request)
        {
            _userService.PayMineDue(request);
            return Ok();
        }
    }
}