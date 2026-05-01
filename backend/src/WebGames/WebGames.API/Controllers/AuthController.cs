using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Auth;
using WebGames.Application.Request.Auth;

namespace WebGames.API.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController(IAuthAppService authAppService) : BaseController
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var appService = await authAppService.Login(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [AllowAnonymous]
    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var appService = await authAppService.CreateUser(request);
        return PostResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpPost("admins")]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateUserRequest request)
    {
        var appService = await authAppService.CreateAdmin(request);
        return PostResponse(appService.Item1, appService.Item2);
    }
}
