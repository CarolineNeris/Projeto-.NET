using AutoMapper;
using CleanArchitecture.Domain.Entities;
using Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetAllUser;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}