using FluentValidation;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed class DeleteUserValidator : AbstractValidator<CreateUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}
