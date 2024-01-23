using Domain.Common;
namespace Domain.Entities;
public class Perfil : BaseEntity {
    public required string Descricao { get; set; }
    public required string Permissoes { get; set; }
}
