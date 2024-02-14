using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure;

namespace Application.Services;

public class PacienteService : IPacienteService
{
    private readonly TechMedDbContext _context;

    public PacienteService(TechMedDbContext context) => _context = context;

    public int Create(NewPacienteInputModel paciente)
    {
        var _paciente = new Paciente{
            Nome = paciente.Nome,
            Cpf = paciente.Cpf,
            DataNascimento = paciente.DataNascimento
        };

        _context.Pacientes.Add(_paciente);
        _context.SaveChanges();

        return _paciente.Id;
    }

    public void Delete(int id)
    {
        _context.Pacientes.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var pacientes = _context.Pacientes.Select(p => new PacienteViewModel {
            Id = p.Id,
            Nome = p.Nome,
            Cpf = p.Cpf
        }).ToList();

        return pacientes;
    }

    public PacienteViewModel? GetById(int id)
    {
        var paciente = GetByDbId(id);

        return new PacienteViewModel
        {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Cpf = paciente.Cpf,
            DataNascimento = paciente.DataNascimento
        };
    }

    public void Update(int id, NewPacienteInputModel paciente)
    {
        var _paciente = GetByDbId(id);

        _paciente.Nome = paciente.Nome;
        _paciente.Cpf = paciente.Cpf;
        _paciente.DataNascimento = paciente.DataNascimento;

        _context.Pacientes.Update(_paciente);
        _context.SaveChanges();
    }

    private Paciente GetByDbId(int id)
    {
        var paciente = _context.Pacientes.Find(id) ?? throw new PacienteNotFoundException();

        return paciente;
    }
}
