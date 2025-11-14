using Microsoft.AspNetCore.Mvc;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request.Championship;

namespace WebGames.API.Controllers.Championship;

[Route("/api/v1/championship")]
[ApiController]
public class ChampionshipsController(IChampionshipAppService championshipAppService) : Controller
{
    private IChampionshipAppService _championshipAppService = championshipAppService;

    [HttpGet]
    public async Task<IActionResult> GetByName([FromBody] ChampionshipByNameRequest request)
    {
        if (request != null)
        {
            return Ok();
        }

        return BadRequest();
    }
}
