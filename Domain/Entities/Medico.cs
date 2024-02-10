using Domain.Common;

namespace Domain.Entities;

public class Medico : BaseEntity
{
    public required string Nome { get; set; }
    public required string Crm { get; set; }
    public required string Cpf { get; set; }
    public Atendimento[] Atendimentos { get; set; }
    public Medico()
    {
        Atendimentos = new Atendimento[0];
    }
}
