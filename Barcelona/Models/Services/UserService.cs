using Barcelona.Models.DTO;
using Barcelona.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Barcelona.Models.Services
{
    public class UserService : IUser
    {
        private UserManager<ApplicationUser> _manager;

        public UserService(UserManager<ApplicationUser> manager)
        {
            _manager = manager;
        }
        public async Task<UserDto> Login(LoginDto loginData)
        {
            var user = await _manager.FindByNameAsync(loginData.Username);
            if (await _manager.CheckPasswordAsync(user, loginData.Password))
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            return null;
        }

        public async Task<UserDto> Register(RegisterDto registerData, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName= registerData.Username,
                Email = registerData.Email,
            };
            var result = await _manager.CreateAsync(user,registerData.Password);
            if (result.Succeeded)
            {

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                  error.Code.Contains("Password") ? nameof(registerData.Password) :
                  error.Code.Contains("Email") ? nameof(registerData.Email) :
                  error.Code.Contains("UserName") ? nameof(registerData.Username) :
                  "";

                modelState.AddModelError(errorKey, error.Description);

            }

            return null;
        }
    }
}
