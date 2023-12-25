using Domain.Dtos.User.LoginDto;
using Domain.Dtos.User.RegisterDto;
using Domain.Dtos.User.UserDto;
using Domain.Wrapper;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    public Task<Response<List<GetAllUserDto>>> GetAllUserAsync();
    public Task<Response<string>> UnBlockedUserAsync(int id);
    public Task<Response<string>> BlockedUserAsync(int id);
    public Task<Response<LoginResponseDto>> LoginAsync(LoginRequestDto model);
    public Task<Response<RegisterRequestDto>> RegisterAsync(RegisterRequestDto model);
}
