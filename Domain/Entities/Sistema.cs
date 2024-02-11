using Domain.Common;

namespace Domain.Entities;

public class Sistema : BaseEntity
{
    public required string Descricao { get; set; }
    public required string Tipo { get; set; }
    public required string EnderecoEntrado { get; set; }
    public required string EnderecoSaida { get; set; }
    public required string Protocolo { get; set; }
    public DateTimeOffset DataHoraInicioIntegracao { get; set; }

    public required string Status  { get; set; }
    public required ICollection<Evento> Eventos { get; set; }

    public required ICollection<Usuario> Usuarios { get; set; }
}
