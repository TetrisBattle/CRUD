using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public string SayHello()
        {
            return "Hello World!";
        }
    }
}
