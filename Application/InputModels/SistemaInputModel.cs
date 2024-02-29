namespace Application.InputModels;

public class SistemaInputModel
{
    public required string Descricao { get; set; }
    public required string Tipo { get; set; }
    public required string EnderecoEntrado { get; set; }
    public required string EnderecoSaida { get; set; }
    public required string Protocolo { get; set; }
    public DateTimeOffset DataHoraInicioIntegracao { get; set; }

    public required string Status  { get; set; }
}
