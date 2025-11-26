using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Championship;

namespace WebGames.API.Controllers;

[ApiController]
[Route("/api/v1/championship")]
public class ChampionshipsController(IChampionshipAppService championshipAppService) : BaseController
{
    private IChampionshipAppService _championshipAppService = championshipAppService;

    [HttpGet]
    public async Task<IActionResult> GetByName([FromQuery] string request)
    {
        var appService = await _championshipAppService.GetByName(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById([FromQuery] Guid Id)
    {
        var appService = await _championshipAppService.GetById(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpPost]
    public async Task<IActionResult> PostChamp([FromBody] PostChampionshipRequest request)
    {
        var appService = await _championshipAppService.PostChamp(request);
        return PostResponse(appService.Item1, appService.Item2);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteChamp([FromQuery] Guid Id)
    {
        var appService = await _championshipAppService.DeleteChamp(Id);
        return CustomResponse(appService.Item1, appService.Item2);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchChamp([FromBody] PatchChampionshipRequest request)
    {
        var appService = await _championshipAppService.PatchChamp(request);
        return CustomResponse(appService.Item1, appService.Item2);
    }
}
