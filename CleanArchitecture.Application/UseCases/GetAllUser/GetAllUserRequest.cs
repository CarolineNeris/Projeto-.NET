using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;

}
