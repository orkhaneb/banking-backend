using User.Models;
using User.Models.DTOs;

namespace User.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterAsync(UserRegisterDto dto);
        Task<UserResponseDto> LoginAsync(UserLoginDto dto);

    }
}
