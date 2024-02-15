using Domain.Entities;

namespace Application.ViewModels;
public class PacienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }

    public PacienteViewModel(Paciente paciente)
    {
        Id = paciente.Id;
        Nome = paciente.Nome;
        Cpf = paciente.Cpf;
        DataNascimento = paciente.DataNascimento;
    }
}
