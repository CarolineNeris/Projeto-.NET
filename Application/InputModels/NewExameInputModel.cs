namespace Application.InputModels;
public class NewExameInputModel
{
    public string Nome { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Valor { get; set; }
    public string Local { get; set; }
    public string ResultadoDescricao { get; set; }
    public int AtendimentoId { get; set; }
}
