using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;

public class UsuarioService : BaseService<UsuarioViewModel, Usuario, UsuarioInputModel>, IUsuarioService
{
    public UsuarioService(ResTICDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<PerfilViewModel?> AddPerfil(int usuarioId, int perfilId)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId);
        if(usuario is null) return null;

        var perfil = await _context.Perfils.FindAsync(perfilId);
        if(perfil is null) return null;

        if(usuario.Perfis.Contains(perfil)) return null;

        usuario.Perfis.Add(perfil);
        perfil.UsuarioId = usuario.Id;
        perfil.Usuario = usuario;
        return _mapper.Map<PerfilViewModel>(perfil);
    }
}
