using FluentValidation;
using SmartExpenseControl.Domain.Repositories;

namespace SmartExpenseControl.Application.Commands.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Email)
            .MustAsync(async (email, _) => !await userRepository.ExistsAsync(email, string.Empty))
            .WithMessage("Email address is already in use");
        RuleFor(x => x.Username)
            .MustAsync(async (username, _) => !await userRepository.ExistsAsync(string.Empty, username))
            .WithMessage("User is already in use");
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.RoleId).GreaterThan(0);
        RuleFor(x => x.RoleId)
            .MustAsync(async (roleId, _) => await userRoleRepository.ExistsAsync(roleId))
            .WithMessage("Role don't exist");
    }
}
