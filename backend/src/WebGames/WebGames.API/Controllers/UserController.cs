using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.User;

namespace WebGames.API.Controllers;

[Route("/api/v1/user")]
[ApiController]
public class UserController(IUserAppService userAppservice) : Controller
{
    private IUserAppService _userAppservice = userAppservice;

    [HttpGet]
    public IActionResult GetByName([FromBody] UserByNameRequest request)
    {
        if (request != null)
        {
            return Ok();
        }

        return BadRequest();
    }
}
