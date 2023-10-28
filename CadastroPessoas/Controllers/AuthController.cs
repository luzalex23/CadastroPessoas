using CadastroPessoas.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth( string username, string password )   
        {
            if(username == "alexsandro" &&  password == "12345")
            {
                var token = TokenService.GenetateToken(new Model.Pessoas());
                return Ok(token);
            }
            return BadRequest("Username or Password invalid");
        }
    }
}
