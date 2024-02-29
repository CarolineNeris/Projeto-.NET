namespace Application.InputModels;

public class EventoInputModel
{
    public required string Tipo { get; set; }
    public required string Descricao { get; set; }
    public required string Codigo { get; set; }
    public required string Conteudo { get; set; }
    public required DateTime DataHoraOcorrencia { get; set; }
}
