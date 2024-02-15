using Domain.Entities;

namespace Application.ViewModels;
public class AtendimentoViewModel
{
    public int Id { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public string SuspeitaInicial { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string Diagnostico { get; set; }
    public PacienteViewModel Paciente { get; set; }
    public MedicoViewModel Medico { get; set; }

    public AtendimentoViewModel(Atendimento atendimento)
    {
        Id = atendimento.Id;
        DataHoraInicio = atendimento.DataHoraInicio;
        SuspeitaInicial = atendimento.SuspeitaInicial;
        DataHoraFim = atendimento.DataHoraFim;
        Diagnostico = atendimento.Diagnostico;
        Paciente = new PacienteViewModel(atendimento.Paciente);
        Medico = new MedicoViewModel(atendimento.Medico);
    }
}
