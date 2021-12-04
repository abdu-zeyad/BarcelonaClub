using Barcelona.Models.DTO;
using Barcelona.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Barcelona.Models.Services
{
    public class UserService : IUser
    {
        public Task<UserDto> Login(LoginDto loginData)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> Register(RegisterDto registerData, ModelStateDictionary modelState)
        {
            throw new System.NotImplementedException();
        }
    }
}
