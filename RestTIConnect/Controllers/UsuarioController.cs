using Application.InputModels;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.GetAsync(id);
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioInputModel usuarioInputModel)
    {
        var usuario = await _usuarioService.InsertAsync(usuarioInputModel);
        return CreatedAtAction("create", usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioInputModel usuarioInputModel)
    {
        var usuario = await _usuarioService.UpdateAsync(id, usuarioInputModel);
        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _usuarioService.DeleteAsync(id);
        return result ? Ok() : NotFound();
    }

    [HttpPost("{usuarioId}/perfil/{perfilId}")]
    public async Task<IActionResult> AddPerfil(int usuarioId, int perfilId)
    {
        var result = await _usuarioService.AddPerfil(usuarioId, perfilId);
        return result is null ? Ok(result) : BadRequest();
    }
}
