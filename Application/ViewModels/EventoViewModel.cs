namespace Application.ViewModels;

public class EventoViewModel
{
    public int Id { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public string? Codigo { get; set; }
    public string? Conteudo { get; set; }
    public DateTime DataHoraOcorrencia { get; set; }
}
