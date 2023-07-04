using Microsoft.AspNetCore.Mvc;
using NewCard.Attributes;

namespace NewCard.Controller
{   
    [ApiController]
    [Route("")]

    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        [ApiKey]
        public ActionResult Get([FromServices]IConfiguration config) 
        {
            var env = config.GetValue<string>("Env");
            return Ok(new
            {
                environment = env,
            });
        }
    }
}
