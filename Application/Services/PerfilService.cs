using Application.ViewModels;
using ApplicationI.InputModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;
public class PerfilService : BaseService<PerfilViewModel, Perfil, PerfilInputModel>, IPerfilService
{
    public PerfilService(ResTICDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}