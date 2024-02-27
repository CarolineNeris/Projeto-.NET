using Application.InputModels;
using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUsuarioService : IBaseService<UsuarioViewModel, UsuarioInputModel>
{
    public Task<PerfilViewModel?> AddPerfil(int usuarioId, int perfilId);
    public Task<IEnumerable<UsuarioViewModel>> GetAllUsuariosAsync();
}
