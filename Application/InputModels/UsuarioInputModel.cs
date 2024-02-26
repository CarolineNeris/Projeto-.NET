namespace Application.InputModels;

public class UsuarioInputModel
{
    public required string Nome { get; set; }
    public required string Apelido { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public required string Telefone { get; set; }
    public required int EnderecoId { get; set; }
}
