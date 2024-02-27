using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class UsuarioService : BaseService<UsuarioViewModel, Usuario, UsuarioInputModel>, IUsuarioService
{
    private readonly ResTICDbContext _context;
    private readonly IMapper _mapper;
    public UsuarioService(ResTICDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
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
    public async Task<IEnumerable<UsuarioViewModel>> GetAllUsuariosAsync()
    {
        var usuarios = await _context.Usuarios
            .Include(u => u.Endereco)
            .ToListAsync();
        return _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
    }
}
