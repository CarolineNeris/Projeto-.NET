using Domain.Common;

namespace Domain.Entities;

public class Paciente : BaseEntity
{
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public Atendimento[] Atendimentos { get; set; }
    public Paciente()
    {
        Atendimentos = new Atendimento[0];
    }
}
