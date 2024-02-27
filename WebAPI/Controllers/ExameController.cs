using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Application.ViewModels;
using Application.InputModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameController : ControllerBase
{
   private readonly IExameService _exameService;
   public List<ExameViewModel> Exames => _exameService.GetAll();
   public ExameController(IExameService service) => _exameService = service;
   
   [HttpGet("exames")]
   public IActionResult Get()
   {
      return Ok(Exames);

   }

   [HttpPost("exame")]
   public IActionResult Post([FromBody] NewExameInputModel exame)
   {
      _exameService.Create(exame);
      return CreatedAtAction(nameof(Get), exame);
 
   }


}