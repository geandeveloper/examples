using System.Threading.Tasks;
using DependencyInjection.Api.Models;
using DependencyInjection.Library.Common;
using DependencyInjection.Library.Models;
using DependencyInjection.Library.Quebrada;
using Microsoft.AspNetCore.Mvc;

[Route("api/quebrada")]
public class QuebradaController : ControllerBase
{
    private readonly RequestTracker _requestTracker;
    private readonly SalveService _salveService;
    private int TentativasSalves { get; set; }

    public QuebradaController(
        RequestTracker requestTracker,
        SalveService salveService)
    {
        _requestTracker = requestTracker;
        _salveService = salveService;
        TentativasSalves = 0;
    }

    [HttpGet]
    [Route("salve/{name}")]
    public async Task<IActionResult> Salve(string name)
    {
        _requestTracker.Track(() => "Se preparando para dar um salve");
        var salveMessage = await _salveService.SalveAsync(name);
        TentativasSalves++;
        _requestTracker.Track(() => $"Tentativas de salve {TentativasSalves}");

        return Ok(new SalveDto(salveMessage, _requestTracker.Events));
    }
    
    [HttpPost]
    [Route("manos")]
    public async Task<IActionResult> CriarUmMano([FromBody] Mano name)
    {
        await _salveService.CriarManoAsync(name);

        return Ok(_requestTracker.Events);
    }
}