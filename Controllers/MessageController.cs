using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Requests.Messages;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageService _messageService;

        public MessageController(ILogger<MessageController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        [HttpGet("{toId}")]
        public IActionResult AllUsers([FromRoute] int toId, [FromQuery] bool isRead)
        {
            return Ok(_messageService.ListOfMessage(toId, isRead));
        }

        [HttpPost("to-manager")]
        public IActionResult SendMessageToManager([FromBody] SendMessageToManagerRequest request)
        {
            _messageService.SendMessageToManager(request);
            return Ok();
        }
    }
}