namespace Application.ViewModels;
public class ExameViewModel
{
    public string Nome { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Valor { get; set; }
    public string Local { get; set; }
    public sbyte ResultadoDescricao { get; set; }
    public AtendimentoViewModel Atendimento { get; set; }
}
