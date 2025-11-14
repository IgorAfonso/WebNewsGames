using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Articles;

namespace WebGames.API.Controllers.Articles;

[ApiController]
[Route("api/v1/article")]
public class ArticlesController(IArticlesAppService ariticlesAppserice) : Controller
{
    private IArticlesAppService _ariticlesAppserice = ariticlesAppserice;

    [HttpGet]
    public async Task<IActionResult> GetByName([FromBody] ArticleByNameRequest request)
    {
        if(request != null)
        {
            return Ok();
        }

        return BadRequest();
    }
}
