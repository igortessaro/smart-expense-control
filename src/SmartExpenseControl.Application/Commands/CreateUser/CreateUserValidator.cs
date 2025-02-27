using FluentValidation;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .MustAsync(async (email, _) => await userRepository.ExistsAsync(email, string.Empty));
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.RoleId).GreaterThan(0);
    }
}
