using Microsoft.AspNetCore.Mvc;
using RabbitMQ_Example.Service;

namespace RabbitMQ_Example.Controllers
{
    [ApiController]
    [Route("api/example")]
    public class ExampleController : Controller
    {
        private readonly IRabbitMQService _rabbitMQService;
        public ExampleController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        [HttpGet]
        public IActionResult Get(string name)
        {
            _rabbitMQService.SendNametoQueue(name);
            return Ok("Success");
        }
    }
}
