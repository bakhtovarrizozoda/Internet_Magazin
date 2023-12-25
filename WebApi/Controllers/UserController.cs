using Domain.Dtos.User.LoginDto;
using Domain.Dtos.User.RegisterDto;
using Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("get-all-user")]
    public async Task<IActionResult> GetAllUser()
    {
        var response = await _service.GetAllUserAsync();
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromQuery]LoginRequestDto model)
    {
        var response = await _service.LoginAsync(model);
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromQuery]RegisterRequestDto model)
    {
        var response = await _service.RegisterAsync(model);
        return Ok(response);
    }

    [HttpPut("unblocked")]
    public async Task<IActionResult> UnBlockedAsync(int id)
    {
        var response = await _service.UnBlockedUserAsync(id);
        return Ok(response);
    }

    [HttpPut("blocked")]
    public async Task<IActionResult> BlockedAsync(int id)
    {
        var response = await _service.BlockedUserAsync(id);
        return Ok(response);
    }

}