using Application.InputModels;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("evento")]
[Authorize(Roles = "Admin")]
public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;

    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var eventos = await _eventoService.GetAllAsync();
        return Ok(eventos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var evento = await _eventoService.GetAsync(id);
        return Ok(evento);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EventoInputModel eventoInputModel)
    {
        var evento = await _eventoService.InsertAsync(eventoInputModel);
        return CreatedAtAction("create", evento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EventoInputModel eventoInputModel)
    {
        var evento = await _eventoService.UpdateAsync(id, eventoInputModel);
        return evento is not null ? Ok(evento) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _eventoService.DeleteAsync(id);
        return result ? Ok() : NotFound();
    }
}
