using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Articles;

namespace WebGames.API.Controllers;

[ApiController]
[Route("api/v1/article")]
public class ArticlesController(IArticlesAppService ariticlesAppserice) : BaseController
{
    private IArticlesAppService _ariticlesAppservice = ariticlesAppserice;

    [HttpGet]
    public async Task<IActionResult> GetByName([FromQuery] string request)
    {
        var appService = await _ariticlesAppservice.GetByName(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromQuery] Guid Id)
    {
        var appService = await _ariticlesAppservice.GetById(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpPost]
    public async Task<IActionResult> PostNews([FromBody] PostArticleRequest request)
    {
        var appService = await _ariticlesAppservice.PostArticle(request);
        return PostResponse(appService.Item1, appService.Item2);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteNews([FromQuery] Guid Id)
    {
        var appService = await _ariticlesAppservice.DeleteArticle(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchNews([FromBody] PatchArticleRequest request)
    {
        var appService = await _ariticlesAppservice.PatchArticle(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }
}
