using Domain.Common;
namespace Domain.Entities;
public class Endereco : BaseEntity {
    public required string Logradouro { get; set; }
    public required string Numero { get; set; }
    public required string Cidade { get; set; }
    public required string Complemento { get; set; }
    public required string Bairro { get; set; }
    public required string Estado { get; set; }
    public required string Cep { get; set; }
    public required string Pais { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}