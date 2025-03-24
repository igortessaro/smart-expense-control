using FluentValidation;
using SmartExpenseControl.Application.Users.Commands;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Users.Validators;

public sealed class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Id)
            .MustAsync(async (id, _) => await userRepository.ExistsAsync(id))
            .WithMessage("User doesn't exist");
    }
}
