using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAuthentication.Repositories;
using UserAuthentication.Services;
using UserAuthentication.WebApi.ViewModels;

namespace UserAuthentication.WebApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromBody] UserViewModel model)
        {
            var user = UserRepository.Get(model.Name, model.Password);
            var token = TokenService.GenerateToken(user);
            if (user.Equals(null))
                return NotFound(new { message = "Usuário ou senha invalidos!" });
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}