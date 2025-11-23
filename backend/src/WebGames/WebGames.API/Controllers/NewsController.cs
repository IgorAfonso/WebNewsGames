using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.News;

namespace WebGames.API.Controllers;

[Route("/api/v1/news")]
[ApiController]
public class NewsController(INewsAppService newsAppservice) : BaseController
{
    private INewsAppService _newsAppservice = newsAppservice;

    [HttpGet("id")]
    public async Task<IActionResult> GetByName([FromQuery] string request)
    {
        var appService = await _newsAppservice.GetByName(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] Guid Id)
    {
        var appService = await _newsAppservice.GetById(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpPost]
    public async Task<IActionResult> PostNews([FromBody] PostNewsRequest request)
    {
        var appService = await _newsAppservice.PostNews(request);
        return PostResponse(appService.Item1, appService.Item2);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteNews([FromQuery] Guid Id)
    {
        var appService = await _newsAppservice.DeleteNews(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchNews([FromBody] PatchNewsRequest request)
    {
        var appService = await _newsAppservice.PatchNews(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }
}
