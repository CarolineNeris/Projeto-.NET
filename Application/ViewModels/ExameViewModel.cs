using Domain.Entities;

namespace Application.ViewModels;
public class ExameViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataHora { get; set; }
    public decimal Valor { get; set; }
    public string Local { get; set; }
    public string ResultadoDescricao { get; set; }
    public AtendimentoViewModel Atendimento { get; set; }

    public ExameViewModel(Exame exame)
    {
        Id = exame.Id;
        Nome = exame.Nome;
        DataHora = exame.DataHora;
        Valor = exame.Valor;
        Local = exame.Local;
        ResultadoDescricao = exame.ResultadoDescricao;
        Atendimento = new AtendimentoViewModel(exame.Atendimento);
    }
}
