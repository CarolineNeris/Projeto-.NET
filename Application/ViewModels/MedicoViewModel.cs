using Domain.Entities;

namespace Application.ViewModels;
public class MedicoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Crm { get; set; }
    public string Cpf { get; set; }

    public MedicoViewModel(Medico medico)
    {
        Id = medico.Id;
        Nome = medico.Nome;
        Crm = medico.Crm;
        Cpf = medico.Cpf;
    }
}
