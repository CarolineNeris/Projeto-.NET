using MediatR;

namespace CleanArchitecture.Aplication.UseCases.CreateUser;
    public sealed record CreateUserRequest(string Email, string Name) :
                                          IRequest<CreateUserResponse>;

