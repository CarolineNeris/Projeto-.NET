namespace Application.ViewModels;
public class AtendimentoViewModel
{
    public DateTime DataHoraInicio { get; set; }
    public string SuspeitaInicial { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string Diagnostico { get; set; }
    public PacienteViewModel Paciente { get; set; }
    public MedicoViewModel Medico { get; set; }
}
