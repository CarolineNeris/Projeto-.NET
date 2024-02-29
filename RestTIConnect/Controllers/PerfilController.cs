using Application.ViewModels;
using ApplicationI.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("perfil")]
[Authorize(Roles = "Admin")]
public class PerfilController : ControllerBase
{
private readonly IPerfilService _perfilService;

public PerfilController(IPerfilService perfilService)
{
    _perfilService = perfilService;
}

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var perfis = await _perfilService.GetAllAsync();
        return Ok(perfis);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var perfil = await _perfilService.GetAsync(id);
        return Ok(perfil);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PerfilInputModel perfilInputModel)
    {
        
        var perfil = await _perfilService.InsertAsync(perfilInputModel);
        return CreatedAtAction("create", perfil);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PerfilInputModel perfilInputModel)
    {
        var perfil = await _perfilService.UpdateAsync(id, perfilInputModel);
        return perfil is not null ? Ok(perfil) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _perfilService.DeleteAsync(id);
        return result ? Ok() : NotFound();
    }
}