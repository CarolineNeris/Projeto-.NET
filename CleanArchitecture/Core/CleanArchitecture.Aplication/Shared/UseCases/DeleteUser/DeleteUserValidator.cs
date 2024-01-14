using FluentValidation;

namespace CleanArchitecture.Aplication.UseCases.DeleteUser;
public sealed class DeleteUserValidator : AbstractValidator<DeleteUserRequest> {
    public DeleteUserValidator() {
        RuleFor(x => x.Id).NotEmpty();
    }
}
