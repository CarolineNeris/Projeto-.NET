namespace Application.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public EnderecoViewModel Endereco { get; set; }
}
