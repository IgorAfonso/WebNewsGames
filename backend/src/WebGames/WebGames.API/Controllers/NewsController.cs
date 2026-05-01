using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Auth;
using WebGames.Application.Request;
using WebGames.Application.Request.News;

namespace WebGames.API.Controllers;

[Route("/api/v1/news")]
[ApiController]
public class NewsController(INewsAppService newsAppservice) : BaseController
{
    private readonly INewsAppService _newsAppservice = newsAppservice;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var appService = await _newsAppservice.GetAll(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromQuery] Guid Id)
    {
        var appService = await _newsAppservice.GetById(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpPost]
    public async Task<IActionResult> PostNews([FromBody] PostNewsRequest request)
    {
        var appService = await _newsAppservice.PostNews(request);
        return PostResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpDelete]
    public async Task<IActionResult> DeleteNews([FromQuery] Guid Id)
    {
        var appService = await _newsAppservice.DeleteNews(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpPatch]
    public async Task<IActionResult> PatchNews([FromBody] PatchNewsRequest request)
    {
        var appService = await _newsAppservice.PatchNews(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }
}
