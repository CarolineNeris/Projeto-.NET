#region CRUD de Usuário

using Domain.Entities;
using Infrastructure;

var context = new ResTICDbContext();

context.Usuarios.RemoveRange(context.Usuarios);
context.SaveChanges();

//Criando usuário
var user = new Usuario {
    Nome = "Fulano",
    Apelido = "Fulaninho",
    Email = "fulano@email.com",
    Senha = "admin",
    Telefone = "1234-5678",
    Endereco = new Endereco {
        Logradouro = "Rua teste",
        Numero = "100",
        Cidade = "Ilhéus",
        Complemento = "Casa",
        Bairro = "Bairro teste",
        Estado = "Bahia",
        Cep = "12345-678",
        Pais = "Brasil"
    },
    Perfis = new List<Perfil>()
};
user.Endereco.Usuario = user;

context.Usuarios.Add(user);
context.SaveChanges();

//Listando usuários
Console.WriteLine("Lista de usuários:");
context.Usuarios.ToList().ForEach(
    u => {
      Console.WriteLine($"Nome: {u.Nome}");
      Console.WriteLine($"Apelido: {u.Apelido}");
      Console.WriteLine($"Email: {u.Email}");
      Console.WriteLine($"Endereço: {u.Endereco.Logradouro}, {u.Endereco.Bairro} - {u.Endereco.Cidade} - {u.Endereco.Pais}");
      Console.WriteLine();
    } 
);

//Atualizando usuário
var userToUpdate = context.Usuarios.Where(u => u.Nome == "Fulano").FirstOrDefault();
if(userToUpdate is not null) {
    Console.WriteLine("Atualizando usuário...");
    userToUpdate.Nome = "Fulano Silva";
    context.Usuarios.Update(userToUpdate);
    context.SaveChanges();
}

//Excluindo um usuário
var userToDelete = context.Usuarios.Where(u => u.Nome == "Fulano Silva").FirstOrDefault();
if(userToDelete is not null){
    Console.WriteLine($"Excluindo usuário {userToDelete.Nome}...");
    context.Usuarios.Remove(userToDelete);
    context.SaveChanges();
}
#endregion