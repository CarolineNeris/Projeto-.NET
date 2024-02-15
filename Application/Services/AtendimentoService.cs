using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure;

namespace Application.Services;

public class AtendimentoService : IAtendimentoService
{
    private readonly TechMedDbContext _context;
    private readonly IMedicoService _medicoService;

    public AtendimentoService(TechMedDbContext context, IMedicoService medicoService)
    {
        _context = context;
        _medicoService = medicoService;
    } 

    public int Create(NewAtendimentoInputModel atendimento)
    {
        return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
    }

    public List<AtendimentoViewModel> GetAll()
    {
        return _context.Atendimentos.Select(a => new AtendimentoViewModel(a)).ToList();
    }

    public AtendimentoViewModel? GetById(int id)
    {
        var atendimento = GetReferenceById(id);

        return new AtendimentoViewModel(atendimento);
    }

    public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
    {
        var atendimentos = _context.Atendimentos.Where(a => a.MedicoId == medicoId);

        return atendimentos.Select(a => new AtendimentoViewModel(a)).ToList();
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {
        var atendimentos = _context.Atendimentos.Where(a => a.PacienteId == pacienteId);

        return atendimentos.Select(a => new AtendimentoViewModel(a)).ToList();
    }

    private Atendimento GetReferenceById(int id)
    {
        var atendimento = _context.Atendimentos.Where(a => a.Id == id).FirstOrDefault() ?? throw new AtendimentoNotFoundException();

        return atendimento;
    }
}
