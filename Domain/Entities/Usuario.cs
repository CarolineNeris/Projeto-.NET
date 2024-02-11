using Domain.Common;

namespace Domain.Entities;

public class Usuario : BaseEntity
{
    public required string Nome { get; set; }
    public required string Apelido { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
    public int? EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
    public required ICollection<Perfil> Perfis { get; set; }

    public required ICollection<Sistema> Sistemas { get; set; }
}
