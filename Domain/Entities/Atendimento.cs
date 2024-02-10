using Domain.Common;

namespace Domain.Entities;

public class Atendimento : BaseEntity
{
    public required DateTime DataHoraInicio { get; set; }
    public required string SuspeitaInicial { get; set; }
    public required DateTime DataHoraFim { get; set; }
    public required string Diagnostico { get; set; }
    public required Paciente Paciente { get; set; }
    public required int PacienteId { get; set; }
    public required Medico Medico { get; set; }
    public required int MedicoId { get; set; }
    public Exame[] Exames { get; set; }
    public Atendimento()
    {
        Exames = new Exame[0];
    }
}
