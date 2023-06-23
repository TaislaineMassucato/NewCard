using Microsoft.AspNetCore.Mvc;
using NewCard.Services;

namespace NewCard.Controller
{
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost("v1/login")]
        public IActionResult Login([FromServices] TokenService tokenService) 
        {
            var token = tokenService.GerarToken(null);

            return Ok(token);

        }
    }
}
