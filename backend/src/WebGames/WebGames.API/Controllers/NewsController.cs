using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.News;

namespace WebGames.API.Controllers;

[Route("/api/v1/news")]
[ApiController]
public class NewsController(INewsAppService newsAppservice) : Controller
{
    private INewsAppService _newsAppservice = newsAppservice;

    [HttpGet]
    public async Task<IActionResult> GetByName([FromBody] NewsByNameRequest request)
    {
        if (request != null)
        {
            return Ok();
        }

        return BadRequest();
    }
}
