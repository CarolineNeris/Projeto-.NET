using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure;

namespace Application.Services;

public class ExameService : IExameService
{
    private readonly TechMedDbContext _context;

    public ExameService(TechMedDbContext context) 
    {
        _context = context;
    }

    public int Create(NewExameInputModel exame)
    {
        var atendimento = _context.Atendimentos
        .Where(a => a.Id == exame.AtendimentoId)
        .FirstOrDefault() ?? throw new AtendimentoNotFoundException();

        var _exame = new Exame 
        {
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Valor = exame.Valor,
            Local = exame.Local,
            ResultadoDescricao = exame.ResultadoDescricao,
            Atendimento = atendimento
        };

        _context.Exames.Add(_exame);
        _context.SaveChanges();

        return _exame.Id;
    }

    public List<ExameViewModel> GetAll()
    {
        var exames = _context.Exames.Select(e => new ExameViewModel(e)).ToList();

        return exames;
    }
}
