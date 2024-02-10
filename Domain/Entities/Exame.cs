using Domain.Common;

namespace Domain.Entities;

public class Exame : BaseEntity
{
    public string Nome { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Valor { get; set; }
    public string Local { get; set; }
    public string ResultadoDescricao { get; set; }
    public Atendimento Atendimento { get; set; }
    public int AtendimentoId { get; set; }
}
