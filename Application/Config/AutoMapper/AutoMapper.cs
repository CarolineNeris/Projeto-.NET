using Application.InputModels;
using Application.ViewModels;
using ApplicationI.InputModels;
using AutoMapper;
using Domain.Entities;

namespace  Application.Config.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PerfilInputModel, Perfil>();
        CreateMap<Perfil, PerfilViewModel>();

        CreateMap<UsuarioInputModel, Usuario>();
        CreateMap<Usuario, UsuarioViewModel>();

        CreateMap<EnderecoInputModel, Endereco>();
        CreateMap<Endereco, EnderecoViewModel>();

        CreateMap<EventoInputModel, Evento>();
        CreateMap<Evento, EventoViewModel>();
    }
}