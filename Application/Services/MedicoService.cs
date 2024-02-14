using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure;

namespace Application.Services;

public class MedicoService : IMedicoService
{
    private readonly TechMedDbContext _context;

    public MedicoService(TechMedDbContext context) => _context = context;

    public int Create(NewMedicoInputModel medico)
    {
        var _medico = new Medico
        {
            Nome = medico.Nome,
            Crm = medico.Crm,
            Cpf = medico.Cpf
        };

        _context.Medicos.Add(_medico);
        _context.SaveChanges();
        
        return _medico.Id;
    }

    public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
    {
        var medico = GetReferenceById(medicoId);
        var paciente = _context.Pacientes
        .Where(p => p.Id == atendimento.PacienteId)
        .FirstOrDefault() ?? throw new PacienteNotFoundException();

        var _atendimento = new Atendimento {
            DataHoraInicio = atendimento.DataHoraInicio,
            SuspeitaInicial = atendimento.SuspeitaInicial,
            Diagnostico = atendimento.Diagnostico,
            DataHoraFim = atendimento.DataHoraFim,
            PacienteId = atendimento.PacienteId,
            Paciente = paciente,
            MedicoId = medicoId,
            Medico = medico
        };

        return _atendimento.Id;
    }

    public void Delete(int id)
    {
        var medico = GetReferenceById(id);

        _context.Medicos.Remove(medico);
        _context.SaveChanges();
    }

    public List<MedicoViewModel> GetAll()
    {
        var medicos = _context.Medicos.Select(m => new MedicoViewModel (m)).ToList();

        return medicos;
    }

    public MedicoViewModel? GetByCrm(string crm)
    {
        var medico = _context.Medicos.Where(m => m.Crm == crm).FirstOrDefault() ?? throw new MedicoNotFoundException();

        return new MedicoViewModel(medico);
    }

    public MedicoViewModel? GetById(int id)
    {
        var medico = GetReferenceById(id);

        return new MedicoViewModel(medico);
    }

    public void Update(int id, NewMedicoInputModel medico)
    {
        var _medico = GetReferenceById(id);

        if(medico.Nome is not null) _medico.Nome = medico.Nome;
        if(medico.Cpf is not null) _medico.Cpf = medico.Cpf;
        if(medico.Crm is not null) _medico.Crm = medico.Crm;
        _medico.UpdatedAt = DateTime.Now;

        _context.Medicos.Update(_medico);
        _context.SaveChanges();
    }

    private Medico GetReferenceById(int id)
    {
        var medico = _context.Medicos.Find(id) ?? throw new MedicoNotFoundException();

        return medico;
    }
}
