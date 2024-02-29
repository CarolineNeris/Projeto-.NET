using Application.InputModels;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("sistema")]
public class SistemaController : ControllerBase
{
    private readonly ISistemaService _sistemaService;

    public SistemaController(ISistemaService sistemaService)
    {
        _sistemaService = sistemaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sistemas = await _sistemaService.GetAllAsync();
        return Ok(sistemas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sistema = await _sistemaService.GetAsync(id);
        return Ok(sistema);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SistemaInputModel sistemaInputModel)
    {
        var sistema = await _sistemaService.InsertAsync(sistemaInputModel);
        return CreatedAtAction("create", sistema);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SistemaInputModel sistemaInputModel)
    {
        var sistema = await _sistemaService.UpdateAsync(id, sistemaInputModel);
        return sistema is not null ? Ok(sistema) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sistemaService.DeleteAsync(id);
        return result ? Ok() : NotFound();
    }
}
