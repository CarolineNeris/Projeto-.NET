using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("endereco")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;

    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var enderecos = await _enderecoService.GetAllAsync();
        return Ok(enderecos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var enredeco = await _enderecoService.GetAsync(id);
        return Ok(enredeco);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EnderecoInputModel enderecoInputModel)
    {
        var endereco = await _enderecoService.InsertAsync(enderecoInputModel);
        return Ok(endereco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EnderecoInputModel enderecoInputModel)
    {
        var endereco = await _enderecoService.UpdateAsync(id, enderecoInputModel);
        return Ok(endereco);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _enderecoService.DeleteAsync(id);
        return result ? Ok(result) : NotFound();
    }
}
