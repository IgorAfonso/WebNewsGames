using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Auth;
using WebGames.Application.Request;
using WebGames.Application.Request.Championship;

namespace WebGames.API.Controllers;

[ApiController]
[Route("/api/v1/championship")]
public class ChampionshipsController(IChampionshipAppService championshipAppService) : BaseController
{
    private readonly IChampionshipAppService _championshipAppService = championshipAppService;

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var appService = await _championshipAppService.GetAll(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdPath(Guid id)
    {
        var appService = await _championshipAppService.GetById(id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [AllowAnonymous]
    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromQuery] Guid Id)
    {
        var appService = await _championshipAppService.GetById(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpPost]
    public async Task<IActionResult> PostChamp([FromBody] PostChampionshipRequest request)
    {
        var appService = await _championshipAppService.PostChamp(request);
        return PostResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpDelete]
    public async Task<IActionResult> DeleteChamp([FromQuery] Guid Id)
    {
        var appService = await _championshipAppService.DeleteChamp(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [Authorize(Roles = AuthRoles.Administrator)]
    [HttpPatch]
    public async Task<IActionResult> PatchChamp([FromBody] PatchChampionshipRequest request)
    {
        var appService = await _championshipAppService.PatchChamp(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }
}
