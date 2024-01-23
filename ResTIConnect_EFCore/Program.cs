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
    Perfis = new List<Perfil>()
};

context.Usuarios.Add(user);
context.SaveChanges();

//Listando usuários
Console.WriteLine("Lista de usuários:");
context.Usuarios.ToList().ForEach(
    u => {
      Console.WriteLine($"Nome: {u.Nome}");
      Console.WriteLine($"Apelido: {u.Apelido}");
      Console.WriteLine($"Email: {u.Email}");
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