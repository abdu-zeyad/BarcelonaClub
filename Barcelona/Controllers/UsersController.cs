using Barcelona.Models.DTO;
using Barcelona.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Barcelona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _user;

        public UsersController(IUser u )
        {
            _user = u;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto data)
        {
            var user = await _user.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));

            // We're gonna need to let people know if their password sucks or email is invalid...
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto data)
        {
            var user = await _user.Login(data);
            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }
    }
}
