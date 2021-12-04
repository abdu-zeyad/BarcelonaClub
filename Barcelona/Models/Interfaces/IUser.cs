using Barcelona.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Barcelona.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Login(LoginDto loginData);
        public Task<UserDto> Register(RegisterDto registerData, ModelStateDictionary modelState);
    }
}
