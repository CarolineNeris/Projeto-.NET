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
    }
}