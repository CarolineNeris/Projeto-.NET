using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;

public class SistemaService : BaseService<SistemaViewModel, Sistema, SistemaInputModel>, ISistemaService
{
    public SistemaService(ResTICDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
