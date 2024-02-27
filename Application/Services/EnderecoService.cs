using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;

public class EnderecoService : BaseService<EnderecoViewModel, Endereco, EnderecoInputModel>, IEnderecoService
{
    public EnderecoService(ResTICDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
